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
        private Prodotto _prodotto;
        
        public RigaFattura(int quantità, Currency prezzoUnitario, Prodotto prodotto)
        {
            if(quantità <= 0 || prezzoUnitario.Value <= 0)
                throw new ArgumentException("quantità <= 0 || prezzoUnitario.Value <= 0");
            if(prodotto == null)
                throw new ArgumentException("prodotto == null");

            this._prezzoUnitario = prezzoUnitario;
            this._quantità = quantità;
            this._prodotto = prodotto;
        }

        public int Quantità
        {
            get { return _quantità; }
        }

        public Currency PrezzoUnitario
        {
            get { return _prezzoUnitario; }
        }

        public Prodotto Prodotto
        {
            get { return _prodotto; }
        }

    }
}
