using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    public abstract class ContenitoreDiDenaro: ISorgente, IDestinazione
    {
        private readonly Currency _saldoIniziale;

        public Currency SaldoIniziale
        {
            get { return _saldoIniziale; }
        }

        public abstract Currency Saldo
        {
            get;
        }
    }
}
