using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    public class Cassa : ContenitoreDiDenaro
    {
        public Cassa(Currency saldoIniziale):base(saldoIniziale)
        {
            
        }
        public override Currency Saldo
        {
            //dovrà calcolare il saldo in base ai movimenti
            get
            {
                Currency sum = SaldoIniziale;
                IEnumerable<Currency> queryImportiMovimentiConCassa =
                     from movimento in Document.GetInstance().Movimenti
                     where (movimento.Sorgente.GetType().Equals(this.GetType()))
                     select movimento.Importo;
             
                

                foreach (Currency c in queryImportiMovimentiConCassa)
                    sum -= c;

                queryImportiMovimentiConCassa =
                     from movimento in Document.GetInstance().Movimenti
                     where (movimento.Destinazione.GetType().Equals(this.GetType()))
                     select movimento.Importo;

                foreach (Currency c in queryImportiMovimentiConCassa)
                    sum += c;

                return sum;
            }
        }
    }
}
