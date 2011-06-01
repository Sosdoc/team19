using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    class NomeVisualizzatoAttribute:System.Attribute
    {
        private string _name;
        public NomeVisualizzatoAttribute(string name)
        {
            _name = name;
        }

        public string NomeVisualizzato
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
