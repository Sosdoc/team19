using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Team19.Model
{
    public static class MovimentoFactory
    {
        //I due metodi commentati possono essere implementati per rappresentare operazioni bancarie come interessi o spese, è possibile creare una sottoclasse di movimento 
        //oppure una delle sottoclassi concrete già esistenti per rappresentare i nuovi movimenti. Eventuali calcoli relativi all'interesse possono essere effettuati nella factory
        //e inseriti come importo del movimento creato.

        //public static MovimentoDiDenaro CreateInteresseBancario(DepositoDiDenaro deposito, double interesse, DateTime data, Dipendente dipendente, string causale)
        //{
        //    throw new NotImplementedException();
        //}

        //public static MovimentoDiDenaro CreateSpesaBancaria(DepositoDiDenaro deposito, Currency importo, DateTime data, Dipendente dipendente, string causale)
        //{
        //    throw new NotImplementedException();
        //}

        public static MovimentoDiDenaro CreatePagamentoAcquisto(ISorgente sorgente, IDestinazione destinazione, DateTime data, Dipendente dipendente, string causale)
        {
            return new PagamentoAcquisto(sorgente, destinazione, data, dipendente, causale);
        }

        public static MovimentoDiDenaro CreateIncassoVendita(FatturaVendita sorgente, IDestinazione destinazione, DateTime data, Dipendente dipendente, string causale)
        {
            return new IncassoVendita(sorgente, destinazione, data, dipendente, causale);
        }

        public static MovimentoDiDenaro CreateMovimentoInterno(DepositoDiDenaro sorgente, Cassa destinazione, Currency importo, DateTime data, Dipendente dipendente, string causale)
        {
            return new Prelievo(sorgente, destinazione, importo, data, dipendente, causale);
        }

        public static MovimentoDiDenaro CreateMovimentoInterno(Cassa sorgente, DepositoDiDenaro destinazione, Currency importo, DateTime data, Dipendente dipendente, string causale)
        {
            return new Versamento(sorgente, destinazione, importo, data, dipendente, causale);
        }

        public static MovimentoDiDenaro CreateMovimentoInterno(DepositoDiDenaro sorgente, DepositoDiDenaro destinazione, Currency importo, DateTime data, Dipendente dipendente, string causale)
        {
            return new Spostamento(sorgente, destinazione, importo, data, dipendente, causale);
        }

        private class PagamentoAcquisto : MovimentoDiDenaro
        {

            public PagamentoAcquisto(ISorgente sorgente, IDestinazione destinazione, DateTime data, Dipendente dipendente, string causale)
                : base(sorgente, destinazione, data, dipendente, causale)
            {
                if (sorgente is Cassa && Importo.Value > ((Cassa)sorgente).Saldo.Value)
                    throw new ArgumentException("Saldo disponibile minore del necessario");
            }

            public override Currency Importo
            {
                get { return ((FatturaAcquisto)Destinazione).Importo; }
            }

        }

        private class IncassoVendita : MovimentoDiDenaro
        {

            public IncassoVendita(ISorgente sorgente, IDestinazione destinazione, DateTime data, Dipendente dipendente, string causale)
                : base(sorgente, destinazione, data, dipendente, causale)
            {

            }

            public override Currency Importo
            {
                get { return ((FatturaVendita)Sorgente).Importo; }
            }

        }

        private abstract class MovimentoInterno : MovimentoDiDenaro
        {
            private Currency _importo;

            public MovimentoInterno(ISorgente sorgente, IDestinazione destinazione, Currency importo, DateTime data, Dipendente dipendente, string causale)
                : base(sorgente, destinazione, data, dipendente, causale)
            {
                if (sorgente is Cassa && importo.Value > ((Cassa)sorgente).Saldo.Value)
                    throw new ArgumentException("Saldo disponibile minore del necessario");
                _importo = importo;
            }

            public override Currency Importo
            {
                get { return _importo; }
            }
        }

        private class Prelievo : MovimentoInterno
        {
            public Prelievo(ISorgente sorgente, IDestinazione destinazione, Currency importo, DateTime data, Dipendente dipendente, string causale)
                : base(sorgente, destinazione, importo, data, dipendente, causale)
            { }
        }

        private class Spostamento : MovimentoInterno
        {
            public Spostamento(ISorgente sorgente, IDestinazione destinazione, Currency importo, DateTime data, Dipendente dipendente, string causale)
                : base(sorgente, destinazione, importo, data, dipendente, causale)
            { }
        }

        private class Versamento : MovimentoInterno
        {
            public Versamento(ISorgente sorgente, IDestinazione destinazione, Currency importo, DateTime data, Dipendente dipendente, string causale)
                : base(sorgente, destinazione, importo, data, dipendente, causale)
            { }
        }
    }
}
