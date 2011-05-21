using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    public class Fornitore : Soggetto
    {
            public Fornitore(string denominazione, string telefono, string email, string partitaIva)
                : base(denominazione, telefono, email, partitaIva)
            {
                if (partitaIva==null)
                    throw new ArgumentNullException("Partita Iva nulla");
            }
        
    }
}
