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
            Document.Changed += AggiornaLista;
        }

        public ImageList LargeImageList
        {
            get
            { return _listView.LargeImageList; }
            set
            { _listView.LargeImageList = value; }
        }

        public ImageList SmallImageList
        {
            get
            { return _listView.SmallImageList; }
            set
            { _listView.SmallImageList = value; }
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

        public ListViewItem SelectedItem
        {
            get
            {
                if (_listView.SelectedItems.Count != 0)
                    return _listView.SelectedItems[0];
                return null;
            }

        }

        protected virtual void OnSelectionChanged()
        {
            if (SelectionChanged != null)
                SelectionChanged(this, EventArgs.Empty);
        }

        private void iconeGrandiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _listView.View = View.LargeIcon;
            AggiornaLista(sender, e);
        }

        private void iconePiccoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _listView.View = View.SmallIcon;
            AggiornaLista(sender, e);
        }

        private void listaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _listView.View = View.List;
            AggiornaLista(sender, e);
        }

        //private void _listView_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    OnSelectionChanged();
        //}

        private void AggiornaLista(object sender, EventArgs e)
        {
            ListViewItem selected = SelectedItem;
            _listView.Clear();

            foreach (PropertyInfo info in Document.GetInstance().GetType().GetProperties())
            {
                object[] attributes = info.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                if (attributes.Count() != 0)
                {
                    string nomeVisualizzato = ((DisplayNameAttribute)attributes[0]).DisplayName;
                    ListViewItem item = new ListViewItem(nomeVisualizzato);
                    item.Tag = info.GetValue(Document.GetInstance(), null);

                    if (item.Tag != null)
                    {
                        if (item.Tag.GetType().BaseType.GetGenericArguments().Count() == 0)
                        {
                            IList<object> list = new List<object>();
                            list.Add(item.Tag);
                            item.Tag = list;
                        }

                        item.ImageKey = nomeVisualizzato;

                        if (selected != null && selected.Tag.Equals(item.Tag))
                            item.Selected = true;

                        Items.Add(item);

                    }
                }
            }
        }

        private void _listView_SelectedIndexChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            OnSelectionChanged();
        }

    }
}
