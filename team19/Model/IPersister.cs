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
        Movimenti LoadMovimenti();
        Soggetti LoadSoggetti();
        Fatture LoadFatture();
        ContenitoriDiDenaro LoadContenitori();
        Prodotti LoadProdotti();
        Dipendenti LoadDipendenti();
        Cassa LoadCassa();
    }
}
