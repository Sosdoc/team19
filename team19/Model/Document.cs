using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Team19.Model.Fatture;
using Team19.Model.Movimenti;

namespace Team19.Model
{
    class Document
    {
        private List<MovimentoDiDenaro> _movimenti;
        private List<ContenitoreDiDenaro> _contenitoriDiDenaro;
        private Cassa _cassa;
        private List<Fattura> _fatture;
        private List<Prodotto> _prodotti;
        //private List<Soggetto> _soggetti;
        private Document _instance;

        public IEnumerable<MovimentoDiDenaro> Movimenti
        {
            get { return _movimenti; }
        }

        public IEnumerable<ContenitoreDiDenaro> ContenitoriDiDenaro
        {
            get { return _contenitoriDiDenaro; }
        }

        public Cassa Cassa
        {
            get { return _cassa; }
        }

        public IEnumerable<Fattura> Fatture
        {
            get { return _fatture; }
        }

        public IEnumerable<Prodotto> Prodotti
        {
            get { return _prodotti; }
        }

        //public IEnumerable<Soggetto> Soggetti
        //{
        //    get { return _soggetti; }
        //}


        private Document()
        {
        }

        public static void CreateInstance()
        {
            throw new NotImplementedException();
        }

        public static Document GetInstance()
        {
            throw new NotImplementedException();
        }




    }
}
