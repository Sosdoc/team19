using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    public interface ISoggetto
    {
        string Telefono
        {
            get;
        }
        
        string EMail
        {
            get;
        }
       
        string PartitaIva
        {
            get;
        }

        string CodiceFiscale
        {
            get;
        }

        Indirizzo Indirizzo
        {
            get;
        }

        string Denominazione
        {
            get;
        }

    }
}
