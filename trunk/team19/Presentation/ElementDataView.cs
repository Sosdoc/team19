using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
namespace Team19.Presentation
{
    public partial class ElementDataView : UserControl
    {
        private object _dataSource;
        public ElementDataView()
        {
            InitializeComponent();
        }
        private void FiltraElenco(object sender, EventArgs e)
        {
            _dataGridView.DataSource = _dataSource;
            RadioButton radio = (RadioButton)sender;
            Type t = (Type)radio.Tag;
            IEnumerable<object> elenco = ((IEnumerable<object>)_dataSource);
            //for (int i = 0; i < elenco.Count(); i++)
            //{
            //    if (!elenco.ElementAt(i).GetType().Equals(t))
            //        _dataGridView.Rows.RemoveAt(i);
            //}
            //_dataGridView
            //
        }
        public DataGridViewSelectedRowCollection SelectedRows
        {
            get { return _dataGridView.SelectedRows; }
        }
        public object DataSource
        {
            get { return _dataSource; }
            set
            {
                _dataSource = value;
                _dataGridView.DataSource = _dataSource;
                if (_dataSource != null)
                {
                    _radioButtonPanel.Controls.Clear();
                    Type mainclass = _dataSource.GetType().GetGenericArguments()[0];
                    if (mainclass.IsAbstract)
                    {
                        foreach (Type type in Assembly.GetAssembly(mainclass).GetTypes())
                        {
                            
                            if (type.IsSubclassOf(mainclass))
                            {
                                RadioButton subclassRadio = new RadioButton();
                                subclassRadio.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                                subclassRadio.TextAlign = ContentAlignment.MiddleLeft;
                                subclassRadio.Text = type.Name;
                                _radioButtonPanel.Controls.Add(subclassRadio);
                                subclassRadio.CheckedChanged += FiltraElenco;
                                subclassRadio.Tag = type;
                            }
                        }
                        RadioButton mainclassRadio = new RadioButton();
                        mainclassRadio.TextAlign = ContentAlignment.MiddleLeft;
                        mainclassRadio.Text = "Tutti";
                        _radioButtonPanel.Controls.Add(mainclassRadio);
                        mainclassRadio.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                        mainclassRadio.CheckedChanged += FiltraElenco;
                        mainclassRadio.Tag = mainclass;
                    }
                }
            }
        }
    }
}
