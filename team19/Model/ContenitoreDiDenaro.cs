using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Team19.Model
{
    public abstract class ContenitoreDiDenaro : ISorgente, IDestinazione, IDisposable
    {
        private readonly Currency _saldoIniziale;
   
        private Currency _cacheSaldo;   //Cache
        
        public event EventHandler Changed;  //Evento per refresh cache

        public ContenitoreDiDenaro(Currency saldoIniziale)
        {
            _saldoIniziale = saldoIniziale;
            _cacheSaldo = null;
            Document.Changed += Document_Changed;
        }

        public abstract string Codice
        {
            get;
        }

        
        public Currency SaldoIniziale
        {
            get { return _saldoIniziale; }
        }

        /// <summary>
        /// Template method, ogni classe concreta che deriva da questa deve implementare Equals perchè il saldo funzioni correttamente
        /// </summary>
        public Currency Saldo
        {
            get 
            {
                if (_cacheSaldo != null)
                    return _cacheSaldo;

                Currency sum = SaldoIniziale;

                //Recupero gli importi dai movimenti in cui questo contenitore è la destinazione
                IEnumerable<Currency> queryImportiMovimentiConQuestoContenitore =
                    from movimento in Document.GetInstance().Movimenti
                    where this.Equals(movimento.Destinazione)
                    select movimento.Importo;

                foreach (Currency c in queryImportiMovimentiConQuestoContenitore)
                    sum += c;

                //Recupero gli importi dai movimenti in cui questo contenitore è la sorgente
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

        //metodo di cui fare l'override per il corretto funzioamento del saldo
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

        public override string ToString()
        {
            return "Contenitore di denaro";
        }

        
    }
}
