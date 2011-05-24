using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    public abstract class DepositoDiDenaro : ContenitoreDiDenaro
    {
        public DepositoDiDenaro(Currency saldoIniziale)
            : base(saldoIniziale)
        { }

        public override bool Equals(object obj)
        {
            return (this.GetType().Equals(obj.GetType()));
                
        }
    }
}
