using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team19.Model;
namespace Team19.Presentation
{
    public partial class FormRiepilogo : Form
    {
        private Dictionary<int, Currency> _riepilogo = new Dictionary<int, Currency>();
        public FormRiepilogo()
        {
            InitializeComponent();
            //   _soggettiCombo.DataSource = Document.GetInstance().Soggetti;
            foreach (Soggetto s in Document.GetInstance().Soggetti)
                _soggettiCombo.Items.Add(s);
            _soggettiCombo.SelectionChangeCommitted += MostraRiepilogo;
            _checkPagate.Checked = true;
            _checkNonPagate.Checked = true;
            _checkNonPagate.CheckedChanged += MostraRiepilogo;
            _checkPagate.CheckedChanged += MostraRiepilogo;

        }
        public FormRiepilogo(Soggetto soggetto)
            : this()
        {
            
            _soggettiCombo.SelectedItem = soggetto;
            if (soggetto != null) MostraRiepilogo(this, EventArgs.Empty);
        }

        private void MostraRiepilogo(object sender, EventArgs e)
        {
            IRiepilogo riepilogo = RiepilogoFactory.CreateRiepilogo((Soggetto)_soggettiCombo.SelectedItem);
            IList<Fattura> listaFatture = new List<Fattura>();

            if (_checkPagate.Checked) listaFatture = riepilogo.GetImportiPagati().ToList();
            if (_checkNonPagate.Checked) listaFatture = riepilogo.GetImportiDaPagare().ToList();
            
            _riepilogoDataGrid.DataSource = listaFatture;
        }
    }
}
