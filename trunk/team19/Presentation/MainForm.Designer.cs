namespace Team19.Presentation

{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgdipendenti = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtcognome = new System.Windows.Forms.TextBox();
            this.txtnome = new System.Windows.Forms.TextBox();
            this.cmbruolo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.moneyGrid = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.fattureGrid = new System.Windows.Forms.DataGridView();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabRiepiloghi = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgdipendenti)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moneyGrid)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fattureGrid)).BeginInit();
            this.tabRiepiloghi.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabRiepiloghi);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(693, 433);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgdipendenti);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtcognome);
            this.tabPage1.Controls.Add(this.txtnome);
            this.tabPage1.Controls.Add(this.cmbruolo);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtpassword);
            this.tabPage1.Controls.Add(this.txtuser);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(685, 407);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dipendenti";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgdipendenti
            // 
            this.dgdipendenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdipendenti.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgdipendenti.Location = new System.Drawing.Point(3, 122);
            this.dgdipendenti.Name = "dgdipendenti";
            this.dgdipendenti.Size = new System.Drawing.Size(679, 282);
            this.dgdipendenti.TabIndex = 12;
            this.dgdipendenti.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgdipendenti_CellContentClick);
            this.dgdipendenti.SelectionChanged += new System.EventHandler(this.dgdipendenti_SelectionChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "ruolo:";
            // 
            // txtcognome
            // 
            this.txtcognome.Location = new System.Drawing.Point(268, 56);
            this.txtcognome.Name = "txtcognome";
            this.txtcognome.Size = new System.Drawing.Size(103, 20);
            this.txtcognome.TabIndex = 10;
            // 
            // txtnome
            // 
            this.txtnome.Location = new System.Drawing.Point(73, 49);
            this.txtnome.Name = "txtnome";
            this.txtnome.Size = new System.Drawing.Size(100, 20);
            this.txtnome.TabIndex = 9;
            // 
            // cmbruolo
            // 
            this.cmbruolo.FormattingEnabled = true;
            this.cmbruolo.Items.AddRange(new object[] {
            "Amministratore",
            "Utente"});
            this.cmbruolo.Location = new System.Drawing.Point(73, 90);
            this.cmbruolo.Name = "cmbruolo";
            this.cmbruolo.Size = new System.Drawing.Size(100, 21);
            this.cmbruolo.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(211, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "cognome:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "nome:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "password:";
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(268, 10);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(107, 20);
            this.txtpassword.TabIndex = 3;
            // 
            // txtuser
            // 
            this.txtuser.Location = new System.Drawing.Point(73, 14);
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(100, 20);
            this.txtuser.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "user:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.moneyGrid);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(685, 407);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Depositi";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // moneyGrid
            // 
            this.moneyGrid.AllowUserToOrderColumns = true;
            this.moneyGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.moneyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.moneyGrid.Location = new System.Drawing.Point(3, 3);
            this.moneyGrid.Name = "moneyGrid";
            this.moneyGrid.Size = new System.Drawing.Size(679, 401);
            this.moneyGrid.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(685, 407);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Clienti & Fornitori";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(685, 407);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Prodotti";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.fattureGrid);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(685, 407);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Fatture";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // fattureGrid
            // 
            this.fattureGrid.AllowUserToAddRows = false;
            this.fattureGrid.AllowUserToDeleteRows = false;
            this.fattureGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fattureGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fattureGrid.Location = new System.Drawing.Point(0, 0);
            this.fattureGrid.Name = "fattureGrid";
            this.fattureGrid.ReadOnly = true;
            this.fattureGrid.Size = new System.Drawing.Size(685, 407);
            this.fattureGrid.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(685, 407);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Movimenti";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabRiepiloghi
            // 
            this.tabRiepiloghi.Controls.Add(this.textBox1);
            this.tabRiepiloghi.Controls.Add(this.panel1);
            this.tabRiepiloghi.Location = new System.Drawing.Point(4, 22);
            this.tabRiepiloghi.Name = "tabRiepiloghi";
            this.tabRiepiloghi.Padding = new System.Windows.Forms.Padding(3);
            this.tabRiepiloghi.Size = new System.Drawing.Size(685, 407);
            this.tabRiepiloghi.TabIndex = 6;
            this.tabRiepiloghi.Text = "tabPage7";
            this.tabRiepiloghi.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(679, 100);
            this.panel1.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(179, 36);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(36, 18);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(85, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(36, 52);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(85, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 103);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(679, 301);
            this.textBox1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 433);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgdipendenti)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.moneyGrid)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fattureGrid)).EndInit();
            this.tabRiepiloghi.ResumeLayout(false);
            this.tabRiepiloghi.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.DataGridView moneyGrid;
        private System.Windows.Forms.DataGridView dgdipendenti;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtcognome;
        private System.Windows.Forms.TextBox txtnome;
        private System.Windows.Forms.ComboBox cmbruolo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView fattureGrid;
        private System.Windows.Forms.TabPage tabRiepiloghi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
    }
}