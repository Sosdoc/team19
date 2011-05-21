using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Team19.Model
{
    public static class MovimentoFactory
    {

        public static MovimentoDiDenaro CreatePagamentoAcquisto(ISorgente sorgente, FatturaAcquisto destinazione, DateTime data, Dipendente dipendente)
        {
            return new PagamentoAcquisto(sorgente,destinazione,data,dipendente);
        }

        public static MovimentoDiDenaro CreateIncassoVendita(FatturaVendita sorgente, IDestinazione destinazione, DateTime data, Dipendente dipendente)
        {
            return new IncassoVendita(sorgente,destinazione,data,dipendente);
        }

        public static MovimentoDiDenaro CreateMovimentoInterno(Cassa sorgente, DepositoDiDenaro destinazione, Currency importo, DateTime data, Dipendente dipendente)
        {
            return new Prelievo(sorgente, destinazione, importo, data, dipendente);
        }

        public static MovimentoDiDenaro CreateMovimentoInterno(DepositoDiDenaro sorgente, Cassa destinazione, Currency importo, DateTime data, Dipendente dipendente)
        {
            return new Versamento(sorgente, destinazione, importo, data, dipendente);
        }

        public static MovimentoDiDenaro CreateMovimentoInterno(DepositoDiDenaro sorgente, DepositoDiDenaro destinazione, Currency importo, DateTime data, Dipendente dipendente)
        {
            return new Spostamento(sorgente, destinazione, importo, data, dipendente);
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

        private abstract class MovimentoInterno : MovimentoDiDenaro
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
            public Prelievo(ISorgente sorgente, IDestinazione destinazione, Currency importo, DateTime data, Dipendente dipendente)
                : base(sorgente, destinazione, importo, data, dipendente)
            { }
        }

        private class Spostamento : MovimentoInterno
        {
             public Spostamento(ISorgente sorgente, IDestinazione destinazione, Currency importo, DateTime data, Dipendente dipendente)
                : base(sorgente, destinazione, importo, data, dipendente)
            { }  
        }

        private class Versamento : MovimentoInterno
        {
            public Versamento(ISorgente sorgente, IDestinazione destinazione, Currency importo, DateTime data, Dipendente dipendente)
                : base(sorgente, destinazione, importo, data, dipendente)
            { }
        }
    }
}
