using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    public class Cassa : ContenitoreDiDenaro
    {
        public override Currency Saldo
        {
            //dovrà calcolare il saldo in base ai movimenti
            get
            {
                IEnumerable<Currency> queryImportiMovimentiConCassa =
                     from movimento in Document.GetInstance().Movimenti
                     where (movimento.Sorgente.GetType().Equals(this.GetType()) || movimento.Destinazione.GetType().Equals(this.GetType()))
                     select movimento.Importo;
             
                Currency sum = new Currency(0);

                foreach (Currency c in queryImportiMovimentiConCassa)
                    sum += c;

                return sum;
            }
        }
    }
}
