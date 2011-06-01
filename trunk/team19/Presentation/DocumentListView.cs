using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team19.Model;
using System.Reflection;
namespace Team19.Presentation
{
    public partial class DocumentListView : UserControl
    {
        public event EventHandler SelectionChanged;
        public DocumentListView()
        {
            InitializeComponent();
            foreach (PropertyInfo info in Document.GetInstance().GetType().GetProperties())
            {
                object[] attributes = info.GetCustomAttributes(typeof(NomeVisualizzatoAttribute),true);
                if (attributes.Count()!=0)
                {

                    ListViewItem item = new ListViewItem(((NomeVisualizzatoAttribute)attributes[0]).NomeVisualizzato);
                    item.Tag = info.GetValue(Document.GetInstance(), null);
                    Items.Add(item);
                }
            }
        }

        private void iconeGrandiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _listView.View = View.LargeIcon;
        }

        private void iconePiccoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            _listView.View = View.SmallIcon;
        }

        private void listaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _listView.View = View.List;
        }
        public ImageList LargeImageList
        {
            get
            { return _listView.LargeImageList; }
            set
            { _listView.LargeImageList = value; }
        }
        public ListView.ListViewItemCollection Items
        {
            get
            { return _listView.Items; }
           
        }
        public View View
        {
            get
            { return _listView.View; }
            set
            { _listView.View = value; }
        }
        protected virtual void OnSelectionChanged()
        {
            if (SelectionChanged != null)
                SelectionChanged(this, EventArgs.Empty);
        }
        public ListViewItem SelectedItem
        {
            get
            {
                if(_listView.SelectedItems.Count!=0)
                    return _listView.SelectedItems[0];
                return null;
            }
        }

        private void _listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSelectionChanged();
        }
    }
}
