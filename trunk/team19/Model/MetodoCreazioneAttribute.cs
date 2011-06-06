using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Team19.Model
{
    /// <summary>
    /// Questo attributo contrassegna metodi factory che verranno utilizzati attraverso la reflection, l'attributo indica il tipo di oggetto che il metodo restituirà oltre
    /// ad una lista di controlli specifici per poter inserire correttamente ogni parametro necessario per la creazione.
    /// </summary>

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor, Inherited = true, AllowMultiple = false)]
    class MetodoCreazioneAttribute : System.Attribute
    {
        private string _tipo;
        private Type[] _controlli;

        public MetodoCreazioneAttribute(string tipo, Type[] controlli)
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
