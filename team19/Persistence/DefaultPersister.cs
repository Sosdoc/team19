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
                
                MovimentoDiDenaro m1 = MovimentoFactory.CreatePagamentoAcquisto(_cassa, _fatture.FindFatturaAcquisto(DateTime.Now.Year,1003), DateTime.Now,
                   _dipendenti.FindByUsername("valerio"), "Tangente per avere un buon voto al progetto");
                MovimentoDiDenaro m2 = MovimentoFactory.CreateIncassoVendita(_fatture.FindFatturaVendita(DateTime.Now.Year,1), _cassa, DateTime.Now,
                    _dipendenti.FindByUsername("francesco"), "Incasso della vendita del programma");               
                MovimentoDiDenaro m3 = MovimentoFactory.CreateMovimentoInterno(_cassa, _contenitoriDiDenaro.FindCCBByIban("IT99678912345"), 
                    new Currency(1000m), DateTime.Now, _dipendenti.FindByUsername("aymen"), "Versamento soldi a caso");

                _movimenti.Add(m1);
                _movimenti.Add(m2);
                _movimenti.Add(m3);
                return _movimenti;
            }

            public Soggetti LoadSoggetti()
            {
                _soggetti = new Soggetti();
                Indirizzo i1 = new Indirizzo("Via Risorgimento", "2", "Bologna", "40100", "Bo", "Italia");
                Indirizzo i2 = new Indirizzo("Via Zamboni", "2", "Bologna", "40100", "Bo", "Italia");

                _soggetti.Add(new Cliente("Francesco Casimiro", "123/2145298","francesco.casimiro@studio.unibo.it","","CSMFNC89E16C214R",i2));
                _soggetti.Add(new Cliente("Valerio Pipolo", "123/2145928", "valerio.pipolo@studio.unibo.it", "", "PPLVLR90C27A877F", i2));
                _soggetti.Add(new Fornitore("Giuseppe Bellavia","123/4561029","giuseppe.bellavia@unibo.it","0764352056C",i1));
                _soggetti.Add(new Fornitore("Gabriele Zannoni","123/456817","gabriele.zannoni@unibo.it","3478920189E",i1));
                _soggetti.Add(new Cliente("Aymen Chakroun", "123/2389012", "aymen.chakroun@studio.unibo.it", "1289428590G", "CHKMNA85A22J213I", i2));
                return _soggetti;
            }

            public Fatture LoadFatture()
            {
                _fatture = new Fatture();
                FatturaAcquisto f1 = FatturaAcquisto.CreateFatturaAcquisto(_soggetti.FindFornitore("Giuseppe Bellavia"), DateTime.Now, 1003, new Currency(5000m));

                List<RigaFattura> righe = new List<RigaFattura>();
                righe.Add(new RigaFattura(10, _prodotti.FindByProductCode("PAL11400")));
                righe.Add(new RigaFattura(30, _prodotti.FindByProductCode("RAC00000")));

                FatturaVendita f2 = FatturaVendita.CreateFatturaVendita(_soggetti.FindCliente("Francesco Casimiro"), DateTime.Now, righe);
                FatturaVendita f3 = FatturaVendita.CreateFatturaVendita(_soggetti.FindCliente("Valerio Pipolo"), DateTime.Now, righe);

                _fatture.Add(f1);
                _fatture.Add(f2);
                _fatture.Add(f3);

                return _fatture;
            }

            public ContenitoriDiDenaro LoadContenitori()
            {
                _contenitoriDiDenaro = new ContenitoriDiDenaro();
                _contenitoriDiDenaro.Add(new ContoCorrenteBancario("IT00123456789", new Currency(10000m)));
                _contenitoriDiDenaro.Add(new ContoCorrenteBancario("IT99678912345", new Currency(30000m)));
                return _contenitoriDiDenaro;
            }

            public Prodotti LoadProdotti()
            {
                _prodotti = new Prodotti();
                _prodotti.Add(new Prodotto(new Currency(10m), "Palla", new CodiceProdotto("PAL11400")));
                _prodotti.Add(new Prodotto(new Currency(5m), "Racchetta", new CodiceProdotto("RAC00000")));
                return _prodotti;
            }

            public Dipendenti LoadDipendenti()
            {
                _dipendenti = new Dipendenti();

                _dipendenti.Add(new Dipendente("aymen", "12345", "Aymen", "Chakroun", TipoDipendente.Amministratore));
                _dipendenti.Add(new Dipendente("francesco", "12345", "Francesco", "Casimiro", TipoDipendente.Amministratore));
                _dipendenti.Add(new Dipendente("valerio", "12345", "Valerio", "Pipolo", TipoDipendente.Amministratore));
                _dipendenti.Add(new Dipendente("admin", "admin", "Amministratore", "Amministratore", TipoDipendente.Amministratore));
                _dipendenti.Add(new Dipendente("utente", "utente", "Utente", "Utente", TipoDipendente.Utente));

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
