using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    public abstract class Soggetto
    {
        private string _denominazione;
        private string _telefono;
        private string _eMail;
        private string _partitaIva;
        private Indirizzo _indirizzo;

        protected Soggetto(string denominazione, string telefono, string email, string partitaIva, Indirizzo indirizzo)
        {
            _denominazione = denominazione;
            _telefono = telefono;
            _eMail = email;
            _partitaIva = partitaIva;
            _indirizzo = indirizzo;
        }

        #region Soggetto properties
        public Indirizzo Indirizzo
        {
            get { return _indirizzo; }
            //set { _indirizzo = value; }
        }

        public string Telefono
        {
            get { return _telefono; }
            //set { _telefono = value; }
        }

        public string EMail
        {
            get { return _eMail; }
            //set { _eMail = value; }
        }

        public string Denominazione
        {
            get { return _denominazione; }
            //set { _denominazione = value; }
        }

        public string PartitaIva
        {
            get { return _partitaIva ?? "Nessuna partita IVA"; }
            //set { _partitaIva = value; }
        }

        public abstract string CodiceFiscale
        {
            get;
        }

        #endregion

    }

    public class Cliente : Soggetto
    {
        private string _codiceFiscale;

        public Cliente(string denominazione, string telefono, string email, string partitaIva, string codiceFiscale, Indirizzo indirizzo)
            : base(denominazione, telefono, email, partitaIva, indirizzo)
        {
            if (partitaIva == null && codiceFiscale == null)
                throw new ArgumentNullException("Partita Iva e Codice Fiscale entrambi nulli");
            _codiceFiscale = codiceFiscale;
        }

        public override string CodiceFiscale  // Chiedere per il null
        {
            get { return _codiceFiscale; }
        }
    }

    public class Fornitore : Soggetto
    {
        public Fornitore(string denominazione, string telefono, string email, string partitaIva, Indirizzo indirizzo)
            : base(denominazione, telefono, email, partitaIva, indirizzo)
        {
            if (partitaIva == null)
                throw new ArgumentNullException("Partita Iva nulla");
        }


        public override string CodiceFiscale
        {
            get { return "Nessun Codice Fiscale"; }
        }
    }
}
