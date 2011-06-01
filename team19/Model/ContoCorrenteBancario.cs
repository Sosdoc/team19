using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    public class ContoCorrenteBancario : DepositoDiDenaro
    {
        private string _codConto;

        public override string Codice
        {
            get { return _codConto; }
        }

        public ContoCorrenteBancario(string codiceConto, Currency saldoIniziale)
            : base(saldoIniziale)
        {
            _codConto = codiceConto;
        }
        
        public override bool Equals(object obj)
        {
            if (this.GetType().Equals(obj.GetType())) //se il tipo è uguale
                return this.Codice.Equals(((ContoCorrenteBancario)obj).Codice); //se ha lo stesso codice conto
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return "CCB: " + Codice;
        }
    }
}
