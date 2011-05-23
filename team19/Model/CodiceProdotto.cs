using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    public class CodiceProdotto
    {
        private readonly string _letters;
        private readonly string _numbers;
        public string Codice
        {
            get
            {
                return _letters + _numbers;
            }
        }

        public CodiceProdotto(string letters, string numbers)
        {
            if (letters.Length != 3 || numbers.Length != 5)//Controllo lunghezza del codice
            {
                throw new ArgumentException("Codice non corretto:lunghezza non consentita");
            }
            foreach (char c in letters) //Controllo lettere maiuscole
            {
                if (Char.IsLower(c) || !Char.IsLetter(c))
                    throw new ArgumentException("Codice non corretto: sequenza di lettere errata");
            }
            foreach (char c in numbers)
            {
                if (!Char.IsDigit(c))
                    throw new ArgumentException("Codice non corretto: sequenza numerica errata");
            }
            _letters = letters;
            _numbers = numbers;
        }
        //    public CodiceProdotto(string code):this(letters,numbers)
        //    {
        //        if (code.Length != 8)
        //            throw new ArgumentException("Codice non corretto:lunghezza non consentita");
        //        string letters = code.Substring(0, 3);
        //        string numbers = code.Substring(3, 5);
        //      }
        public override string ToString()
        {
            return this.Codice;
        }
    }
}
