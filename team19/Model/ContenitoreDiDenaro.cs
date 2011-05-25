using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    public abstract class ContenitoreDiDenaro : ISorgente, IDestinazione, IDisposable
    {
        private readonly Currency _saldoIniziale;
        //Cache
        private Currency _cacheSaldo;
        //Evento per refresh cache
        public event EventHandler Changed;

        public ContenitoreDiDenaro(Currency saldoIniziale)
        {
            _saldoIniziale = saldoIniziale;
            _cacheSaldo = null;
            Document.Changed += Document_Changed;
        }

        public string Tipo
        {
            get { return this.GetType().Name; }
        }

        public virtual string CodConto
        {
            get { return ""; }
        }

        public Currency SaldoIniziale
        {
            get { return _saldoIniziale; }
        }

        public Currency Saldo
        {
            get //template method, ogni classe concreta deve implementare Equals
            {
                if (_cacheSaldo != null)
                    return _cacheSaldo;

                Currency sum = SaldoIniziale;

                IEnumerable<Currency> queryImportiMovimentiConQuestoContenitore =
                    from movimento in Document.GetInstance().Movimenti
                    where this.Equals(movimento.Destinazione)
                    select movimento.Importo;

                foreach (Currency c in queryImportiMovimentiConQuestoContenitore)
                    sum += c;

                queryImportiMovimentiConQuestoContenitore =
                      from movimento in Document.GetInstance().Movimenti
                      where this.Equals(movimento.Sorgente)
                      select movimento.Importo;

                foreach (Currency c in queryImportiMovimentiConQuestoContenitore)
                    sum -= c;

                _cacheSaldo = sum;
                return sum;
            }
        }

        protected virtual void Document_Changed(object sender, EventArgs args)
        {
            OnChanged();
        }

        private void OnChanged()
        {
            _cacheSaldo = null;
            if (Changed != null)
                Changed(this, EventArgs.Empty);
        }


        public abstract override bool Equals(object obj);

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #region IDisposable members
        public void Dispose()
        {
            Document.Changed -= Document_Changed;
        }
        #endregion

    }
}
