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
            foreach (PropertyInfo info in tipoElemento.GetProperties())
            {

                object[] attributes = info.GetCustomAttributes(typeof(ControlloAssociatoAttribute), true);
                if (attributes.Count() != 0)
                {
                    Type tipoControlloAssociato = ((ControlloAssociatoAttribute)info.GetCustomAttributes(typeof(ControlloAssociatoAttribute), true)[0]).Controllo;
                    Label propertyLabel = new Label();
                    propertyLabel.Text = info.Name;
                    _detailsPanel.Controls.Add(propertyLabel);
                    Control controlloAssociato = (System.Windows.Forms.Control)typeof(Form).Assembly.CreateInstance(tipoControlloAssociato.FullName);
                    _detailsPanel.Controls.Add(controlloAssociato);
                    if (controlloAssociato is ComboBox)
                    {
                        foreach (PropertyInfo docInfo in Document.GetInstance().GetType().GetProperties())
                        {
                            //Provare con attributo custom nei metodi di document (aggiungere getter per i sottotipi
                            Type[] generics = docInfo.PropertyType.GetGenericArguments();
                            if (generics.Contains(info.PropertyType.BaseType))
                            {
                                
                                    ((ComboBox)controlloAssociato).DataSource = docInfo.GetValue(Document.GetInstance(), null);
                            }
                        }
                    }

                }



            }
        }


    }
}
