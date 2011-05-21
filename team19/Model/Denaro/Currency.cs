using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    public class Currency
    {
        private double _value;

        public double Value
        {
            get { return _value; }
            set { this._value = value; }
        }

        public Currency(double value)
        {
            this._value = value;
        }

        public override String ToString()
        {
            return "€ " + this.Value.ToString();
        }
    }
}
