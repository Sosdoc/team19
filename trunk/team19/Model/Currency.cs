using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    class Currency
    {
        private double _value;

        public Currency(double value)
        {
            this._value = value;
        }
        public override String ToString()
        {
            return "€ " + _value.ToString();
        }
    }
}
