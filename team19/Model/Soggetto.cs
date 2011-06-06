using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

        public string Denominazione
        {
            get { return _denominazione; }
        }

        public Indirizzo Indirizzo
        {
            get { return _indirizzo; }
        }
        
        public string Telefono
        {
            get { return _telefono; }
        }

        public string EMail
        {
            get { return _eMail; }
        }

        public string PartitaIva
        {
            get { return _partitaIva ?? "Nessuna partita IVA"; }
        }

        public abstract string CodiceFiscale
        {
            get;
        }

        #endregion

        public override string ToString()
        {
            return Denominazione;
        }
    }

    public class Cliente : Soggetto
    {
        private string _codiceFiscale;

        public Cliente(string denominazione, string telefono, string email, string partitaIva, string codiceFiscale, Indirizzo indirizzo)
            : base(denominazione, telefono, email, partitaIva, indirizzo)
        {
            if (String.IsNullOrEmpty(partitaIva) && String.IsNullOrEmpty(codiceFiscale))
                throw new ArgumentNullException("Partita Iva e Codice Fiscale entrambi nulli");
            _codiceFiscale = codiceFiscale;
        }

        public override string CodiceFiscale  
        {
            get { return _codiceFiscale; }
        }
        public override string ToString()
        {
            return base.ToString() + " - Cliente";
        }
    }

    public class Fornitore : Soggetto
    {
        public Fornitore(string denominazione, string telefono, string email, string partitaIva, Indirizzo indirizzo)
            : base(denominazione, telefono, email, partitaIva, indirizzo)
        {
            if (String.IsNullOrEmpty(partitaIva))
                throw new ArgumentNullException("Partita Iva nulla");
        }

        public override string CodiceFiscale
        {
            get { return "Nessun Codice Fiscale"; }
        }

        public override string ToString()
        {
            return base.ToString() + " - Fornitore";
        }
    }
}
