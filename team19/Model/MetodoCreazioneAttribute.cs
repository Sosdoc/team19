using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Team19.Model
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor, Inherited = true, AllowMultiple = false)]
    class MetodoCreazioneAttribute:System.Attribute
    {
        private string _tipo;
        private Type[] _controlli;

        
        public MetodoCreazioneAttribute(string tipo,Type[] controlli)
        {
            _tipo = tipo;
            foreach (Type t in controlli)
            {
                if (!t.IsSubclassOf(typeof(Control))) throw new ArgumentException();

            }
            _controlli = controlli;
        }

        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
        public Type[] Controlli
        {
            get { return _controlli; }
            set { _controlli = value; }
        }

    }
}
