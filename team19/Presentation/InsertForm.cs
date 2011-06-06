using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Team19.Model;
namespace Team19.Presentation
{
    /// <summary>
    /// NOTA: La creazione di alcuni tipi di oggetti(ad es. FatturaVendita) necessita di parametri il cui inserimento nel form andrebbe fatto con degli UserControl specifici
    /// </summary>
    public partial class InsertForm : Form
    {
        private object _elementoCreato;
        private Type _tipoElemento;

        public object ElementoCreato
        {
            get { return _elementoCreato; }
        }

        public InsertForm(Type tipoElemento)
        {
            InitializeComponent();
            _okButton.Click += CreaElemento;

            //Qui viene popolata la ComboBox per scegliere il tipo concreto da creare
            if (tipoElemento.IsAbstract)
            {
                foreach (Type type in Assembly.GetAssembly(tipoElemento).GetTypes())
                {
                    if (type.IsSubclassOf(tipoElemento) && !type.IsAbstract)
                    {
                        _subtypeCombo.Items.Add(type);
                    }
                }
                _subtypeCombo.DisplayMember = "Name";

            }
            else
            {
                _subtypeCombo.Items.Add(tipoElemento);
                _subtypeCombo.SelectedItem = tipoElemento;
                InizializzaForm(this, EventArgs.Empty);
            }

            _detailsBox.Text = "Inserimento " + tipoElemento.Name;
            _subtypeCombo.SelectionChangeCommitted += InizializzaForm;

        }

        //Recupera il metodo adeguato per la creazione di un oggetto di tipo tipoElemento, i metodi per la creazione sono contenuti in ElementFactory
        private MethodInfo trovaMetodoCreazione(Type tipoElemento)
        {
            foreach (MethodInfo method in typeof(ElementFactory).GetMethods())
            {
                if (method.GetCustomAttributes(typeof(MetodoCreazioneAttribute), false).Count() != 0)
                {
                    //L'attributo custom contiene anche una lista di controlli con cui riempire il form
                    MetodoCreazioneAttribute metodoCreazione = (MetodoCreazioneAttribute)method.GetCustomAttributes(typeof(MetodoCreazioneAttribute), false).First();
                    if (tipoElemento.Name.Equals(metodoCreazione.Tipo))
                        return method;
                }
            }
            return null;
        }

        public void InizializzaForm(object sender, EventArgs e)
        {

            _detailsPanel.Controls.Clear();
            _detailsPanel.FlowDirection = FlowDirection.TopDown;
            _tipoElemento = (Type)_subtypeCombo.SelectedItem;

            //recupero il metodo per creare l'oggetto
            MethodInfo metodoCreazione = trovaMetodoCreazione(_tipoElemento);

            if (metodoCreazione == null) 
                throw new InvalidOperationException("Impossibile aggiungere un nuovo oggetto");

            Type[] controlli = ((MetodoCreazioneAttribute)metodoCreazione.GetCustomAttributes(typeof(MetodoCreazioneAttribute), false).First()).Controlli;

            for (int i = 0; i < metodoCreazione.GetParameters().Count(); i++)
            {
                //Aggiunta label con nome della proprietà e controllo per inserimento del valore
                Label parameterLabel = new Label();
                parameterLabel.Text = metodoCreazione.GetParameters()[i].Name;
                _detailsPanel.Controls.Add(parameterLabel);

                //Aggiunta controllo per l'inserimento del parametro
                Control parameterControl = (System.Windows.Forms.Control)typeof(Form).Assembly.CreateInstance(controlli[i].FullName);
                parameterControl.Tag = metodoCreazione.GetParameters()[i];
                _detailsPanel.Controls.Add(parameterControl);

                //Riempimento combobox
                if (parameterControl is ComboBox)
                {
                    RiempiControllo((ComboBox)parameterControl);
                }
            }


        }


        //Questo metodo è usato per popolare le ComboBox inserite nel form, cerca un metodo che restituisca una lista del tipo adeguato nel Document.
        private void RiempiControllo(ComboBox controllo)
        {
            foreach (MethodInfo docMethod in Document.GetInstance().GetType().GetMethods()) //itero su tutti i metodi di Document
            {
                if (docMethod.ReturnType.GetGenericArguments().Count() != 0) //se il metodo restituisce un oggetto con tipo generico
                {
                    Type genericType = docMethod.ReturnType.GetGenericArguments()[0];
                    Type tipoParametro = ((ParameterInfo)controllo.Tag).ParameterType;
                    if (genericType.Equals(tipoParametro) || (genericType.GetInterfaces().Count() != 0 && tipoParametro.Equals(genericType.GetInterfaces().First())))
                    {   //se il tipo generico è quello da usare per riempire il controllo(contenuto nel tag) oppure il tipo implementa l'interfaccia
                        controllo.DataSource = docMethod.Invoke(Document.GetInstance(), null);
                    }
                }
            }
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Questo handler trova un metodo decorato con MetodoCreazioneAttribute e lo invoca per creare l'oggetto adeguato
        private void CreaElemento(object sender, EventArgs e)
        {
            try
            {
                MethodInfo metodoCreazione = trovaMetodoCreazione(_tipoElemento); //recupero il metodo adeguato per creare l'oggetto
                if (metodoCreazione != null)
                {
                    List<object> parameters = new List<object>();
                    foreach (Control c in _detailsPanel.Controls)
                    {
                        if (c.Tag != null)
                        {
                            //è necessario discriminare il tipo di controllo, se è una ComboBox si può ottenere direttamente il riferimento all'oggetto selezionato
                            //nel caso di una TextBox o un DateTimePicker viene semplicemente recuperato il testo, di cui verrà fatto il parsing nella factory se necessario
                            if (c is ComboBox)
                                parameters.Add(((ComboBox)c).SelectedItem);
                            else
                                parameters.Add(c.Text);
                        }
                    }
                    //Qui viene invocata la creazione dell'elemento
                    _elementoCreato = metodoCreazione.Invoke(null, parameters.ToArray());
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
