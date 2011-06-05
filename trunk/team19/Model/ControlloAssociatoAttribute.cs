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
        private Type _tipo;

        
        public ControlloAssociatoAttribute(Type controllo)
        {
            if (!controllo.IsSubclassOf(typeof(Control)))
                throw new ArgumentException("Non un controllo");
                
            _controllo = controllo;
            
        }

        public ControlloAssociatoAttribute(Type controllo, Type tipo)
            : this(controllo)
        {
            _tipo = tipo;
        }

        public Type Controllo
        {
            get { return _controllo; }
            set { _controllo = value; }
        }

        public Type Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }



    }
}
