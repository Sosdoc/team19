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

        private static Dictionary<int, int> _dizionarioFatture = new Dictionary<int, int>(); //chiave: anno -- valore: numero fattura

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

        // Usa il dizionario per recuperare l'ultimo numero di fattura in base all'anno
        private static int NumeroProssimaFatturaDiVendita(DateTime dataNuovaFattura)
        {

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
            return new FatturaVendita(cliente, data, NumeroProssimaFatturaDiVendita(data), elencoProdotti);
        }

        #region FatturaVendita properties

        [Browsable(false)]
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

        public Cliente Cliente
        {
            get { return _cliente; }
        }

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

        #endregion
    }
}
