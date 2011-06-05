using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    class Movimenti : List<MovimentoDiDenaro>
    {
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
