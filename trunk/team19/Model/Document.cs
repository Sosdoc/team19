﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Team19.Persistence;

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


        //#region Document Adders

        //public void Add(MovimentoDiDenaro movimento)
        //{
        //    _movimenti.Add(movimento);
        //    OnChanged();
        //}

        //public void Add(Fattura fattura)
        //{
        //    _fatture.Add(fattura);
        //    OnChanged();
        //}

        //public void Add(Soggetto soggetto)
        //{
        //    _soggetti.Add(soggetto);
        //    OnChanged();
        //}

        //public void Add(ContenitoreDiDenaro contenitore)
        //{
        //    _contenitoriDiDenaro.Add(contenitore);
        //    OnChanged();
        //}

        //public void Add(Prodotto prodotto)
        //{
        //    _prodotti.Add(prodotto);
        //    OnChanged();
        //}

        //public void Add(Dipendente dipendente)
        //{
        //    IsAmministratore();
        //    _dipendenti.Add(dipendente);
        //    OnChanged();
        //}

        //#endregion

        //#region Document Removers

        //public void Remove(MovimentoDiDenaro movimento)
        //{
        //    _movimenti.Remove(movimento);
        //    OnChanged();
        //}

        //public void Remove(Fattura fattura)
        //{
        //    _fatture.Remove(fattura);
        //    OnChanged();
        //}

        //public void Remove(Soggetto soggetto)
        //{
        //    _soggetti.Remove(soggetto);
        //    OnChanged();
        //}

        //public void Remove(ContenitoreDiDenaro contenitore)
        //{
        //    _contenitoriDiDenaro.Remove(contenitore);
        //    OnChanged();
        //}

        //public void Remove(Prodotto prodotto)
        //{
        //    _prodotti.Remove(prodotto);
        //    OnChanged();
        //}

        //public void Remove(Dipendente dipendente)
        //{
        //    IsAmministratore();
        //    _dipendenti.Remove(dipendente);
        //    OnChanged();
        //}

        //#endregion

        #region Document properties

        public Dipendente UtenteConnesso
        {
            get { return _utenteConnesso; }
            set { _utenteConnesso = value; }
        }

        [NomeVisualizzato("Dipendenti")]
        public IList<Dipendente> Dipendenti 
        {
            get
            {
                if (_utenteConnesso!=null && _utenteConnesso.Ruolo != TipoDipendente.Amministratore) 
                    throw new InvalidOperationException("L'utente corrente non dispone dei privilegi di amministratore");
                return _dipendenti;
            }

        }

        [NomeVisualizzato("Movimenti")]
        public IList<MovimentoDiDenaro> Movimenti
        {
            get { return _movimenti; }
        }

        [NomeVisualizzato("Depositi")]
        public IList<ContenitoreDiDenaro> ContenitoriDiDenaro
        {
            get { return _contenitoriDiDenaro; }
        }

        public Cassa Cassa
        {
            get { return _cassa; }
        }

        [NomeVisualizzato("Fatture")]
        public IList<Fattura> Fatture
        {
            get { return _fatture; }
        }

        [NomeVisualizzato("Prodotti")]
        public IList<Prodotto> Prodotti
        {
            get { return _prodotti; }
        }

        [NomeVisualizzato("Soggetti")]
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

        public IEnumerable<FatturaVendita> GetFattureVendita()
        {
            return this.Fatture.OfType<FatturaVendita>();
        }

        public IEnumerable<FatturaAcquisto> GetFattureAcquisto()
        {
            return this.Fatture.OfType<FatturaAcquisto>();
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
