using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    class RiepilogoFactory
    {
        public static IRiepilogo CreateRiepilogo(Cliente cliente)
        {
            return new RiepilogoCliente(cliente);
        }

        public static IRiepilogo CreateRiepilogo(Fornitore fornitore)
        {
            return new RiepilogoFornitore(fornitore);
        }

        public abstract class Riepilogo : IRiepilogo
        {

            public Dictionary<int, Currency> GetImportiPagati()
            {
                Dictionary<int, Currency> result = new Dictionary<int, Currency>();
                foreach (Fattura fattura in this.FatturePagate)
                    result.Add(fattura.NumeroFattura, fattura.Importo);
                return result;
            }

            public Dictionary<int, Currency> GetImportiDaPagare()
            {
                Dictionary<int, Currency> result = new Dictionary<int, Currency>();
                foreach (Fattura fattura in this.FattureDaPagare)
                    result.Add(fattura.NumeroFattura, fattura.Importo);
                return result;
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
            private Cliente _cliente;

            public RiepilogoCliente(Cliente cliente)
            {
                _cliente = cliente;
            }

            public Cliente Cliente
            {
                get { return _cliente; }
            }

            #region Riepilogo Members
            protected override IEnumerable<Fattura> FatturePagate
            {
                get
                {
                    IEnumerable<FatturaVendita> fatture =
                        from fattura in Document.GetInstance().GetFattureVendita()
                        join movimento in Document.GetInstance().GetIncassiVendite() on fattura equals (FatturaVendita)movimento.Sorgente
                        where fattura.Cliente.Equals(Cliente)
                        select fattura;
                    return fatture;
                }
            }
            protected override IEnumerable<Fattura> FattureDaPagare
            {
                get
                {
                    return Document.GetInstance().Fatture.OfType<FatturaVendita>().Except(this.FatturePagate);
                }
            }
            #endregion
        }

        private class RiepilogoFornitore : Riepilogo
        {
            private Fornitore _fornitore;

            public RiepilogoFornitore(Fornitore fornitore)
            {
                this._fornitore = fornitore;
            }

            public Fornitore Fornitore
            {
                get { return _fornitore; }
            }

            #region Riepilogo Members

            protected override IEnumerable<Fattura> FatturePagate
            {
                get
                {
                    IEnumerable<FatturaAcquisto> fatture =
                        from fattura in Document.GetInstance().GetFattureAcquisto()
                        join movimento in Document.GetInstance().GetPagamentiAcquisti() on fattura equals (FatturaAcquisto)movimento.Destinazione
                        where fattura.Fornitore.Equals(Fornitore)
                        select fattura;
                    return fatture;
                }
            }
            protected override IEnumerable<Fattura> FattureDaPagare
            {
                get
                {
                    return Document.GetInstance().Fatture.OfType<FatturaAcquisto>().Except(this.FatturePagate);
                }
            }

            #endregion
        }
    }
}
