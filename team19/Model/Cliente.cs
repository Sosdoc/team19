using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
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

        public string CodiceFiscale  // Chiedere per il null
        {
            get { return _codiceFiscale; }
        }
    }
}
