using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Team19.Model
{
    /// <summary>
    /// ElementFactory viene utilizzata per raggiungere facilmente tutti i metodi di creazione di oggetti. Ognuno dei metodi è contrassegnato con un attributo custom
    /// che indica il tipo di oggetto creato ed i tipi di controllo necessari per ottenere i parametri del metodo(TextBox per una stringa, ComboBox per riferimenti ad
    /// altri oggetti, DateTimePicker per DateTime, ecc.)
    /// </summary>
    static class ElementFactory
    {
        #region Fatture

        [MetodoCreazione("FatturaVendita", new Type[] { typeof(ComboBox), typeof(DateTimePicker), typeof(TextBox) })]
        public static FatturaVendita CreateFatturaVendita(Cliente cliente, string data, List<RigaFattura> elencoProdotti)
        {
            return FatturaVendita.CreateFatturaVendita(cliente, DateTime.Parse(data), elencoProdotti);
        }

        [MetodoCreazione("FatturaAcquisto", new Type[] { typeof(ComboBox), typeof(DateTimePicker), typeof(TextBox), typeof(TextBox) })]
        public static FatturaAcquisto CreateFatturaAcquisto(Fornitore fornitore, string data, string numero, string importo)
        {
            return FatturaAcquisto.CreateFatturaAcquisto(fornitore, DateTime.Parse(data) , Int32.Parse(numero), Currency.ParseCurrency(importo));
        }
        #endregion

        #region Soggetti
        [MetodoCreazione("Cliente", new Type[] { typeof(TextBox), typeof(TextBox), typeof(TextBox), typeof(TextBox), typeof(TextBox), typeof(TextBox) })]
        public static Cliente CreateCliente(string denominazione, string telefono, string email, string partitaIva, string codiceFiscale, string indirizzo)
        {
            return new Cliente(denominazione, telefono, email, partitaIva, codiceFiscale, new Indirizzo(indirizzo));
        }

        [MetodoCreazione("Fornitore", new Type[] { typeof(TextBox), typeof(TextBox), typeof(TextBox), typeof(TextBox), typeof(TextBox), typeof(TextBox) })]
        public static Fornitore CreateFornitore(string denominazione, string telefono, string email, string partitaIva, string indirizzo)
        {
            return new Fornitore(denominazione, telefono, email, partitaIva, new Indirizzo(indirizzo));
        }
        #endregion

        #region Movimenti
        public static MovimentoDiDenaro CreateInteresseBancario(DepositoDiDenaro deposito, double interesse, DateTime data, Dipendente dipendente, string causale)
        {
            throw new NotImplementedException();
        }

        public static MovimentoDiDenaro CreateSpesaBancaria(DepositoDiDenaro deposito, Currency importo, DateTime data, Dipendente dipendente, string causale)
        {
            throw new NotImplementedException();
        }
        [MetodoCreazione("PagamentoAcquisto", new Type[] { typeof(ComboBox), typeof(ComboBox), typeof(DateTimePicker), typeof(TextBox) })]
        public static MovimentoDiDenaro CreatePagamentoAcquisto(ContenitoreDiDenaro sorgente, FatturaAcquisto destinazione, string data, string causale)
        {
            return MovimentoFactory.CreatePagamentoAcquisto(sorgente, destinazione, DateTime.Parse(data), causale);
        }

        [MetodoCreazione("IncassoVendita", new Type[] { typeof(ComboBox), typeof(ComboBox), typeof(DateTimePicker), typeof(TextBox) })]
        public static MovimentoDiDenaro CreateIncassoVendita(FatturaVendita sorgente, ContenitoreDiDenaro destinazione, string data, string causale)
        {
            return MovimentoFactory.CreateIncassoVendita(sorgente, destinazione, DateTime.Parse(data), causale);
        }
        [MetodoCreazione("Prelievo", new Type[] { typeof(ComboBox), typeof(ComboBox), typeof(TextBox), typeof(DateTimePicker), typeof(TextBox) })]
        public static MovimentoDiDenaro CreateMovimentoInterno(DepositoDiDenaro sorgente, Cassa destinazione, string importo, string data, string causale)
        {
            return MovimentoFactory.CreateMovimentoInterno(sorgente, destinazione, Currency.ParseCurrency(importo), DateTime.Parse(data), causale);
        }

        [MetodoCreazione("Versamento", new Type[] { typeof(ComboBox), typeof(ComboBox), typeof(TextBox), typeof(DateTimePicker), typeof(TextBox) })]
        public static MovimentoDiDenaro CreateMovimentoInterno(Cassa sorgente, DepositoDiDenaro destinazione, string importo, string data, string causale)
        {
            return MovimentoFactory.CreateMovimentoInterno(sorgente, destinazione, Currency.ParseCurrency(importo), DateTime.Parse(data), causale);
        }

        [MetodoCreazione("Spostamento", new Type[] { typeof(ComboBox), typeof(ComboBox), typeof(TextBox), typeof(DateTimePicker), typeof(TextBox) })]
        public static MovimentoDiDenaro CreateMovimentoInterno(DepositoDiDenaro sorgente, DepositoDiDenaro destinazione, string importo, string data, string causale)
        {
            return MovimentoFactory.CreateMovimentoInterno(sorgente, destinazione, Currency.ParseCurrency(importo), DateTime.Parse(data), causale);
        }
        #endregion

        #region Prodotti

        [MetodoCreazione("Prodotto", new Type[] { typeof(TextBox), typeof(TextBox), typeof(TextBox) })]
        public static Prodotto CreateProdotto(string prezzo, string descrizione, string codice)
        {
            return new Prodotto(Currency.ParseCurrency(prezzo) , descrizione, new CodiceProdotto(codice));
        }

        #endregion

        #region Dipendenti
        [MetodoCreazione("Dipendente", new Type[] { typeof(TextBox), typeof(TextBox), typeof(TextBox), typeof(TextBox), typeof(ComboBox) })]
        public static Dipendente createDipendente(string username, string password, string nome, string cognome, TipoDipendente ruolo)
        {
            return new Dipendente(username, password, nome, cognome, ruolo);
        }
        #endregion

        #region Contenitori di denaro
        [MetodoCreazione("ContoCorrenteBancario", new Type[] { typeof(TextBox), typeof(TextBox)})]
        public static ContoCorrenteBancario createContoCorrente(string IBAN, string saldoIniziale)
        {
            return new ContoCorrenteBancario(IBAN, Currency.ParseCurrency(saldoIniziale));
        }


        #endregion

    }
}
