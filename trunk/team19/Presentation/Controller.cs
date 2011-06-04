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
        private readonly ElementDataView _dataGridView;

        public Controller(DocumentListView documentListView, ElementDataView dataGridView)
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
                    #region initialize
                    Document.CreateInstance(new DefaultPersister());

                    Document.Autentica(auth.Username, auth.Password);

                    _document = Document.GetInstance();

                    //if (Document.GetInstance().UtenteConnesso == null)
                    _dataGridView.DataSource = _document.Movimenti;
                    #endregion
                    IEnumerable<MovimentoDiDenaro> m = _document.Movimenti;
                }
                else Application.Exit();
            }
        }

        private void AggiornaTabella(object sender, EventArgs e)
        {
            if (_documentListView.SelectedItem != null)
                _dataGridView.DataSource = _documentListView.SelectedItem.Tag;
        }

        public void MostraRiepilogo()
        {
            Soggetto s = null;
            if (_dataGridView.SelectedRows.Count == 1)
            {
                s = _document.Soggetti.ElementAt(_dataGridView.SelectedRows[0].Index);
            }
            using (FormRiepilogo formRiepilogo = new FormRiepilogo(s))
            {
                formRiepilogo.ShowDialog();
            }
        }
    }
}
