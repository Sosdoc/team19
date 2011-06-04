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
        private Control _controllo;

        public ControlloAssociatoAttribute(Control controllo)
        {
            _controllo = controllo;
        }

        public Control Controllo
        {
            get { return _controllo; }
            set { _controllo = value; }
        }



    }
}
