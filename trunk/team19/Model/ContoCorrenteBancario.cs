﻿using System;
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

        public ContoCorrenteBancario(String codiceConto, Currency saldoIniziale)
            : base(saldoIniziale)
        {
            _codConto = codiceConto;
        }

        //public override Currency Saldo
        //{
        //    get { throw new NotImplementedException(); }
        //}

        public override bool Equals(object obj)
        {
            if (this.GetType().Equals(obj.GetType())) //se il tipo è uguale
                return this.CodConto.Equals(((ContoCorrenteBancario)obj).CodConto); //se ha lo stesso codice conto
            return false;
        }
    }
}
