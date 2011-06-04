using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    public class RigaFattura
    {
        private double _quantità;
        private Currency _prezzoUnitario;
        private Prodotto _prodotto;

        public RigaFattura(double quantità, Currency prezzoUnitario, Prodotto prodotto)
        {
            if (quantità <= 0 || prezzoUnitario.Value <= 0)
                throw new ArgumentException("quantità <= 0 || prezzoUnitario.Value <= 0");
            if (prodotto == null)
                throw new ArgumentException("prodotto == null");

            this._prezzoUnitario = prezzoUnitario;
            this._quantità = quantità;
            this._prodotto = prodotto;
        }
        public RigaFattura(double quantità, Prodotto prodotto)
            : this(quantità, prodotto.Prezzo, prodotto)
        {

        }

        public double Quantità
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

        public override string ToString()
        {
            return "#"+Quantità.ToString()+" "+Prodotto.ToString();
        }
    }
}
