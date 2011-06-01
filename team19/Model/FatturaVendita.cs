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

        private static FatturaVendita _ultimaFattura = new FatturaVendita(SoggettoFactory.CreateCliente(".", ".", ".", ".", ".", new Indirizzo("", "", "", "", "", "")), DateTime.MinValue, 1, new List<RigaFattura>());


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
            int retval = 1;

            if (_ultimaFattura.Data.Year == dataNuovaFattura.Year)
                retval = _ultimaFattura.NumeroFattura + 1;


            return retval;
        }
        public static FatturaVendita CreateFatturaVendita(Cliente cliente, DateTime data, List<RigaFattura> elencoProdotti)
        {

            FatturaVendita nuovaFattura = new FatturaVendita(cliente, data, NumeroProssimaFatturaDiVendita(data), elencoProdotti);
            _ultimaFattura = nuovaFattura;
            return nuovaFattura;

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
