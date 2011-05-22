using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    public class AltroDepositoDiDenaro : DepositoDiDenaro
    {
        public override Currency Saldo
        {
            //dovrà calcolare il saldo in base ai movimenti
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
