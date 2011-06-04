﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Team19.Model;
namespace Team19.Presentation
{
    public partial class ElementDataView : UserControl
    {
        private object _dataSource;
        public ElementDataView()
        {
            InitializeComponent();
            _subItemsCombo.SelectionChangeCommitted += FiltraElenco;
        }

        private void FiltraElenco(object sender, EventArgs e)
        {
           // _dataGridView.DataSource = _dataSource;
            //RadioButton radio = (RadioButton)sender;
            //Type tipo = (Type)radio.Tag;
            Type tipo = (Type)_subItemsCombo.SelectedItem;
            IEnumerable<object> elenco = ((IEnumerable<object>)_dataSource);
            IList<object> elencoFiltrato = new List<object>();
            foreach (object obj in elenco)
            {
                if (obj.GetType().Equals(tipo))
                    elencoFiltrato.Add(obj);
            }
            _dataGridView.DataSource = elencoFiltrato;
            

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
                    _subItemsCombo.Items.Clear();
                    _subItemsCombo.Text = "";
                    Type mainclass = _dataSource.GetType().GetGenericArguments()[0];
                    
                    if (mainclass.IsAbstract)
                    {
                        foreach (Type type in Assembly.GetAssembly(mainclass).GetTypes())
                        {
                            
                            if (type.IsSubclassOf(mainclass) &&!type.IsAbstract)
                            {
                                _subItemsCombo.Items.Add(type);
                            }
                        }
                        _subItemsCombo.DisplayMember = "Name";
                    }
                }
            }
        }
    }
}
