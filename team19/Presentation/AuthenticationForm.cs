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

        public string Username
        {
            get { return _username; }
           
        }
        private string _password;

        public string Password
        {
            get { return _password; }
          
        }
        public AuthenticationForm()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _username = textBox1.Text;
            _password = textBox2.Text;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        
    }
}
