using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    abstract class MovimentoDiDenaro
    {
        private DateTime _data;

        private ISorgente _sorgente;
        private IDestinazione _destinazione;
        private Dipendente _dipendente;
        private DateTime _dataRegistrazione;

        
        public DateTime Data
        {
            get { return _data; }
        }

        public abstract Currency Importo
        {
            get;
        }

        public abstract ISorgente Sorgente
        {
            get;
        }

        public abstract IDestinazione Destinazione
        {
            get;
        }

        public Dipendente Dipendente
        {
            get { return _dipendente; }
        }

        public DateTime DataRegistrazione
        {
            get { return _dataRegistrazione; }
        }

        public static MovimentoDiDenaro creaMovimento(DateTime data, Currency importo, ISorgente sorgente, IDestinazione destinazione, Dipendente dipendente)
        {
            return new PagamentoAcquisto(data, importo, sorgente, destinazione, dipendente);
        }

        private class PagamentoAcquisto : MovimentoDiDenaro
        {
            public PagamentoAcquisto(DateTime data, Currency importo, ISorgente sorgente, IDestinazione destinazione, Dipendente dipendente)
            {
                base._data = data;
                base._importo = importo;
                base._sorgente = sorgente;
                base._destinazione = destinazione;
                base._dipendente = dipendente;
                base._dataRegistrazione = DateTime.Now;
            }

            public override Currency Importo
            {
                get { throw new NotImplementedException(); }
            }

            public override ISorgente Sorgente
            {
                get { return base._sorgente; }
            }

            public override IDestinazione Destinazione
            {
                get { return base._destinazione; }
            }

            public override string ToString()
            {
                return _data + ") " + _importo + ",da " + _sorgente.getInfo() + " a " + _destinazione.getInfo() + ", registrato da " + _dipendente.ToString() + " " + _dataRegistrazione;
            }
        }

        private class IncassoVendita : MovimentoDiDenaro
        {

            public override Currency Importo
            {
                get { throw new NotImplementedException(); }
            }

            public override ISorgente Sorgente
            {
                get { return base._sorgente; }
            }

            public override IDestinazione Destinazione
            {
                get { return base._destinazione; }
            }

        }
        private abstract class MovimentoInterno : MovimentoDiDenaro
        {
            private Currency _importo;

            public override Currency Importo
            {
                get { return _importo; }
            }

            public abstract ISorgente Sorgente
            {
                get;
            }

            public abstract IDestinazione Destinazione
            {
                get;
            }

            public MovimentoInterno creaMovimentoInterno(ISorgente sorgente, IDestinazione destinazione)
            {
                throw new NotImplementedException();
            }


            private class Prelievo : MovimentoInterno
            {
                public override ISorgente Sorgente
                {
                    get { throw new NotImplementedException(); }
                }

                public override IDestinazione Destinazione
                {
                    get { throw new NotImplementedException(); }
                }
            }

            private class Spostamento : MovimentoInterno
            {
                public override ISorgente Sorgente
                {
                    get { throw new NotImplementedException(); }
                }

                public override IDestinazione Destinazione
                {
                    get { throw new NotImplementedException(); }
                }
            }

            private class Versamento : MovimentoInterno
            {
                public override ISorgente Sorgente
                {
                    get { throw new NotImplementedException(); }
                }

                public override IDestinazione Destinazione
                {
                    get { throw new NotImplementedException(); }
                }
            }

        }
    }
}