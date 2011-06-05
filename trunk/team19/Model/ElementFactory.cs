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
        public static FatturaVendita CreateFatturaVendita(Cliente cliente, DateTime data, List<RigaFattura> elencoProdotti)
        {
            return FatturaVendita.CreateFatturaVendita(cliente, data, elencoProdotti);
        }

        public static FatturaAcquisto CreateFatturaAcquisto(Fornitore fornitore, DateTime data, int numero, Currency importo)
        {
            return FatturaAcquisto.CreateFatturaAcquisto(fornitore, data, numero, importo);
        }
        #endregion

        #region Soggetti
        public static Cliente CreateCliente(string denominazione, string telefono, string email, string partitaIva, string codiceFiscale, Indirizzo indirizzo)
        {
            return new Cliente(denominazione, telefono, email, partitaIva, codiceFiscale, indirizzo);
        }

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
        public static MovimentoDiDenaro CreateMovimentoInterno(Cassa sorgente, DepositoDiDenaro destinazione, Currency importo, DateTime data, string causale)
        {
            return MovimentoFactory.CreateMovimentoInterno(sorgente, destinazione, importo, data, causale);
        }
        [MetodoCreazione("Spostamento", new Type[] { typeof(ComboBox), typeof(ComboBox), typeof(TextBox), typeof(DateTimePicker), typeof(TextBox) })]
        public static MovimentoDiDenaro CreateMovimentoInterno(DepositoDiDenaro sorgente, DepositoDiDenaro destinazione, Currency importo, DateTime data, string causale)
        {
            return MovimentoFactory.CreateMovimentoInterno(sorgente, destinazione, importo, data, causale);
        }
        #endregion

    }
}
