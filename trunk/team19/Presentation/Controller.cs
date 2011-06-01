using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team19.Model;
using Team19.Persistence;
namespace Team19.Presentation
{
    class Controller
    {
        private Document _document;
        private readonly DocumentListView _documentListView;
        private readonly DataGridView _dataGridView;
        public Controller(DocumentListView documentListView, DataGridView dataGridView)
        {
            _documentListView = documentListView;
            _dataGridView = dataGridView;
            _documentListView.SelectionChanged += AggiornaTabella;

        }
        public void Autentica()
        {
            using (AuthenticationForm auth = new AuthenticationForm())
            {
                if (auth.ShowDialog() == DialogResult.OK)
                {
                    #region inizialize
                    Document.CreateInstance(new DefaultPersister());

                    Document.Autentica(auth.Username, auth.Password);

                    _document = Document.GetInstance();

                    //if (Document.GetInstance().UtenteConnesso == null)
                    _dataGridView.DataSource = _document.Movimenti;
                    #endregion
                    IEnumerable<MovimentoDiDenaro> m = _document.Movimenti;
                    //ImageList list = new ImageList();
                    //list.Images.Add(Icon);
                    //_documentListView.LargeImageList = list;
                   
                }
                else Application.Exit();
            }


        }

        private void AggiornaTabella(object sender, EventArgs e)
        {
            if(_documentListView.SelectedItem!=null)
            _dataGridView.DataSource = _documentListView.SelectedItem.Tag;
        }
    }
}
