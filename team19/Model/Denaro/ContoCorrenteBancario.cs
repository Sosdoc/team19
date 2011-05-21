using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    public class ContoCorrenteBancario : DepositoDiDenaro
    {
        private String _codConto;

        public String CodConto
        {
            get { return _codConto; }
        }

        public ContoCorrenteBancario(String codiceConto)
        {
            _codConto = codiceConto;
        }

        public override Currency Saldo
        {
            //dovrà calcolare il saldo in base ai movimenti
            get { throw new NotImplementedException(); }
        }
    }
}
