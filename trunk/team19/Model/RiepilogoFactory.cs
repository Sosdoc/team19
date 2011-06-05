using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    class RiepilogoFactory
    {
        private static Dictionary<Type, Riepilogo> _riepiloghi;
        static RiepilogoFactory()
        {
            _riepiloghi = new Dictionary<Type, Riepilogo>();
            _riepiloghi.Add(typeof(Cliente), new RiepilogoCliente(null));
            _riepiloghi.Add(typeof(Fornitore), new RiepilogoFornitore(null));
        }
        public static IRiepilogo CreateRiepilogo(Soggetto soggetto)
        {
            Riepilogo result = _riepiloghi[soggetto.GetType()];
            result.Soggetto = soggetto;
            return result;
        }
        //public static IRiepilogo CreateRiepilogo(Cliente cliente)
        //{
        //    return new RiepilogoCliente(cliente);
        //}

        //public static IRiepilogo CreateRiepilogo(Fornitore fornitore)
        //{
        //    return new RiepilogoFornitore(fornitore);
        //}

        public abstract class Riepilogo : IRiepilogo
        {
            private Soggetto _soggetto;


            protected Riepilogo(Soggetto soggetto)
            {
                _soggetto = soggetto;
            }

            public IEnumerable<Fattura> GetImportiPagati()
            {
                IList<Fattura> result = new List<Fattura>();
                foreach (Fattura fattura in this.FatturePagate)
                    result.Add(fattura);
                return result;
            }

            public IEnumerable<Fattura> GetImportiDaPagare()
            {
                IList<Fattura> result = new List<Fattura>();
                foreach (Fattura fattura in this.FattureDaPagare)
                    result.Add(fattura);
                return result;
            }
            public Soggetto Soggetto
            {
                get { return _soggetto; }
                set { _soggetto = value; }
            }
            protected abstract IEnumerable<Fattura> FatturePagate
            {
                get;
            }
            protected abstract IEnumerable<Fattura> FattureDaPagare
            {
                get;
            }
        }

        private class RiepilogoCliente : Riepilogo
        {

            public RiepilogoCliente(Soggetto cliente)
                : base(cliente)
            {
            }

            //public Cliente Cliente
            //{
            //    get { return _cliente; }
            //}

            #region Riepilogo Members
            protected override IEnumerable<Fattura> FatturePagate
            {
                get
                {
                    IEnumerable<FatturaVendita> fatture =
                        from fattura in Document.GetInstance().Fatture.OfType<FatturaVendita>()
                        join movimento in Document.GetInstance().GetIncassiVendite() on fattura equals (FatturaVendita)movimento.Sorgente
                        where fattura.Cliente.Equals(Soggetto)
                        select fattura;
                    return fatture;
                }
            }
            protected override IEnumerable<Fattura> FattureDaPagare
            {
                get
                {
                    IEnumerable<FatturaVendita> fatture= Document.GetInstance().Fatture.OfType<FatturaVendita>().Where(fattura=>fattura.Cliente.Equals(Soggetto));
                    return fatture.Except(FatturePagate);
                }
            }
            #endregion
        }

        private class RiepilogoFornitore : Riepilogo
        {

            public RiepilogoFornitore(Soggetto fornitore)
                : base(fornitore)
            {
            }

            //public Fornitore Fornitore
            //{
            //    get { return _fornitore; }
            //}

            #region Riepilogo Members

            protected override IEnumerable<Fattura> FatturePagate
            {
                get
                {
                    IEnumerable<FatturaAcquisto> fatture =
                        from fattura in Document.GetInstance().Fatture.OfType<FatturaAcquisto>()
                        join movimento in Document.GetInstance().GetPagamentiAcquisti() on fattura equals (FatturaAcquisto)movimento.Destinazione
                        where fattura.Fornitore.Equals(Soggetto)
                        select fattura;
                    return fatture;
                }
            }
            protected override IEnumerable<Fattura> FattureDaPagare
            {
                get
                {
                    IEnumerable<FatturaAcquisto> fatture = Document.GetInstance().Fatture.OfType<FatturaAcquisto>().Where(fattura=>fattura.Fornitore.Equals(Soggetto));
                    return fatture.Except(FatturePagate);
                }
            }

            #endregion
        }
    }
}
