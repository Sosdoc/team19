using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    interface IRiepilogo
    {
        List<Currency> GetImportiPagati();
        List<Currency> GetImportiDaPagare();
        
    }

    public class RiepilogoCliente : IRiepilogo
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
