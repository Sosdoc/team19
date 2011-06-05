using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Team19.Model
{
    public class Prodotto
    {
        private string _descrizione;
        private Currency _prezzo;
        CodiceProdotto _codProdotto;

        public Prodotto(Currency prezzo, string descrizione, CodiceProdotto codProdotto)
        {
            this._descrizione = descrizione;
            this._prezzo = prezzo;
            this._codProdotto = codProdotto;
        }

        public string Descrizione
        {
            get { return _descrizione; }
        }

        public Currency Prezzo
        {
            get { return _prezzo; }
        }

        public CodiceProdotto CodProdotto
        {
            get { return _codProdotto; }
        }

        public override string ToString()
        {
            return Descrizione;
        }
    }
}
