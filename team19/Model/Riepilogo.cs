using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace Team19.Model
{
    interface IRiepilogo
    {
        Dictionary<int, Currency> GetImportiPagati();
        Dictionary<int, Currency> GetImportiDaPagare();
    }
    public class RiepilogoCliente : IRiepilogo
    {
        private ICliente _cliente;

        public RiepilogoCliente(ICliente cliente)
        {
            _cliente = cliente;
        }

        public ICliente Cliente
        {
            get { return _cliente; }
        }

        #region IRiepilogo Members

        private IEnumerable<FatturaVendita> GetFatturePagate()
        {
            IEnumerable<FatturaVendita> fatture =
                from fattura in Document.GetInstance().GetFattureVendita()
                join movimento in Document.GetInstance().GetIncassiVendite() on fattura equals (FatturaVendita)movimento.Sorgente
                where fattura.Cliente.Equals(Cliente)
                select fattura;
            return fatture;
        }
        public Dictionary<int, Currency> GetImportiPagati()
        {

            IEnumerable<FatturaVendita> fatture =
               from fattura in Document.GetInstance().GetFattureVendita()
               join movimento in Document.GetInstance().GetIncassiVendite() on fattura equals (FatturaVendita)movimento.Sorgente
               where fattura.Cliente.Equals(Cliente)
               select fattura;
            Dictionary<int, Currency> result = new Dictionary<int, Currency>();
            foreach (FatturaVendita fattura in fatture)
                result.Add(fattura.NumeroFattura, fattura.Importo);
            return result;
        }

        public Dictionary<int, Currency> GetImportiDaPagare()
        {



            IEnumerable<FatturaVendita> fatture =
              from fattura in Document.GetInstance().GetFattureVendita()
              join movimento in Document.GetInstance().GetIncassiVendite() on fattura equals (FatturaVendita)movimento.Sorgente into temp
              from fatturaNonPagata in temp.DefaultIfEmpty()
              where fattura.Cliente.Equals(Cliente)
              select fattura;
            Dictionary<int, Currency> result = new Dictionary<int, Currency>();
            foreach (FatturaVendita fattura in fatture)
                result.Add(fattura.NumeroFattura, fattura.Importo);
            return result;
        }

        #endregion
    }

    public class RiepilogoFornitore : IRiepilogo
    {
        private IFornitore _fornitore;

        public RiepilogoFornitore(IFornitore fornitore)
        {
            this._fornitore = fornitore;



        }

        IFornitore Fornitore
        {
            get { return _fornitore; }
        }

        #region IRiepilogo Members

        public Dictionary<int, Currency> GetImportiPagati()
        {
            IEnumerable<FatturaAcquisto> fatture =
               from fattura in Document.GetInstance().GetFattureAcquisto()
               join movimento in Document.GetInstance().GetPagamentiAcquisti() on fattura equals (FatturaAcquisto)movimento.Destinazione
               where fattura.Fornitore.Equals(Fornitore)
               select fattura;
            Dictionary<int, Currency> result = new Dictionary<int, Currency>();
            foreach (FatturaAcquisto fattura in fatture)
                result.Add(fattura.NumeroFattura, fattura.Importo);
            return result;
        }

        public Dictionary<int, Currency> GetImportiDaPagare()
        {
            IEnumerable<FatturaAcquisto> fatture =
              from fattura in Document.GetInstance().GetFattureAcquisto()
              join movimento in Document.GetInstance().GetPagamentiAcquisti() on fattura equals (FatturaAcquisto)movimento.Destinazione into temp
              from fatturaNonPagata in temp.DefaultIfEmpty()
              where fattura.Fornitore.Equals(Fornitore)
              select fattura;
            Dictionary<int, Currency> result = new Dictionary<int, Currency>();
            foreach (FatturaAcquisto fattura in fatture)
                result.Add(fattura.NumeroFattura, fattura.Importo);
            return result;
        }

        #endregion
    }

}
