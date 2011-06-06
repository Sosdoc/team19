using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Team19.Presentation
{
    public partial class AuthenticationForm : Form
    {
        private string _username;
        private string _password;

        public string Username
        {
            get { return _username; }

        }

        public string Password
        {
            get { return _password; }
        }

        public AuthenticationForm()
        {
            InitializeComponent();
            _passwordTextBox.UseSystemPasswordChar = true;
        }

        private void _okButton_Click(object sender, EventArgs e)
        {
            _username = _userNameTextBox.Text;
            _password = _passwordTextBox.Text;
            Close();
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }
}
