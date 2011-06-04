using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace Team19.Model
{
    public class FatturaVendita : Fattura, ISorgente
    {
        private List<RigaFattura> _elencoProdotti;
        private Cliente _cliente;

        // private static FatturaVendita _ultimaFattura = new FatturaVendita(SoggettoFactory.CreateCliente(".", ".", ".", ".", ".", new Indirizzo("", "", "", "", "", "")), DateTime.MinValue, 1, new List<RigaFattura>());

        private static Dictionary<int, int> _dizionarioFatture = new Dictionary<int, int>(); //chiave: anno - valore: numero fattura

        private FatturaVendita(Cliente cliente, DateTime data, int numero, List<RigaFattura> elencoProdotti)
            : base(data, numero)
        {
            if (elencoProdotti == null)
                throw new ArgumentNullException("elencoProdotti");
            if (cliente == null)
                throw new ArgumentNullException("cliente");

            this._elencoProdotti = elencoProdotti;
            this._cliente = cliente;
        }

        private static int NumeroProssimaFatturaDiVendita(DateTime dataNuovaFattura)
        {
            //usa il dizionario per recuperare l'ultimo numero di fattura in base all'anno
            if (!_dizionarioFatture.ContainsKey(dataNuovaFattura.Year))
            {
                _dizionarioFatture.Add(dataNuovaFattura.Year, 1);
                return 1;
            }
            else
            {
                _dizionarioFatture[dataNuovaFattura.Year] += 1;
                return _dizionarioFatture[dataNuovaFattura.Year];
            }
        }

        public static FatturaVendita CreateFatturaVendita(Cliente cliente, DateTime data, List<RigaFattura> elencoProdotti)
        {

            FatturaVendita nuovaFattura = new FatturaVendita(cliente, data, NumeroProssimaFatturaDiVendita(data), elencoProdotti);
            return nuovaFattura;

        }

        [Browsable(false)]
        [ControlloAssociato(typeof(ComboBox))]
        public IEnumerable<RigaFattura> ElencoProdotti
        {
            get
            {
                return _elencoProdotti;
            }
        }

        [DisplayName("Prodotti")]
        public string Elenco
        {
            get
            {
                return "Vendita di " + ElencoProdotti.Count() + " prodotti diversi";
            }
        }

        [ControlloAssociato(typeof(ComboBox))]
        public Cliente Cliente
        {
            get { return _cliente; }
        }

        [ControlloAssociato(typeof(TextBox))]
        public override Currency Importo
        {
            get
            {
                Currency sum = new Currency(0m);
                foreach (RigaFattura riga in _elencoProdotti)
                {
                    sum += riga.PrezzoUnitario * riga.Quantità;
                }
                return sum;
            }
        }
    }
}
