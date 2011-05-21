using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    class Document
    {
        private List<MovimentoDiDenaro> _movimenti;
        private List<ContenitoreDiDenaro> _contenitoriDiDenaro;
        private List<Fattura> _fatture;
        private List<Prodotto> _prodotti;
        private List<Soggetto> _soggetti;
        private Cassa _cassa;

        private static Document _instance;

        public static event EventHandler Changed;

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

        public IEnumerable<Soggetto> Soggetti
        {
            get { return _soggetti; }
        }

        private Document()
        {
        }

        public static void CreateInstance()
        {
            _instance = new Document();
            _instance.Load();
        }

        public static Document GetInstance()
        {
            if (_instance == null)
                CreateInstance();
            return _instance;
        }

        private void Load()
        {
            //qui inizializzo le liste
            OnChanged();
        }

        public void Save()
        {
            //questo metodo non fa nulla
        }

        protected virtual void OnChanged()
        {
            if (Changed != null)
                Changed(this, EventArgs.Empty);
        }


    }
}
