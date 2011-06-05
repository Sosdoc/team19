using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Team19.Model;

namespace Team19.Persistence
{
    class DefaultPersister : IDocumentPersister
    {
        public IDocumentLoader GetLoader()
        {
            return new DefaultLoader();
        }

        public void Save(Model.Document documento)
        {
            throw new NotImplementedException("Questo persister non salva i dati");
        }

        class DefaultLoader : IDocumentLoader
        {
            private Movimenti _movimenti;
            private ContenitoriDiDenaro _contenitoriDiDenaro;
            private Fatture _fatture;
            private Prodotti _prodotti; 
            private Soggetti _soggetti;
            private Dipendenti _dipendenti;
            private Cassa _cassa;

            public DefaultLoader()
            {
            }

            public Movimenti LoadMovimenti()
            {
                _movimenti = new Movimenti();
                
                MovimentoDiDenaro m1 = MovimentoFactory.CreatePagamentoAcquisto(_cassa, _fatture.OfType<FatturaAcquisto>().ElementAt(0), DateTime.Now,
                   _dipendenti.ElementAt(0), "asd");
                MovimentoDiDenaro m2 = MovimentoFactory.CreateIncassoVendita(_fatture.OfType<FatturaVendita>().ElementAt(0), _cassa, DateTime.Now,
                    _dipendenti.ElementAt(2), "asd");               
                MovimentoDiDenaro m3 = MovimentoFactory.CreateMovimentoInterno(_cassa, _contenitoriDiDenaro.OfType<ContoCorrenteBancario>().ElementAt(0), 
                    new Currency(1000m), DateTime.Now, 
                    _dipendenti.ElementAt(1), "loisd");

                _movimenti.Add(m1);
                _movimenti.Add(m2);
                _movimenti.Add(m3);
                return _movimenti;
            }

            public Soggetti LoadSoggetti()
            {
                _soggetti = new Soggetti();
                Indirizzo i = new Indirizzo("Via GianDomenico Puppa", "42", "Sucate", "02983", "MI", "Italia");
                Cliente c1 = new Cliente("Pinco Pallino", "0", "no", "8301", "PNCPLNlol", i);
                Fornitore fo1 = new Fornitore("Pallo Pinchino", "13109", "forse", "9329239", i);
                Soggetto cf = new Cliente("Soshito Nakakata", "6786796", "dfhskh", "jhjkhlJH", "hgkhgkjhG", i);
                Soggetto cf2 = new Fornitore("Soshito Nakakata", "6786796", "dfhskh", "jhjkhlJH", i);

                _soggetti.Add(fo1);
                _soggetti.Add(c1);
                _soggetti.Add(cf);
                _soggetti.Add(cf2);
                return _soggetti;
            }

            public Fatture LoadFatture()
            {
                _fatture = new Fatture();
                FatturaAcquisto f1 = FatturaAcquisto.CreateFatturaAcquisto(_soggetti.OfType<Fornitore>().First(), DateTime.Now, 1003, new Currency(10004.23m));
                RigaFattura riga1 = new RigaFattura(10, _prodotti.First());
                RigaFattura riga2 = new RigaFattura(320, _prodotti.First());
                List<RigaFattura> righe = new List<RigaFattura>();
                righe.Add(riga1);
                righe.Add(riga2);

                FatturaVendita f2 = FatturaVendita.CreateFatturaVendita(_soggetti.OfType<Cliente>().ElementAt(0), DateTime.Now, righe);
                FatturaVendita f3 = FatturaVendita.CreateFatturaVendita(_soggetti.OfType<Cliente>().ElementAt(0), DateTime.Now, righe);

                _fatture.Add(f1);
                _fatture.Add(f2);
                _fatture.Add(f3);
                return _fatture;
            }

            public ContenitoriDiDenaro LoadContenitori()
            {
                _contenitoriDiDenaro = new ContenitoriDiDenaro();
                ContoCorrenteBancario cc = new ContoCorrenteBancario("AOSIDJHOGIHAPI", new Currency(10000m));
                _contenitoriDiDenaro.Add(cc);
                return _contenitoriDiDenaro;
            }

            public Prodotti LoadProdotti()
            {
                _prodotti = new Prodotti();
                Prodotto p1 = new Prodotto(new Currency(10m), "palla", new CodiceProdotto("PAL11400"));
                _prodotti.Add(p1);
                return _prodotti;
            }

            public Dipendenti LoadDipendenti()
            {
                _dipendenti = new Dipendenti();

                _dipendenti.Add(new Dipendente("aymen2011", "12345", "aymen", "chakroun", TipoDipendente.Amministratore));
                _dipendenti.Add(new Dipendente("francesco2011", "12345", "francesco", "casimiro", TipoDipendente.Amministratore));
                _dipendenti.Add(new Dipendente("valerio2011", "12345", "valerio", "pipolo", TipoDipendente.Amministratore));
                _dipendenti.Add(new Dipendente("maria2011", "12345", "maria", "rosso", TipoDipendente.Utente));
                _dipendenti.Add(new Dipendente("elena2011", "12345", "elena", "vasilescu", TipoDipendente.Utente));

                return _dipendenti;
            }

            public Cassa LoadCassa()
            {
                _cassa = new Cassa(new Currency(10000.00m));
                return _cassa;
            }

        }
    }
}
