using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    public class AltroDepositoDiDenaro : DepositoDiDenaro
    {
        public AltroDepositoDiDenaro(Currency saldoIniziale)
            : base(saldoIniziale)
        { }

        public override bool Equals(object obj)
        {
            if (this.GetType().Equals(obj.GetType())) //se il tipo è uguale
                return Object.ReferenceEquals(this, obj); //se è lo stesso riferimento --- Magari è meglio cambiarlo
            return false;
        }
    }
}
