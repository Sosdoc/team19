using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    public class FatturaVendita : Fattura, ISorgente
    {
        private List<RigaFattura> _elencoProdotti;
        private Cliente _cliente;

        private static int _numeroUltimaFattura = 0;

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

        public static FatturaVendita CreateFatturaVendita(Cliente cliente, DateTime data, List<RigaFattura> elencoProdotti)
        {
            if (Document.GetInstance().GetFattureVendita().Count() != 0)
            {   //Se ci sono già delle fatture in document recupero l'ultima fattura e calcolo il prossimo numero
                FatturaVendita ultimaFattura =
                (from fattura in Document.GetInstance().GetFattureVendita()
                 orderby fattura.Data descending
                 select fattura).First();

                _numeroUltimaFattura = ultimaFattura.NumeroFattura + 1;

                if (!data.Year.Equals(ultimaFattura.Data.Year)) //se è cambiato anno torno al numero 1
                    _numeroUltimaFattura = 1;
            }
            else
                _numeroUltimaFattura = 1;        

            return new FatturaVendita(cliente, data, _numeroUltimaFattura, elencoProdotti);
        }

        public IEnumerable<RigaFattura> ElencoProdotti
        {
            get
            {
                return _elencoProdotti;
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
    }
}
