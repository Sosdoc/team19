using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    /// <summary>
    /// Questo file definisce i contenitori utilizzati in Document, i contenitori definiscono dei metodi Add con parametro object poichè necessario per aggiungere un oggetto
    /// tramite reflection, evitando il problema di dover effettuare in modo dinamico un cast. Vengono anche definiti alcuni metodi di utilità per trovare degli oggetti.
    /// </summary>

    class Movimenti : List<MovimentoDiDenaro>
    {
        public static event EventHandler ItemChanged;
        public Movimenti()
            : base()
        { }

        public void Add(object obj)
        {
            if (obj is MovimentoDiDenaro)
                base.Add((MovimentoDiDenaro)obj);
            OnItemChanged();
        }

        public void Delete(int index)
        {
            base.RemoveAt(index);
            OnItemChanged();
        }
        protected virtual void OnItemChanged()
        {
            if (ItemChanged != null)
                ItemChanged(this, EventArgs.Empty);
        }

    }

    class Fatture : List<Fattura>
    {
        public static event EventHandler ItemChanged;
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
            OnItemChanged();
        }

        public void Delete(int index)
        {
            base.RemoveAt(index);
            OnItemChanged();
        }
        protected virtual void OnItemChanged()
        {
            if (ItemChanged != null)
                ItemChanged(this, EventArgs.Empty);
        }
    }

    class Soggetti : List<Soggetto>
    {
        public static event EventHandler ItemChanged;
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
            OnItemChanged();
        }

        public void Delete(int index)
        {
            base.RemoveAt(index);
            OnItemChanged();
        }
        protected virtual void OnItemChanged()
        {
            if (ItemChanged != null)
                ItemChanged(this, EventArgs.Empty);
        }
    }

    class Dipendenti : List<Dipendente>
    {
        public static event EventHandler ItemChanged;
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
            OnItemChanged();
        }

        public void Delete(int index)
        {
            base.RemoveAt(index);
            OnItemChanged();
        }
        protected virtual void OnItemChanged()
        {
            if (ItemChanged != null)
                ItemChanged(this, EventArgs.Empty);
        }
    }

    class Prodotti : List<Prodotto>
    {
        public static event EventHandler ItemChanged;
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
            OnItemChanged();
        }

        public void Delete(int index)
        {
            base.RemoveAt(index);
            OnItemChanged();
        }
        protected virtual void OnItemChanged()
        {
            if (ItemChanged != null)
                ItemChanged(this, EventArgs.Empty);
        }
    }

    class ContenitoriDiDenaro : List<DepositoDiDenaro>
    {
        public static event EventHandler ItemChanged;
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
            OnItemChanged();
        }

        public void Delete(int index)
        {
            base.RemoveAt(index);
            OnItemChanged();
        }
        protected virtual void OnItemChanged()
        {
            if (ItemChanged != null)
                ItemChanged(this, EventArgs.Empty);
        }
    }
}
