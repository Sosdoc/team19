using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Team19.Model.Soggetti;
namespace Team19.Model.Fatture
{
    public class FatturaVendita : Fattura, ISorgente
    {
        private List<RigaFattura> _elencoProdotti;
        private Cliente _cliente;
        public override Currency Importo
        {
            get
            {
                double sum = 0;
                foreach (RigaFattura riga in _elencoProdotti)
                {
                    sum += riga.Quantità * riga.PrezzoUnitario.Value;
                }
                return new Currency(sum);
            }
        }

        public FatturaVendita(Cliente cliente, DateTime data, int numero, List<RigaFattura> elencoProdotti)
            : base(data, numero)
        {
            //nota -- le fatture di vendita devono prendere il numero progressivo da qualche parte: da dove?
            this._elencoProdotti = elencoProdotti;
            this._cliente = cliente;
        }
    }
}
