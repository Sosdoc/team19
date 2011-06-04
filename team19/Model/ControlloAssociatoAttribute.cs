using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Team19.Model
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    class ControlloAssociatoAttribute : System.Attribute
    {
        private Type _controllo;

        public ControlloAssociatoAttribute(Type controllo)
        {
            if (!controllo.IsSubclassOf(typeof(Control)))
                throw new ArgumentException("Non un controllo");
                
            _controllo = controllo;
            
        }

        public Type Controllo
        {
            get { return _controllo; }
            set { _controllo = value; }
        }



    }
}
