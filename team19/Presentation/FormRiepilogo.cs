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
        public FormRiepilogo(Soggetto soggetto):this()
        {
            _soggettiCombo.SelectedItem = soggetto;
            MostraRiepilogo(this, EventArgs.Empty);
        }

        private void MostraRiepilogo(object sender, EventArgs e)
        {
            IRiepilogo riepilogo = RiepilogoFactory.CreateRiepilogo((Soggetto)_soggettiCombo.SelectedItem);
            Dictionary<int, Currency> listaFatture = new Dictionary<int, Currency>();
            if (_checkPagate.Checked) listaFatture.Concat(riepilogo.GetImportiPagati()).ToDictionary(entry=>entry.Key,entry=>entry.Value);
            if (_checkNonPagate.Checked) listaFatture.Concat(riepilogo.GetImportiDaPagare().ToDictionary(entry => entry.Key, entry => entry.Value));
            //var lista = from row in listaFatture
            //                  select new { Numero = row.Key, Importo = row.Value };
            _riepilogoDataGrid.DataSource = listaFatture.ToList();
        }
    }
}
