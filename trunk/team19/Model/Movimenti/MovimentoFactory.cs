using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model.Movimenti
{
    public static class MovimentoFactory
    {

        public static MovimentoDiDenaro CreatePagamentoAcquisto(ISorgente sorgente, IDestinazione destinazione, DateTime data, Dipendente dipendente)
        {
            if(!(destinazione is FatturaAcquisto))
            {
                throw new ArgumentException("La destinazione non è una fattura di acquisto");
            }
            return new PagamentoAcquisto(sorgente,destinazione,data,dipendente);
        }

        public static MovimentoDiDenaro CreateIncassoVendita(ISorgente sorgente, IDestinazione destinazione, DateTime data, Dipendente dipendente)
        {
            if(!(destinazione is FatturaVendita))
            {
                throw new ArgumentException("La sorgente non è una fattura di vendita");
            }
            return new IncassoVendita(sorgente,destinazione,data,dipendente);
        }

        public static MovimentoDiDenaro CreateMovimentoInterno(ISorgente sorgente, IDestinazione destinazione, Currency importo, DateTime data, Dipendente dipendente)
        {
            if (destinazione.Equals(sorgente))
                throw new ArgumentException("Sorgente e destinazione non possono coincidere");

        }

        private class PagamentoAcquisto : MovimentoDiDenaro
        {
            
            public PagamentoAcquisto(ISorgente sorgente, IDestinazione destinazione, DateTime data, Dipendente dipendente):base(sorgente,destinazione,data,dipendente)
            {
            }

            public override Currency Importo
            {
                get { return ((FatturaAcquisto) Destinazione).Importo; }
            }

        //    public override string ToString()
        //    {
        ////        return _data + ") " + _importo + ",da " + _sorgente.getInfo() + " a " + _destinazione.getInfo() + ", registrato da " + _dipendente.ToString() + " " + _dataRegistrazione;
        //    }
        }

        private class IncassoVendita : MovimentoDiDenaro
        {

            public IncassoVendita(ISorgente sorgente, IDestinazione destinazione, DateTime data, Dipendente dipendente):base(sorgente,destinazione,data,dipendente)
            {
                
            }
            public override Currency Importo
            {
                get { return ((FatturaAcquisto) Sorgente).Importo; }
            }


        }

        private class MovimentoInterno : MovimentoDiDenaro
        {
            private Currency _importo;

            public MovimentoInterno(ISorgente sorgente, IDestinazione destinazione, Currency importo, DateTime data, Dipendente dipendente)
                : base(sorgente, destinazione, data, dipendente)
            {
                _importo = importo;
            }

            public override Currency Importo
            {
                get { return _importo; }
            }
        }

        private class Prelievo : MovimentoInterno
        {
            
        }

        private class Spostamento : MovimentoInterno
        {
               
        }

        private class Versamento : MovimentoInterno
        {
               
        }
    }
}
