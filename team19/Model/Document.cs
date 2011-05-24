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
        private List<Prodotto> _prodotti; //meglio un dictionary?
        private List<Soggetto> _soggetti;
        private List<Dipendente> _dipendenti;

        public List<Dipendente> Dipendenti
        {
            get { return _dipendenti; }
           
        }
        //riepiloghi?
        private Cassa _cassa;

        private static Document _instance;

        public static event EventHandler Changed;

        private Document()
        {
        }

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
            _movimenti = new List<MovimentoDiDenaro>();
            _cassa = new Cassa(new Currency(10000m));
            _contenitoriDiDenaro = new List<ContenitoreDiDenaro>();
            _fatture = new List<Fattura>();
            _prodotti = new List<Prodotto>();
            _soggetti = new List<Soggetto>();
            _dipendenti = new List<Dipendente>();

            _dipendenti.Add(new Dipendente("aymen2011", "12345", "aymen", "chakroun", "Uente"));
            _dipendenti.Add(new Dipendente("francesco2011", "12345", "francesco", "casimiro", "Amministratore"));
            _dipendenti.Add(new Dipendente("valerio2011", "12345", "valerio", "pipolo", "Uente"));
            _dipendenti.Add(new Dipendente("maria2011", "12345", "maria", "rosso", "Uente"));
            _dipendenti.Add(new Dipendente("elena2011", "12345", "elena", "vasilescu", "Uente"));
           
            Indirizzo i = new Indirizzo("nessuna", "9001", "Quaggiù", "02983", "BOH", "Ailati");
            Cliente c1 = new Cliente("Pinco Pallino", "0", "no", "8301", "PNCPLNlol", i);
            Fornitore fo1 = new Fornitore("Pallo Pinchino", "13109", "forse", "9329239", i);
            Prodotto p1 = new Prodotto(new Currency(10m), "palla", new CodiceProdotto("PAL", "11400"));
            FatturaAcquisto f1 = FatturaFactory.Instance.CreateFatturaAcquisto(fo1, DateTime.Now, 1003, new Currency(10004.23m) );
            RigaFattura riga1 = new RigaFattura(10, p1);
            RigaFattura riga2 = new RigaFattura(320, p1);
            List<RigaFattura> righe = new List<RigaFattura>();
            righe.Add(riga1);
            righe.Add(riga2);
            FatturaVendita f2 = FatturaFactory.Instance.CreateFatturaVendita(c1, DateTime.Now, righe);
           
            FatturaVendita f3 = FatturaFactory.Instance.CreateFatturaVendita(c1, DateTime.Now, righe);
            Dipendente d = new Dipendente("io", "no", "lol", "asd","Amministratore");
            MovimentoDiDenaro m1 = MovimentoFactory.CreatePagamentoAcquisto(Cassa, f1, DateTime.Now, d, "asd");
            MovimentoDiDenaro m2 = MovimentoFactory.CreateIncassoVendita(f2, Cassa, DateTime.Now, d, "asd");
            ContoCorrenteBancario cc = new ContoCorrenteBancario("AOSIDJHOGIHAPI",new Currency(10000m));
            MovimentoDiDenaro m3 = MovimentoFactory.CreateMovimentoInterno(Cassa, cc, new Currency(1000m), DateTime.Now, d, "loisd");
            _movimenti.Add(m1);
            _movimenti.Add(m2);
            _movimenti.Add(m3);
            _fatture.Add(f1);
            _fatture.Add(f2);

            _soggetti.Add(fo1);
            _soggetti.Add(c1);

            

            _prodotti.Add(p1);
            _contenitoriDiDenaro.Add(_cassa);
            _contenitoriDiDenaro.Add(cc);


            OnChanged();
        }

        public void Save()
        {
            //questo metodo non fa nulla
        }
        
        public IEnumerable<FatturaVendita> GetFattureVendita()
        {
            return this.Fatture.OfType<FatturaVendita>();
        }

        public IEnumerable<FatturaAcquisto> GetFattureAcquisto()
        {
            return this.Fatture.OfType<FatturaAcquisto>();
        }        

        protected virtual void OnChanged()
        {
            if (Changed != null)
                Changed(this, EventArgs.Empty);
        }
    }
}
