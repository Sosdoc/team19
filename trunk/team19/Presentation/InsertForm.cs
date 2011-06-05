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

        private MethodInfo trovaMetodoCreazione(Type tipoElemento)
        {
            foreach (MethodInfo method in typeof(ElementFactory).GetMethods())
            {
                if (method.GetCustomAttributes(typeof(MetodoCreazioneAttribute), false).Count() != 0)
                {
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
            _tipoElemento = (Type)_subtypeCombo.SelectedItem;
            MethodInfo metodoCreazione = trovaMetodoCreazione(_tipoElemento);
            if (metodoCreazione == null) throw new InvalidOperationException("Impossibile aggiungere un nuovo oggetto");
            Type[] controlli = ((MetodoCreazioneAttribute)metodoCreazione.GetCustomAttributes(typeof(MetodoCreazioneAttribute), false).First()).Controlli;
            for (int i = 0; i < metodoCreazione.GetParameters().Count(); i++)
            {
                //Aggiunta label con nome della proprietà e controllo per inserimento del valore
                Label parameterLabel = new Label();
                parameterLabel.Text = metodoCreazione.GetParameters()[i].Name.ToUpper();
                _detailsPanel.Controls.Add(parameterLabel);
                Control parameterControl = (System.Windows.Forms.Control)typeof(Form).Assembly.CreateInstance(controlli[i].FullName);
                parameterControl.Tag = metodoCreazione.GetParameters()[i];
                _detailsPanel.Controls.Add(parameterControl);

                //Riempimento combobox
                if (parameterControl is ComboBox)
                {
                    foreach (MethodInfo docMethod in Document.GetInstance().GetType().GetMethods())
                    {
                        if (docMethod.ReturnType.GetGenericArguments().Count() != 0)
                        {
                            Type genericType = docMethod.ReturnType.GetGenericArguments()[0];
                            Type type = metodoCreazione.GetParameters()[i].ParameterType;
                            if (genericType.Equals(type) || (genericType.GetInterfaces().Count() != 0 && type.Equals(genericType.GetInterfaces().First())))
                            {
                                ((ComboBox)parameterControl).DataSource = docMethod.Invoke(Document.GetInstance(), null);

                            }
                        }
                    }
                }
                if (parameterControl is Label)
                {
                    ((Label)parameterControl).Text = metodoCreazione.GetParameters()[i].ParameterType.Name;

                }
            }
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreaElemento(object sender, EventArgs e)
        {
            MethodInfo metodoCreazione = trovaMetodoCreazione(_tipoElemento);
            if (metodoCreazione != null)
            {
                List<object> parameters = new List<object>();
                foreach (Control c in _detailsPanel.Controls)
                {

                    if (c.Tag != null)
                    {
                        if (c is ComboBox)
                            parameters.Add(((ComboBox)c).SelectedItem);
                        else
                            parameters.Add(c.Text);

                    }
                }

                _elementoCreato = metodoCreazione.Invoke(null, parameters.ToArray());
            }

            this.Close();
        }

    }
}
