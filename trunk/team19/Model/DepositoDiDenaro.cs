﻿using System;
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

        public override string CodConto
        {
            get { return "Cassa"; }
        }
    }
}