using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    public class Currency
    {
        private decimal _value;

        public decimal Value
        {
            get { return _value; }
        }

        public Currency(decimal value)
        {
            this._value = value;
        }

        public override String ToString()
        {
            return String.Format("{0:C}", this.Value);
        }

        public static Currency operator +(Currency c1, Currency c2)
        {
            return new Currency(c1.Value + c2.Value);
        }

        public static Currency operator -(Currency c1, Currency c2)
        {
            return (c1 + new Currency(-c2.Value));
        }

        public static Currency operator *(Currency c1, Currency c2)
        {
            return (new Currency(c1.Value * c2.Value));
        }

        public static Currency operator *(double d, Currency c)
        {
            return (new Currency((decimal)d * c.Value));
        }

        public static Currency operator *(Currency c, double d)
        {
            return d * c;
        }

        public static Currency operator /(Currency c1, Currency c2)
        {
            if (c2.Value == 0)
                throw new DivideByZeroException("Divisione per zero");
            return (c1 * (new Currency(1 / c2.Value)));
        }

        //public static bool operator ==(Currency c1, Currency c2)
        //{
        //    return (c1.Value == c2.Value);
        //}

        //public static bool operator !=(Currency c1, Currency c2)
        //{
        //    return !(c1 == c2);
        //}

        public override bool Equals(Object c)
        {
            if (!(c is Currency))
                return false;
            return ((c is Currency && this == (Currency)c) || object.ReferenceEquals(this, c));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
