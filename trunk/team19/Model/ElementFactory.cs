using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Team19.Model
{
    static class ElementFactory
    {
        #region Fatture

        [MetodoCreazione("FatturaVendita", new Type[] { typeof(ComboBox), typeof(DateTimePicker), typeof(TextBox) })]
        public static FatturaVendita CreateFatturaVendita(Cliente cliente, DateTime data, List<RigaFattura> elencoProdotti)
        {
            return FatturaVendita.CreateFatturaVendita(cliente, data, elencoProdotti);
        }

        [MetodoCreazione("FatturaAcquisto", new Type[] { typeof(ComboBox), typeof(DateTimePicker), typeof(TextBox), typeof(TextBox) })]
        public static FatturaAcquisto CreateFatturaAcquisto(Fornitore fornitore, DateTime data, int numero, Currency importo)
        {
            return FatturaAcquisto.CreateFatturaAcquisto(fornitore, data, numero, importo);
        }
        #endregion

        #region Soggetti
        [MetodoCreazione("Cliente", new Type[] { typeof(TextBox), typeof(TextBox), typeof(TextBox), typeof(TextBox), typeof(TextBox), typeof(TextBox) })]
        public static Cliente CreateCliente(string denominazione, string telefono, string email, string partitaIva, string codiceFiscale, Indirizzo indirizzo)
        {
            return new Cliente(denominazione, telefono, email, partitaIva, codiceFiscale, indirizzo);
        }

        [MetodoCreazione("Fornitore", new Type[] { typeof(TextBox), typeof(TextBox), typeof(TextBox), typeof(TextBox), typeof(TextBox), typeof(TextBox) })]
        public static Fornitore CreateFornitore(string denominazione, string telefono, string email, string partitaIva, Indirizzo indirizzo)
        {
            return new Fornitore(denominazione, telefono, email, partitaIva, indirizzo);
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
        public static MovimentoDiDenaro CreatePagamentoAcquisto(ISorgente sorgente, IDestinazione destinazione, DateTime data, string causale)
        {
            return MovimentoFactory.CreatePagamentoAcquisto(sorgente, destinazione, data, causale);
        }
        [MetodoCreazione("IncassoVendita", new Type[] { typeof(ComboBox), typeof(ComboBox), typeof(DateTimePicker), typeof(TextBox) })]
        public static MovimentoDiDenaro CreateIncassoVendita(FatturaVendita sorgente, IDestinazione destinazione, DateTime data, string causale)
        {
            return MovimentoFactory.CreateIncassoVendita(sorgente, destinazione, data, causale);
        }
        [MetodoCreazione("Prelievo", new Type[] { typeof(ComboBox), typeof(Label), typeof(TextBox), typeof(DateTimePicker), typeof(TextBox) })]
        public static MovimentoDiDenaro CreateMovimentoInterno(DepositoDiDenaro sorgente, Cassa destinazione, Currency importo, DateTime data, string causale)
        {
            return MovimentoFactory.CreateMovimentoInterno(sorgente, destinazione, importo, data, causale);
        }

        [MetodoCreazione("Versamento", new Type[] { typeof(Label), typeof(ComboBox), typeof(TextBox), typeof(DateTimePicker), typeof(TextBox) })]
        public static MovimentoDiDenaro CreateMovimentoInterno(Cassa sorgente, DepositoDiDenaro destinazione, string importo, string data, string causale)
        {
            return MovimentoFactory.CreateMovimentoInterno(sorgente, destinazione, Currency.ParseCurrency(importo), DateTime.Parse(data), causale);
        }

        [MetodoCreazione("Spostamento", new Type[] { typeof(ComboBox), typeof(ComboBox), typeof(TextBox), typeof(DateTimePicker), typeof(TextBox) })]
        public static MovimentoDiDenaro CreateMovimentoInterno(DepositoDiDenaro sorgente, DepositoDiDenaro destinazione, Currency importo, DateTime data, string causale)
        {
            return MovimentoFactory.CreateMovimentoInterno(sorgente, destinazione, importo, data, causale);
        }
        #endregion

        #region Prodotti

        [MetodoCreazione("Prodotto", new Type[] { typeof(TextBox), typeof(TextBox), typeof(TextBox) })]
        public static Prodotto CreateProdotto(Currency prezzo, string descrizione, CodiceProdotto codice)
        {
            return new Prodotto(prezzo, descrizione, codice);
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
        public static ContoCorrenteBancario createContoCorrente(string IBAN, Currency saldoIniziale)
        {
            return new ContoCorrenteBancario(IBAN, saldoIniziale);
        }


        #endregion

    }
}
