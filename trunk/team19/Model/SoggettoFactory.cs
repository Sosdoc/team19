using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    class SoggettoFactory
    {

        public static ICliente CreateCliente(string denominazione, string telefono, string email, string partitaIva, string codiceFiscale, Indirizzo indirizzo)
        {
            return new Cliente(denominazione, telefono, email, partitaIva, codiceFiscale, indirizzo);
        }
        public static IFornitore CreateFornitore(string denominazione, string telefono, string email, string partitaIva, Indirizzo indirizzo)
        {
            return new Fornitore(denominazione, telefono, email, partitaIva, indirizzo);
        }
        public static ISoggetto CreateClienteFornitore(string denominazione, string telefono, string email, string partitaIva,string codiceFiscale, Indirizzo indirizzo)
        {
            return new ClienteFornitore(denominazione, telefono, email, partitaIva,codiceFiscale, indirizzo);
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
                if (partitaIva == null && codiceFiscale == null)
                    throw new ArgumentNullException("Partita Iva e Codice Fiscale entrambi nulli");
                _codiceFiscale = codiceFiscale;
            }

            public string CodiceFiscale
            {
                get { throw new NotImplementedException(); }
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

        }
    }
}
