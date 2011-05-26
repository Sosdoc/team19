using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    class SoggettoFactory
    {

        public static ISoggetto CreateCliente(string denominazione, string telefono, string email, string partitaIva, string codiceFiscale, Indirizzo indirizzo)
        {
            if (String.IsNullOrEmpty(partitaIva) && String.IsNullOrEmpty(codiceFiscale))
                throw new ArgumentNullException("partitaIva o codicefiscale null");

            IFornitore f = FornitoreExist(partitaIva);

            if (f != null)
            {
                Document.GetInstance().Remove(f);
                return CreateClienteFornitore(denominazione, telefono, email, partitaIva, codiceFiscale, indirizzo);
            }

            return new Cliente(denominazione, telefono, email, partitaIva, codiceFiscale, indirizzo);
        }

        private static IFornitore FornitoreExist(string partitaIva)
        {
            IFornitore fornitore =
                (from f in Document.GetInstance().Soggetti.OfType<IFornitore>()
                 where f.PartitaIva.Equals(partitaIva)
                 select f).First();

            if (fornitore is ClienteFornitore)
                return null;

            return fornitore;
        }

        public static ISoggetto CreateFornitore(string denominazione, string telefono, string email, string partitaIva, Indirizzo indirizzo)
        {
            if (String.IsNullOrEmpty(partitaIva))
                throw new ArgumentNullException("partitaIva o codicefiscale null");

            ICliente c = ClienteExist(partitaIva);

            if (c != null)
            {
                Document.GetInstance().Remove(c);
                return CreateClienteFornitore(denominazione, telefono, email, partitaIva, c.CodiceFiscale, indirizzo);
            }

            return new Fornitore(denominazione, telefono, email, partitaIva, indirizzo);
        }

        private static ICliente ClienteExist(string partitaIva)
        {
            ICliente cliente =
                (from c in Document.GetInstance().Soggetti.OfType<ICliente>()
                 where c.PartitaIva.Equals(partitaIva)
                 select c).First();

            if (cliente is ClienteFornitore)
                return null;

            return cliente;
        }

        private static ISoggetto CreateClienteFornitore(string denominazione, string telefono, string email, string partitaIva, string codiceFiscale, Indirizzo indirizzo)
        {
            return new ClienteFornitore(denominazione, telefono, email, partitaIva, codiceFiscale, indirizzo);
        }

        public abstract class Soggetto : ISoggetto
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

            public override bool Equals(object obj)
            {
                if (!(obj is ISoggetto))
                    return false;
                return false;
            }

        }

        public class Cliente : Soggetto, ICliente
        {
            public Cliente(string denominazione, string telefono, string email, string partitaIva, string codiceFiscale, Indirizzo indirizzo)
                : base(denominazione, telefono, email, partitaIva, indirizzo)
            {
                if (partitaIva == null && codiceFiscale == null)
                    throw new ArgumentNullException("Partita Iva e Codice Fiscale entrambi nulli");
                _codiceFiscale = codiceFiscale;
            }
            private string _codiceFiscale;
            public string CodiceFiscale  // Chiedere per il null
            {
                get { return _codiceFiscale; }
            }
        }

        class ClienteFornitore : Soggetto, IFornitore, ICliente
        {
            private string _codiceFiscale;
            public ClienteFornitore(string denominazione, string telefono, string email, string partitaIva, string codiceFiscale, Indirizzo indirizzo)
                : base(denominazione, telefono, email, partitaIva, indirizzo)
            {
                if (String.IsNullOrEmpty(partitaIva) && String.IsNullOrEmpty(codiceFiscale))
                    throw new ArgumentNullException("Partita Iva e Codice Fiscale entrambi nulli");
                _codiceFiscale = codiceFiscale;
            }

            public string CodiceFiscale
            {
                get { return _codiceFiscale ?? "Nessun Codice Fiscale"; }
            }
        }

        public class Fornitore : Soggetto, IFornitore
        {
            public Fornitore(string denominazione, string telefono, string email, string partitaIva, Indirizzo indirizzo)
                : base(denominazione, telefono, email, partitaIva, indirizzo)
            {
                if (partitaIva == null)
                    throw new ArgumentNullException("Partita Iva nulla");
            }


            public string CodiceFiscale
            {
                get { return "Nessun Codice Fiscale"; }
            }
        }
    }
}
