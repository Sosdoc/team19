using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team19.Model;
using Team19.Persistence;
using System.Reflection;
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
                    _document = Document.GetInstance();
                    _document.Autentica(auth.Username, auth.Password);
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
            Soggetto soggetto = null;
            if (_dataGridView.SelectedRows.Count == 1)
            {
                soggetto = _document.Soggetti.ElementAt(_dataGridView.SelectedRows[0].Index);
            }
            using (FormRiepilogo formRiepilogo = new FormRiepilogo(soggetto))
            {
                formRiepilogo.ShowDialog();
            }
        }

        public void CreaElemento(object sender, EventArgs e)
        {
            try
            {
                using (InsertForm form = new InsertForm(_dataGridView.DataType))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {   //Aggiunta di un oggetto ai contentitori

                        //recupero la property del document relativa al tipo creato
                        PropertyInfo property = _document.GetType().GetProperties().Where(prop => prop.PropertyType.GetGenericArguments().Contains(_dataGridView.DataType)).First();
                        //recupero il metodo Add(object) della property
                        MethodInfo add = property.GetValue(_document, null).GetType().GetMethod("Add", new Type[] { typeof(object) });
                        //invoco il metodo Add
                        add.Invoke(property.GetValue(_document, null), new object[1] { form.ElementoCreato });
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
