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
    public partial class MainForm : Form
    {
        private Document _document;

        public MainForm()
        {
            InitializeComponent();
            _document = Document.GetInstance();
            UpdateDocument();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show((new Currency(10.30m)).ToString());
            
           
            

        }

        private void UpdateDocument()
        {
            DataTable d = new DataTable();

            d.Columns.Add("Tipo di deposito");
            d.Columns.Add("Codice");
            d.Columns.Add("Saldo iniziale");
            d.Columns.Add("Saldo corrente");
            Cassa cassa= _document.Cassa;
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
                if (c is Cassa) rowValues.Add(c.Saldo.ToString());
                else rowValues.Add("");
                d.Rows.Add(rowValues.ToArray());

            }

            moneyGrid.DataSource = d;
        }
    }
}
