using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    class RigaFattura
    {
        private int _quantità;
        private Currency _prezzoUnitario;
        //private Prodotto _prodotto;
        
        //aggiungere il prodotto
        public RigaFattura(int quantità, Currency prezzoUnitario)
        {
            this._prezzoUnitario = prezzoUnitario;
            this._quantità = quantità;
        }

        public int Quantità
        {
            get { return _quantità; }
        }

        public Currency PrezzoUnitario
        {
            get { return _prezzoUnitario; }
        }
    

    }
}
