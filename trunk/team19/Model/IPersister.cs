using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    interface IDocumentPersister
    {
        IDocumentLoader GetLoader();
        void Save(Document documento);
    }

    interface IDocumentLoader
    {
        List<MovimentoDiDenaro> LoadMovimenti();
        List<Soggetto> LoadSoggetti();
        List<Fattura> LoadFatture();
        List<DepositoDiDenaro> LoadContenitori();
        List<Prodotto> LoadProdotti();
        List<Dipendente> LoadDipendenti();
        Cassa LoadCassa();
    }
}
