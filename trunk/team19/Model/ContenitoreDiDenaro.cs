using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    public abstract class ContenitoreDiDenaro : ISorgente, IDestinazione
    {
        private readonly Currency _saldoIniziale;

        public ContenitoreDiDenaro(Currency saldoIniziale)
        {
            _saldoIniziale = saldoIniziale;
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

                return sum;
            }
        }
        
        public abstract override bool Equals(object obj);
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
