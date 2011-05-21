using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model.Soggetti
{
    public class Cliente : Soggetto
    {
        private string? _codiceFiscale;

        

        public Cliente(string denominazione, string telefono, string email, string? partitaIva, string? codiceFiscale) :base(denominazione,telefono,email,partitaIva)
        {
            if (!partitaIva.HasValue && !codiceFiscale.HasValue)
                throw new ArgumentNullException("Partita Iva e Codice Fiscale entrambi nulli");
            _codiceFiscale = codiceFiscale;
        }

        public string CodiceFiscale  // Chiedere per il null
        {
            get { return _codiceFiscale.Value; }
        }
    }
}
