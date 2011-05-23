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

        public static Currency operator +(Currency c1, Currency c2)
        {
            if(!c1.Valuta.Equals(c2.Valuta))
                throw new InvalidOperationException("Valuta diversa!");
            return new Currency(c1.Value + c2.Value, c1.Valuta);
        }

        public static Currency operator -(Currency c1, Currency c2)
        {
            return ( c1 + new Currency(- c2.Value, c2.Valuta) );
        }

        private static Currency operator *(Currency c1, Currency c2)
        {
            if (!c1.Valuta.Equals(c2.Valuta))
                throw new InvalidOperationException("Valuta diversa!");
            return (new Currency(c1.Value * c2.Value, c1.Valuta));
        }

        private static Currency operator /(Currency c1, Currency c2)
        {
            if (c2.Value == 0)
                throw new DivideByZeroException("Divisione per zero");
            return (c1 * (new Currency(1/c2.Value,c2.Valuta) ) );
        }

        private static bool operator ==(Currency c1, Currency c2)
        {
            return (c1.Value == c2.Value && c1.Valuta.Equals(c2.Valuta));
        }
    }
}
