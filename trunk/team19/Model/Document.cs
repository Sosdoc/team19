using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Team19.Persistence;
using System.ComponentModel;
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
        private Cassa _cassa;

        private static Document _instance;
        private IDocumentPersister _persister;
        private Dipendente _utenteConnesso;
        public static event EventHandler Changed;

        private Document(IDocumentPersister persister)
        {
            this._persister = persister;
            _prodotti = new List<Prodotto>();
            _dipendenti = new List<Dipendente>();

            _contenitoriDiDenaro = new List<ContenitoreDiDenaro>();
            _soggetti = new List<Soggetto>();
            _fatture = new List<Fattura>();
            _movimenti = new List<MovimentoDiDenaro>();

        }

        #region Document properties

        public Dipendente UtenteConnesso
        {
            get { return _utenteConnesso; }
            set { _utenteConnesso = value; }
        }

        [DisplayName("Dipendenti")]
        public IList<Dipendente> Dipendenti
        {
            get
            {
                if (_utenteConnesso != null && _utenteConnesso.Ruolo != TipoDipendente.Amministratore)
                    return null;
                return _dipendenti;
            }

        }

        [DisplayName("Movimenti")]
        public IList<MovimentoDiDenaro> Movimenti
        {
            get { return _movimenti; }
        }

        [DisplayName("Depositi")]
        public IList<ContenitoreDiDenaro> ContenitoriDiDenaro
        {
            get { return _contenitoriDiDenaro; }
        }

        public Cassa Cassa
        {
            get { return _cassa; }
        }

        [DisplayName("Fatture")]
        public IList<Fattura> Fatture
        {
            get { return _fatture; }
        }

        [DisplayName("Prodotti")]
        public IList<Prodotto> Prodotti
        {
            get { return _prodotti; }
        }

        [DisplayName("Soggetti")]
        public IList<Soggetto> Soggetti
        {
            get { return _soggetti; }
        }

        #endregion

        #region Document members

        public static void CreateInstance(IDocumentPersister persister)
        {
            _instance = new Document(persister);
            _instance.Load();
        }

        public static Document GetInstance()
        {
            if (_instance == null)
                CreateInstance(new DefaultPersister());
            //if (_instance.UtenteConnesso == null) 
            //    throw new ApplicationException("Nessun utente connesso");
            return _instance;
        }

        private void IsAmministratore()
        {
            if (!UtenteConnesso.Ruolo.Equals(TipoDipendente.Amministratore))
                throw new InvalidOperationException("Non hai privilegi di amministratore");
        }

        public void Autentica(string username, string password)
        {

            try
            {
                IEnumerable<Dipendente> dipendenti = from dipendente in _instance._dipendenti
                                                     where dipendente.Username.Equals(username) && dipendente.Password.Equals(password)
                                                     select dipendente;
                Dipendente d = null;

                if (dipendenti.Count() != 0)
                    d = dipendenti.First();

                if (d == null) throw new KeyNotFoundException("Username o password non corrispondenti");
                _utenteConnesso = d;
                OnChanged();
            }
            catch (InvalidOperationException ex) { }
        }

        private void Load()
        {
            IDocumentLoader loader = _persister.GetLoader();

            _prodotti = loader.LoadProdotti();
            _dipendenti = loader.LoadDipendenti();
            _cassa = loader.LoadCassa();
            _contenitoriDiDenaro = loader.LoadContenitori();
            _soggetti = loader.LoadSoggetti();
            _fatture = loader.LoadFatture();
            _movimenti = loader.LoadMovimenti();

            OnChanged();
        }

        public void Save()
        {
            //questo metodo non fa nulla -- defaultPersister lancia NotImplementedException
            //_persister.Save();
        }

        public IList<Cliente> GetClienti()
        {
            return this.Soggetti.OfType<Cliente>().ToList();
        }

        public IList<Fornitore> GetFornitori()
        {
            return this.Soggetti.OfType<Fornitore>().ToList();
        }

        public IList<FatturaVendita> GetFattureVendita()
        {
            return this.Fatture.OfType<FatturaVendita>().ToList();
        }

        public IList<FatturaAcquisto> GetFattureAcquisto()
        {
            return this.Fatture.OfType<FatturaAcquisto>().ToList();
        }

        public IList<DepositoDiDenaro> GetDepositi()
        {
            return this.ContenitoriDiDenaro.OfType<DepositoDiDenaro>().ToList();
        }

        public IList<ContenitoreDiDenaro> GetContenitori()
        {
            return this.ContenitoriDiDenaro.ToList();
        }

        public Cassa GetCassa()
        {
            return this.Cassa;
        }

        public IEnumerable<MovimentoDiDenaro> GetPagamentiAcquisti()
        {
            return this.Movimenti.Where(movimento => movimento.Destinazione is FatturaAcquisto);
        }

        public IEnumerable<MovimentoDiDenaro> GetIncassiVendite()
        {
            return this.Movimenti.Where(movimento => movimento.Sorgente is FatturaVendita);
        }

        #endregion

        protected virtual void OnChanged()
        {
            if (Changed != null)
                Changed(this, EventArgs.Empty);
        }
    }
}
