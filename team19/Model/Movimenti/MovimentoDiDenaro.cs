using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    abstract class MovimentoDiDenaro
    {
        private DateTime _data;

        private ISorgente _sorgente;
        private IDestinazione _destinazione;
        private Dipendente _dipendente;
        private DateTime _dataRegistrazione;

        protected MovimentoDiDenaro(ISorgente sorgente, IDestinazione destinazione, DateTime data, Dipendente dipendente)
        {
            _data = data;
            _sorgente = sorgente;
            _destinazione = destinazione;
            _dataRegistrazione = DateTime.Now;
        }


        public DateTime Data
        {
            get { return _data; }
        }

        public abstract Currency Importo
        {
            get;
        }

        public ISorgente Sorgente
        {
            get;
        }

        public IDestinazione Destinazione
        {
            get;
        }

        public Dipendente Dipendente
        {
            get { return _dipendente; }
        }

        public DateTime DataRegistrazione
        {
            get { return _dataRegistrazione; }
        }


       
    }
}