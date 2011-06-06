using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    class Movimenti : List<MovimentoDiDenaro>
    {
        public Movimenti()
            : base()
        { }

        public void Add(object obj)
        {
            if (obj is MovimentoDiDenaro)
                base.Add((MovimentoDiDenaro)obj);
        }

        public void Remove(object obj)
        {
            if (obj is MovimentoDiDenaro)
                base.Remove((MovimentoDiDenaro)obj);
        }
    }

    class Fatture : List<Fattura>
    {
        public Fatture()
            : base()
        { }

        public FatturaVendita FindFatturaVendita(int anno, int numero)
        {
            return (FatturaVendita)base.Find(fattura => fattura is FatturaVendita && (fattura.Data.Year.Equals(anno) && fattura.NumeroFattura.Equals(numero)));
        }

        public void Add(object obj)
        {
            if (obj is Fattura)
                base.Add((Fattura)obj);
        }

        public void Remove(object obj)
        {
            if (obj is Fattura)
                base.Remove((Fattura)obj);
        }
    }

    class Soggetti : List<Soggetto>
    {
        public Soggetti()
            : base()
        { }

        public Soggetto FindByName(string denominazione)
        {
            return base.Find(soggetto => soggetto.Denominazione.Equals(denominazione));
        }

        public Fornitore FindFornitore(string denominazione)
        {
            return (Fornitore)base.Find(fornitore => fornitore is Fornitore && fornitore.Denominazione.Equals(denominazione));
        }

        public Cliente FindCliente(string denominazione)
        {
            return (Cliente)base.Find(cliente => cliente is Cliente && cliente.Denominazione.Equals(denominazione));
        }

        public void Add(object obj)
        {
            if (obj is Soggetto)
                base.Add((Soggetto)obj);
        }

        public void Remove(object obj)
        {
            if (obj is Soggetto)
                base.Remove((Soggetto)obj);
        }
    }

    class Dipendenti : List<Dipendente>
    {
        public Dipendenti()
            : base()
        { }

        public Dipendente FindByUsername(string username)
        {
            return base.Find(dipendente => dipendente.Username.Equals(username));
        }

        public void Add(object obj)
        {
            if (obj is Dipendente)
                base.Add((Dipendente)obj);
        }

        public void Remove(object obj)
        {
            if (obj is Dipendente)
                base.Remove((Dipendente)obj);
        }
    }

    class Prodotti : List<Prodotto>
    {
        public Prodotti()
            : base()
        { }

        public Prodotto FindByProductCode(string codiceProdotto)
        {
            return base.Find(prodotto => prodotto.CodProdotto.Codice.Equals(prodotto.CodProdotto.Codice));
        }

        public void Add(Object obj)
        {
            if (obj is Prodotto)
                base.Add((Prodotto)obj);
        }

        public void Remove(Object obj)
        {
            if (obj is Prodotto)
                base.Remove((Prodotto)obj);
        }
    }

    class ContenitoriDiDenaro : List<DepositoDiDenaro>
    {
        public ContenitoriDiDenaro()
            : base()
        { }

        public ContoCorrenteBancario FindCCBByIban(string iban)
        {
            return (ContoCorrenteBancario)base.Find(deposito => deposito is ContoCorrenteBancario && deposito.Codice.Equals(iban));
        }

        public void Add(Object obj)
        {
            if (obj is DepositoDiDenaro)
                base.Add((DepositoDiDenaro)obj);
        }

        public void Remove(Object obj)
        {
            if (obj is DepositoDiDenaro)
                base.Add((DepositoDiDenaro)obj);
        }
    }
}
