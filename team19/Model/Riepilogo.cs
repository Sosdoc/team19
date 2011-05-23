using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    interface IRiepilogo
    {
        IEnumerable<Currency> GetImportiPagati();
        IEnumerable<Currency> GetImportiDaPagare();
    }

    public class RiepilogoCliente : IRiepilogo
    {
        #region IRiepilogo Members

        private Cliente _cliente;

        public Cliente Cliente
        {
            get { return _cliente; }
        }

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

    public class RiepilogoFornitore : IRiepilogo
    {
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
