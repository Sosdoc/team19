using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team19.Model;
using Team19.Persistence;
namespace Team19.Presentation
{
    public partial class MainForm : Form
    {
        private Document _document;

        public MainForm()
        {
            InitializeComponent();
            AuthenticationForm auth = new AuthenticationForm();

            //DialogResult dr = auth.ShowDialog();
            //if (dr.Equals(DialogResult.Yes))
            //{
            Document.CreateInstance(new DefaultPersister());
            //Document.Autentica(auth.Username,auth.Password);
            _document = Document.GetInstance();

            // if (Document.GetInstance().UtenteConnesso == null)
            moneyGrid.DataSource = _document.ContenitoriDiDenaro;
            this.dgdipendenti.DataSource = _document.Dipendenti;
            
            fattureGrid.DataSource = _document.Fatture;
            ICliente cl = _document.Soggetti.OfType<ICliente>().First();
            IRiepilogo riepilogo = new RiepilogoCliente(cl);
            Dictionary<int,Currency> values = riepilogo.GetImportiDaPagare();
            textBox1.AppendText("Riepilogo importi da pagare cliente\n");
            foreach (int key in values.Keys)
            {
                Currency c=null;
                values.TryGetValue(key,out c);
                textBox1.AppendText(key + " " +c.ToString()+"\n");
            }
            values = riepilogo.GetImportiPagati();
            textBox1.AppendText("Riepilogo importi pagati cliente\n");
            foreach (int key in values.Keys)
            {
                Currency c = null;
                values.TryGetValue(key, out c);
                textBox1.AppendText(key + " " + c.ToString() + "\n");
            }
            IFornitore fo = _document.Soggetti.OfType<IFornitore>().First();
            riepilogo = new RiepilogoFornitore(fo);
            values = riepilogo.GetImportiDaPagare();
            textBox1.AppendText("Riepilogo importi da pagare Fornitore\n");
            foreach (int key in values.Keys)
            {
                Currency c = null;
                values.TryGetValue(key, out c);
                textBox1.AppendText(key + " " + c.ToString() + "\n");
            }
            values = riepilogo.GetImportiPagati();
            textBox1.AppendText("Riepilogo importi pagati Fornitore\n");
            foreach (int key in values.Keys)
            {
                Currency c = null;
                values.TryGetValue(key, out c);
                textBox1.AppendText(key + " " + c.ToString() + "\n");
            }

            IEnumerable<ISoggetto> soggetti = _document.Soggetti.OfType<ICliente>();
            foreach (ISoggetto s in soggetti)
                textBox1.AppendText(s.Denominazione +"\n");
            soggetti = _document.Soggetti.OfType<IFornitore>();
            foreach (ISoggetto s in soggetti)
                textBox1.AppendText(s.Denominazione + "\n");
            

            //         UpdateDocument();
            //}
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //MessageBox.Show((new Currency(10.30m)).ToString());




        }
        private void UpdateDocument()
        {
            DataTable d = new DataTable();

            d.Columns.Add("Tipo di deposito");
            d.Columns.Add("Codice");
            d.Columns.Add("Saldo iniziale");
            d.Columns.Add("Saldo corrente");
            Cassa cassa = _document.Cassa;
            List<string> rowValues = new List<string>();
            rowValues.Add(cassa.GetType().Name);
            rowValues.Add("");
            rowValues.Add(cassa.SaldoIniziale.ToString());
            rowValues.Add(cassa.Saldo.ToString());
            d.Rows.Add(rowValues.ToArray());
            foreach (ContenitoreDiDenaro c in _document.ContenitoriDiDenaro)
            {
                rowValues = new List<string>();
                rowValues.Add(c.GetType().Name);
                if (c is ContoCorrenteBancario) rowValues.Add(((ContoCorrenteBancario)c).CodConto);
                else rowValues.Add("");
                rowValues.Add(c.SaldoIniziale.ToString());
                rowValues.Add(c.Saldo.ToString());
                d.Rows.Add(rowValues.ToArray());

            }

            moneyGrid.DataSource = d;
        }

        private void dgdipendenti_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgdipendenti_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow dv = dgdipendenti.CurrentRow;
            txtnome.Text = dv.Cells["nome"].Value.ToString();
            txtcognome.Text = dv.Cells["cognome"].Value.ToString();
            txtuser.Text = dv.Cells["username"].Value.ToString();
            txtpassword.Text = dv.Cells["password"].Value.ToString();
            cmbruolo.Text = dv.Cells["ruolo"].Value.ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //if (radioButton1.Checked==true)
            //{
            //    comboBox1.Items.Clear();
            //    IEnumerable<Fornitore> fornitori = _document.Soggetti.Where(soggetto => soggetto is Fornitore);
            //    foreach (Soggetto s in _document.GetFornitori()) comboBox1.Items.Add(s.Denominazione);
            //}
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == false)
            {
                comboBox1.Items.Clear();

         //       foreach (Soggetto s in _document.GetFornitori()) comboBox1.Items.Add(s.Denominazione);
            }
        }
    }
}
