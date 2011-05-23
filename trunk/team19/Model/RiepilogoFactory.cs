using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    class RiepilogoFactory
    {
        static IRiepilogo CreateRiepilogo(Cliente cliente)
        {
            return new RiepilogoCliente(cliente);
        }

        static IRiepilogo CreateRiepilogo(Fornitore fornitore)
        {
            return new RiepilogoFornitore(fornitore);
        }

        //static IRiepilogo CreateRiepilogo(Soggetto soggetto)
        //{
        
        //}

        private class RiepilogoCliente : IRiepilogo
        {
            private Cliente _cliente;

            public RiepilogoCliente(Cliente cliente)
            {
                _cliente = cliente;
            }

            public Cliente Cliente
            {
                get { return _cliente; }
            }

            #region IRiepilogo Members

            public List<Currency> GetImportiPagati()
            {
                throw new NotImplementedException();
            }

            public List<Currency> GetImportiDaPagare()
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        private class RiepilogoFornitore : IRiepilogo
        {
            private Fornitore _fornitore;

            public RiepilogoFornitore(Fornitore fornitore)
            {
                _fornitore = fornitore;
            }

            public Fornitore Fornitore
            {
                get { return _fornitore; }
            }

            #region IRiepilogo Members

            public List<Currency> GetImportiPagati()
            {
                throw new NotImplementedException();
            }

            public List<Currency> GetImportiDaPagare()
            {
                throw new NotImplementedException();
            }

            #endregion
        }
    }
}
