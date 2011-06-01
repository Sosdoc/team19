using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    class SoggettoFactory
    {

        public static Cliente CreateCliente(string denominazione, string telefono, string email, string partitaIva, string codiceFiscale, Indirizzo indirizzo)
        {
            return new Cliente(denominazione, telefono, email, partitaIva, codiceFiscale, indirizzo);
        }

        public static Fornitore CreateFornitore(string denominazione, string telefono, string email, string partitaIva, Indirizzo indirizzo)
        {
            return new Fornitore(denominazione, telefono, email, partitaIva, indirizzo);
        }

    
    }
}
