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
        private Movimenti _movimenti;
        private ContenitoriDiDenaro _contenitoriDiDenaro;
        private Fatture _fatture;
        private Prodotti _prodotti; 
        private Soggetti _soggetti;
        private Dipendenti _dipendenti;
        private Cassa _cassa;

        private static Document _instance;
        private IDocumentPersister _persister;
        private Dipendente _utenteConnesso;
        public static event EventHandler Changed;

        private Document(IDocumentPersister persister)
        {
            this._persister = persister;
            _prodotti = new Prodotti();
            _dipendenti = new Dipendenti();

            _contenitoriDiDenaro = new ContenitoriDiDenaro();
            _soggetti = new Soggetti();
            _fatture = new Fatture();
            _movimenti = new Movimenti();

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
        public IList<DepositoDiDenaro> ContenitoriDiDenaro
        {
            get { return _contenitoriDiDenaro; }
        }
        [DisplayName("Cassa")]
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

        #region Document Instance

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
        #endregion

        #region Document Autenticazione/Persistenza

        private void IsAmministratore()
        {
            if (!UtenteConnesso.Ruolo.Equals(TipoDipendente.Amministratore))
                throw new InvalidOperationException("Non hai privilegi di amministratore");
        }

        public void Autentica(string username, string password)
        {
            IEnumerable<Dipendente> dipendenti = from dipendente in _instance._dipendenti
                                                 where dipendente.Username.Equals(username) && dipendente.Password.Equals(password)
                                                 select dipendente;
            Dipendente d = null;

            if (dipendenti.Count() != 0)
                d = dipendenti.First();

            if (d == null) 
                throw new KeyNotFoundException("Username o password non corrispondenti");

            _utenteConnesso = d;
            OnChanged();
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
        #endregion

        #region Document utility
        //public IList<Cliente> GetClienti()
        //{
        //    return this.Soggetti.OfType<Cliente>().ToList();
        //}

        //public IList<Fornitore> GetFornitori()
        //{
        //    return this.Soggetti.OfType<Fornitore>().ToList();
        //}

        //public IList<FatturaVendita> GetFattureVenditaDaPagare()
        //{
        //    IEnumerable<FatturaVendita> fatture= from fattura in Fatture.OfType<FatturaVendita>().ToList()
        //                                   join movimento in GetIncassiVendite().ToList() on fattura equals (FatturaVendita)movimento.Sorgente
        //                                   select fattura;
        //    return Fatture.OfType<FatturaVendita>().Except(fatture).ToList();
        //}

        //public IList<FatturaAcquisto> GetFattureAcquistoDaPagare()
        //{
        //    IEnumerable<FatturaAcquisto> fatture = from fattura in Fatture.OfType<FatturaAcquisto>().ToList()
        //                                           join movimento in GetPagamentiAcquisti().ToList() on fattura equals (FatturaAcquisto)movimento.Destinazione
        //                                          select fattura;
        //    return Fatture.OfType<FatturaAcquisto>().Except(fatture).ToList();
        //}

        //public IList<DepositoDiDenaro> GetDepositi()
        //{
        //    return this.ContenitoriDiDenaro.OfType<DepositoDiDenaro>().ToList();
        //}

        //public IList<DepositoDiDenaro> GetContenitori()
        //{
        //    return this.ContenitoriDiDenaro.ToList();
        //}

        //public IList<Cassa> GetCassa()
        //{
        //    IList<Cassa> result = new List<Cassa>();
        //    result.Add(Cassa);
        //    return result;
        //}

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
