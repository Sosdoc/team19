using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    public class Cassa : ContenitoreDiDenaro
    {
        public Cassa(Currency saldoIniziale)
            : base(saldoIniziale)
        { }

        public override bool Equals(object obj)
        {
            return this.GetType().Equals(obj.GetType()); //la cassa è unica, basta controllare che il tipo sia lo stesso
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "Cassa";
        }

        public override string Codice
        {
            get { return "Cassa"; }
        }

    }
}
