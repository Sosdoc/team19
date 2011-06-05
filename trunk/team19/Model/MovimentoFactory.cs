using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Team19.Model
{
    public static class MovimentoFactory
    {
        public static MovimentoDiDenaro CreateInteresseBancario(DepositoDiDenaro deposito, double interesse, DateTime data, Dipendente dipendente, string causale)
        {
            throw new NotImplementedException();
        }
        public static MovimentoDiDenaro CreateSpesaBancaria(DepositoDiDenaro deposito, Currency importo, DateTime data, Dipendente dipendente, string causale)
        {
            throw new NotImplementedException();
        }

        public static MovimentoDiDenaro CreatePagamentoAcquisto(ISorgente sorgente, IDestinazione destinazione, DateTime data, Dipendente dipendente, string causale)
        {
            return new PagamentoAcquisto(sorgente, destinazione, data, dipendente, causale);
        }

        [MetodoCreazione("PagamentoAcquisto", new Type[] { typeof(ComboBox), typeof(ComboBox), typeof(DateTimePicker), typeof(TextBox) })]
        public static MovimentoDiDenaro CreatePagamentoAcquisto(ContenitoreDiDenaro sorgente, FatturaAcquisto destinazione, DateTime data, string causale)
        {
            return new PagamentoAcquisto(sorgente, destinazione, data, Document.GetInstance().UtenteConnesso, causale);
        }

        public static MovimentoDiDenaro CreateIncassoVendita(FatturaVendita sorgente, IDestinazione destinazione, DateTime data, Dipendente dipendente, string causale)
        {
            return new IncassoVendita(sorgente, destinazione, data, dipendente, causale);
        }

        [MetodoCreazione("IncassoVendita", new Type[] { typeof(ComboBox), typeof(ComboBox), typeof(DateTimePicker), typeof(TextBox) })]
        public static MovimentoDiDenaro CreateIncassoVendita(FatturaVendita sorgente, ContenitoreDiDenaro destinazione, DateTime data, string causale)
        {
            return new IncassoVendita(sorgente, destinazione, data, Document.GetInstance().UtenteConnesso, causale);
        }

        public static MovimentoDiDenaro CreateMovimentoInterno(DepositoDiDenaro sorgente,Cassa destinazione, Currency importo, DateTime data, Dipendente dipendente, string causale)
        {
            return new Prelievo(sorgente, destinazione, importo, data, dipendente, causale);
        }

        [MetodoCreazione("Prelievo", new Type[] { typeof(ComboBox), typeof(Label), typeof(TextBox), typeof(DateTimePicker), typeof(TextBox) })]
        public static MovimentoDiDenaro CreateMovimentoInterno(DepositoDiDenaro sorgente, Cassa destinazione, Currency importo, DateTime data, string causale)
        {
            return new Prelievo(sorgente, destinazione, importo, data, Document.GetInstance().UtenteConnesso, causale);
        }

        public static MovimentoDiDenaro CreateMovimentoInterno(Cassa sorgente,DepositoDiDenaro  destinazione, Currency importo, DateTime data, Dipendente dipendente, string causale)
        {
            return new Versamento(sorgente, destinazione, importo, data, dipendente, causale);
        }

        [MetodoCreazione("Versamento", new Type[] {  typeof(Label), typeof(ComboBox), typeof(TextBox), typeof(DateTimePicker), typeof(TextBox) })]
        public static MovimentoDiDenaro CreateMovimentoInterno(Cassa sorgente,DepositoDiDenaro destinazione, Currency importo, DateTime data, string causale)
        {
            return new Versamento(sorgente, destinazione, importo, data, Document.GetInstance().UtenteConnesso, causale);
        }

        public static MovimentoDiDenaro CreateMovimentoInterno(DepositoDiDenaro sorgente, DepositoDiDenaro destinazione, Currency importo, DateTime data, Dipendente dipendente, string causale)
        {
            return new Spostamento(sorgente, destinazione, importo, data, dipendente, causale);
        }

        [MetodoCreazione("Spostamento",new Type[]{typeof(ComboBox),typeof(ComboBox),typeof(TextBox),typeof(DateTimePicker),typeof(TextBox)})]
        public static MovimentoDiDenaro CreateMovimentoInterno(DepositoDiDenaro sorgente, DepositoDiDenaro destinazione, Currency importo, DateTime data, string causale)
        {
            return new Spostamento(sorgente, destinazione, importo, data, Document.GetInstance().UtenteConnesso, causale);
        }

        private class PagamentoAcquisto : MovimentoDiDenaro
        {

            public PagamentoAcquisto(ISorgente sorgente, IDestinazione destinazione, DateTime data, Dipendente dipendente, string causale)
                : base(sorgente, destinazione, data, dipendente, causale)
            {

            }

            [ControlloAssociato(typeof(TextBox))]
            public override Currency Importo
            {
                get { return ((FatturaAcquisto)Destinazione).Importo; }
            }

            [ControlloAssociato(typeof(ComboBox), typeof(IList<FatturaAcquisto>))]
            public override IDestinazione Destinazione
            {
                get
                {
                    return base.Destinazione;
                }
            }

            [ControlloAssociato(typeof(ComboBox), typeof(IList<ContenitoreDiDenaro>))]
            public override ISorgente Sorgente
            {
                get
                {
                    return base.Sorgente;
                }
            }
            //    public override string ToString()
            //    {
            ////        return _data + ") " + _importo + ",da " + _sorgente.getInfo() + " a " + _destinazione.getInfo() + ", registrato da " + _dipendente.ToString() + " " + _dataRegistrazione;
            //    }
        }

        private class IncassoVendita : MovimentoDiDenaro
        {

            public IncassoVendita(ISorgente sorgente, IDestinazione destinazione, DateTime data, Dipendente dipendente, string causale)
                : base(sorgente, destinazione, data, dipendente, causale)
            {

            }
            [ControlloAssociato(typeof(TextBox))]
            public override Currency Importo
            {
                get { return ((FatturaVendita)Sorgente).Importo; }
            }

            [ControlloAssociato(typeof(ComboBox), typeof(IList<FatturaVendita>))]
            public override ISorgente Sorgente
            {
                get
                {
                    return base.Sorgente;
                }
            }
            [ControlloAssociato(typeof(ComboBox), typeof(IList<ContenitoreDiDenaro>))]
            public override IDestinazione Destinazione
            {
                get
                {
                    return base.Destinazione;
                }
            }
        }

        private abstract class MovimentoInterno : MovimentoDiDenaro
        {
            private Currency _importo;

            public MovimentoInterno(ISorgente sorgente, IDestinazione destinazione, Currency importo, DateTime data, Dipendente dipendente, string causale)
                : base(sorgente, destinazione, data, dipendente, causale)
            {
                _importo = importo;
            }

            [ControlloAssociato(typeof(TextBox))]
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

            [ControlloAssociato(typeof(ComboBox), typeof(IList<DepositoDiDenaro>))]
            public override ISorgente Sorgente
            {
                get
                {
                    return base.Sorgente;
                }
            }

             [ControlloAssociato(typeof(Label), typeof(Cassa))]
            public override IDestinazione Destinazione
            {
                get
                {
                    return base.Destinazione;
                }
            }
        }

        private class Spostamento : MovimentoInterno
        {
            public Spostamento(ISorgente sorgente, IDestinazione destinazione, Currency importo, DateTime data, Dipendente dipendente, string causale)
                : base(sorgente, destinazione, importo, data, dipendente, causale)
            { }

             [ControlloAssociato(typeof(ComboBox), typeof(IList<DepositoDiDenaro>))]
            public override ISorgente Sorgente
            {
                get
                {
                    return base.Sorgente;
                }
            }

            [ControlloAssociato(typeof(ComboBox), typeof(IList<DepositoDiDenaro>))]
             public override IDestinazione Destinazione
             {
                 get
                 {
                     return base.Destinazione;
                 }
             }
        }

        private class Versamento : MovimentoInterno
        {
            public Versamento(ISorgente sorgente, IDestinazione destinazione, Currency importo, DateTime data, Dipendente dipendente, string causale)
                : base(sorgente, destinazione, importo, data, dipendente, causale)
            { }

            [ControlloAssociato(typeof(Label), typeof(Cassa))]
            public override ISorgente Sorgente
            {
                get
                {
                    return base.Sorgente;
                }
            }

            [ControlloAssociato(typeof(ComboBox), typeof(IList<DepositoDiDenaro>))]
            public override IDestinazione Destinazione
            {
                get
                {
                    return base.Destinazione;
                }
            }
        }
    }
}
