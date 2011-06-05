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
        public object ElementoCreato
        {
            get { return _elementoCreato; }
        }

        public InsertForm(Type tipoElemento)
        {
            InitializeComponent();
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

        public void InizializzaForm(object sender, EventArgs e)
        {
            _detailsPanel.Controls.Clear();
            Type tipoElemento = (Type)_subtypeCombo.SelectedItem;
            foreach (MethodInfo method in typeof(ElementFactory).GetMethods())
            {
                if (method.GetCustomAttributes(typeof(MetodoCreazioneAttribute), false).Count() != 0)
                {
                    MetodoCreazioneAttribute metodoCreazione = (MetodoCreazioneAttribute)method.GetCustomAttributes(typeof(MetodoCreazioneAttribute), false).First();
                    if (tipoElemento.Name.Equals(metodoCreazione.Tipo))
                    {
                        for (int i = 0; i < method.GetParameters().Count(); i++)
                        {
                            Label parameterLabel = new Label();
                            parameterLabel.Text = method.GetParameters()[i].Name;
                            _detailsPanel.Controls.Add(parameterLabel);
                            Control parameterControl = (System.Windows.Forms.Control)typeof(Form).Assembly.CreateInstance(metodoCreazione.Controlli[i].FullName);
                            _detailsPanel.Controls.Add(parameterControl);
                            if (parameterControl is ComboBox)
                            {
                                foreach (MethodInfo docMethod in Document.GetInstance().GetType().GetMethods())
                                {
                                    //Provare con attributo custom nei metodi di document (aggiungere getter per i sottotipi
                                    if (docMethod.ReturnType.GetGenericArguments().Count() != 0)
                                    {
                                        Type genericType = docMethod.ReturnType.GetGenericArguments()[0];
                                        Type type = method.GetParameters()[i].ParameterType;
                                        if (genericType.Equals(type) || (genericType.GetInterfaces().Count()!=0 && type.Equals(genericType.GetInterfaces().First()) ))
                                        {
                                            ((ComboBox)parameterControl).DataSource = docMethod.Invoke(Document.GetInstance(), null);

                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }


            //foreach (PropertyInfo info in tipoElemento.GetProperties())
            //{

            //    object[] attributes = info.GetCustomAttributes(typeof(ControlloAssociatoAttribute), true);
            //    if (attributes.Count() != 0)
            //    {
            //        ControlloAssociatoAttribute attributoTipoControllo = (ControlloAssociatoAttribute)info.GetCustomAttributes(typeof(ControlloAssociatoAttribute), true)[0];
            //        Type tipoControlloAssociato = attributoTipoControllo.Controllo;
            //        Label propertyLabel = new Label();
            //        propertyLabel.Text = info.Name;
            //        _detailsPanel.Controls.Add(propertyLabel);
            //        Control controlloAssociato = (System.Windows.Forms.Control)typeof(Form).Assembly.CreateInstance(tipoControlloAssociato.FullName);
            //        _detailsPanel.Controls.Add(controlloAssociato);
            //        if (controlloAssociato is ComboBox)
            //        {
            //            foreach (MethodInfo method in Document.GetInstance().GetType().GetMethods())
            //            {
            //                //Provare con attributo custom nei metodi di document (aggiungere getter per i sottotipi
            //                Type returnType = method.ReturnType;
            //                if (attributoTipoControllo.Tipo != null && attributoTipoControllo.Tipo.Equals(returnType))
            //                {
            //                    ((ComboBox)controlloAssociato).DataSource = method.Invoke(Document.GetInstance(), null);

            //                }
            //            }
            //        }
            //        if (controlloAssociato is Label)
            //        {
            //            ((Label)controlloAssociato).Text = attributoTipoControllo.Tipo.Name;
            //        }

            //    }



            //}
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _okButton_Click(object sender, EventArgs e)
        {


            this.Close();
        }


    }
}
