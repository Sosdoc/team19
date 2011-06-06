using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    /// <summary>
    /// Classe da cui derivano tutti i Contenitori che non siano la Cassa
    /// </summary>
    public abstract class DepositoDiDenaro : ContenitoreDiDenaro
    {
        public DepositoDiDenaro(Currency saldoIniziale)
            : base(saldoIniziale)
        { }        
    }
}
