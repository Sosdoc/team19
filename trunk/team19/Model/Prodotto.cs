using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    public class Prodotto
    {
        private string descrizione;
        private Currency prezzo;
        CodiceProdotto codProdotto;

        public string Descrizione
        {
            get { return descrizione; }
        //    set { descrizione = value; }
        }

        public Currency Prezzo
        {
            get { return prezzo; }
        //    set { prezzo = value; }
        }

        public CodiceProdotto CodProdotto
        {
            get { return codProdotto; }
        //    set { codProdotto = value; }
        } 
    }
}
