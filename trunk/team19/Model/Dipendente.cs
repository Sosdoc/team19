using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team19.Model
{
    public class Dipendente
    {
        private string _username;
        private string _password;
        private string _cognome;
        private string _nome;

        public Dipendente(string username, string password, string cognome, string nome)
        {
            this._username = username;
            this._password = password;
            this._cognome = cognome;
            this._nome = nome;
        }

        public string Username
        {
            get { return _username; }
        }
        public string Password
        {
            get { return _password; }
        }
        public string Nome
        {
            get { return _nome; }
        }
        public string Cognome
        {
            get { return _cognome; }
        }
        
    }
}
