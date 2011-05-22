using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    public class Currency
    {
        private double _value;
        private String _valuta;

        public String Valuta
        {
            get { return _valuta; }
            set { _valuta = value; }
        }

        public double Value
        {
            get { return _value; }
        }

        public Currency(double value)
            : this(value, "€")
        {
        }

        public Currency(double value, String valuta)
        {
            if (value <= 0)
                throw new ArgumentException("value <= 0");
            if (valuta.Length != 1)
                throw new ArgumentException("valuta.Length != 1");

            this._value = value;
            this._valuta = valuta;
        }

        public override String ToString()
        {
            return this.Valuta + " " + this.Value.ToString();
        }

        //TODO: override degli operatori + - * / ==
    }
}
