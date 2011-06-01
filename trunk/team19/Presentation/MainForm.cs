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
            try
            {
                
                Autentica();
            }
            catch (KeyNotFoundException kexc)
            {
                MessageBox.Show(kexc.Message);
                Autentica();
            }

        }
        private void Autentica()
        {
            AuthenticationForm auth = new AuthenticationForm();

            DialogResult dr = auth.ShowDialog();
            if (dr.Equals(DialogResult.OK))
            {
                #region inizialize
                Document.CreateInstance(new DefaultPersister());

                Document.Autentica(auth.Username, auth.Password);

                _document = Document.GetInstance();

                //if (Document.GetInstance().UtenteConnesso == null)
                moneyGrid.DataSource = _document.ContenitoriDiDenaro;
                this.dgdipendenti.DataSource = _document.Dipendenti;
                IEnumerable<MovimentoDiDenaro> pagamenti = _document.GetPagamentiAcquisti();
                fattureGrid.DataSource = _document.Fatture;
                Cliente cl = _document.Soggetti.OfType<Cliente>().First();
                IRiepilogo riepilogo = RiepilogoFactory.CreateRiepilogo(cl);
                Dictionary<int, Currency> values = riepilogo.GetImportiDaPagare();
                textBox1.AppendText("Riepilogo importi da pagare cliente\n");
                foreach (int key in values.Keys)
                {
                    Currency c = null;
                    values.TryGetValue(key, out c);
                    textBox1.AppendText(key + " " + c.ToString() + "\n");
                }
                values = riepilogo.GetImportiPagati();
                textBox1.AppendText("Riepilogo importi pagati cliente\n");
                foreach (int key in values.Keys)
                {
                    Currency c = null;
                    values.TryGetValue(key, out c);
                    textBox1.AppendText(key + " " + c.ToString() + "\n");
                }
                Fornitore fo = _document.Soggetti.OfType<Fornitore>().First();
                riepilogo = RiepilogoFactory.CreateRiepilogo(fo);
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

                IEnumerable<Soggetto> soggetti = _document.Soggetti.OfType<Cliente>();
                foreach (Soggetto s in soggetti)
                    textBox1.AppendText(s.Denominazione + "\n");
                soggetti = _document.Soggetti.OfType<Fornitore>();
                foreach (Soggetto s in soggetti)
                    textBox1.AppendText(s.Denominazione + "\n");
                #endregion
            }
            else
                this.Close();




            //         UpdateDocument();
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
