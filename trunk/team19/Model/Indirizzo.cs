using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    public struct Indirizzo
    {
        private string _via;
        private string _numeroCivico;
        private string _località;
        private string _cap;
        private string _provincia;
        private string _nazione;

        //Costruttore da singola stringa, orribile, non fa alcun tipo di controllo e se sbagli ti esplode in faccia
        public Indirizzo(string indirizzo)
        {
            string[] splitIndirizzo = indirizzo.Split(',');
            _via = splitIndirizzo[0];
            _numeroCivico = splitIndirizzo[1];
            _cap = splitIndirizzo[2];
            _località = splitIndirizzo[3];
            _provincia = splitIndirizzo[4];
            _nazione = splitIndirizzo[5];
        }

        public Indirizzo(string via, string numeroCivico, string località, string cap, string provincia, string nazione)
        {
            _via = via;
            _numeroCivico = numeroCivico;
            _località = località;
            _cap = cap;
            _provincia = provincia;
            _nazione = nazione;
        }

        public string Via
        {
            get { return _via; }
            set { _via = value; }
        }

        public string NumeroCivico
        {
            get { return _numeroCivico; }
            set { _numeroCivico = value; }
        }

        public string Località
        {
            get { return _località; }
            set { _località = value; }
        }

        public string Cap
        {
            get { return _cap; }
            set { _cap = value; }
        }

        public string Provincia
        {
            get { return _provincia; }
            set { _provincia = value; }
        }

        public string Nazione
        {
            get { return _nazione; }
            set { _nazione = value; }
        }

        public override string ToString()
        {
            return Via + ", " + NumeroCivico + ", " + Località + " (" + Provincia + ")," + Cap + ", " + Nazione;
        }
    }
}
