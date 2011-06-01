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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._dataGridView = new System.Windows.Forms.DataGridView();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._smallImageList = new System.Windows.Forms.ImageList(this.components);
            this._largeImageList = new System.Windows.Forms.ImageList(this.components);
            this._documentListView = new Team19.Presentation.DocumentListView();
            this.nuovoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.stampaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.modificaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aggiungiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rimuoviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.modificaToolStripMenuItem,
            this.toolStripMenuItem3});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(801, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this._documentListView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._dataGridView);
            this.splitContainer1.Size = new System.Drawing.Size(801, 447);
            this.splitContainer1.SplitterDistance = 267;
            this.splitContainer1.TabIndex = 4;
            // 
            // _dataGridView
            // 
            this._dataGridView.AllowUserToAddRows = false;
            this._dataGridView.AllowUserToDeleteRows = false;
            this._dataGridView.AllowUserToOrderColumns = true;
            this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataGridView.Location = new System.Drawing.Point(0, 0);
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.ReadOnly = true;
            this._dataGridView.Size = new System.Drawing.Size(530, 447);
            this._dataGridView.TabIndex = 3;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuovoToolStripMenuItem,
            this.apriToolStripMenuItem,
            this.salvaToolStripMenuItem,
            this.toolStripMenuItem2,
            this.stampaToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // _smallImageList
            // 
            this._smallImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_smallImageList.ImageStream")));
            this._smallImageList.TransparentColor = System.Drawing.Color.Transparent;
            this._smallImageList.Images.SetKeyName(0, "Prodotti");
            this._smallImageList.Images.SetKeyName(1, "Fatture");
            this._smallImageList.Images.SetKeyName(2, "Depositi");
            this._smallImageList.Images.SetKeyName(3, "Movimenti");
            this._smallImageList.Images.SetKeyName(4, "Soggetti");
            this._smallImageList.Images.SetKeyName(5, "Dipendenti");
            // 
            // _largeImageList
            // 
            this._largeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_largeImageList.ImageStream")));
            this._largeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this._largeImageList.Images.SetKeyName(0, "Fatture");
            this._largeImageList.Images.SetKeyName(1, "Depositi");
            this._largeImageList.Images.SetKeyName(2, "Prodotti");
            this._largeImageList.Images.SetKeyName(3, "Movimenti");
            this._largeImageList.Images.SetKeyName(4, "Soggetti");
            this._largeImageList.Images.SetKeyName(5, "Dipendenti");
            // 
            // _documentListView
            // 
            this._documentListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._documentListView.LargeImageList = this._largeImageList;
            this._documentListView.Location = new System.Drawing.Point(0, 0);
            this._documentListView.Name = "_documentListView";
            this._documentListView.Size = new System.Drawing.Size(267, 447);
            this._documentListView.SmallImageList = this._smallImageList;
            this._documentListView.TabIndex = 0;
            this._documentListView.View = System.Windows.Forms.View.LargeIcon;
            // 
            // nuovoToolStripMenuItem
            // 
            this.nuovoToolStripMenuItem.Name = "nuovoToolStripMenuItem";
            this.nuovoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nuovoToolStripMenuItem.Text = "&Nuovo";
            // 
            // apriToolStripMenuItem
            // 
            this.apriToolStripMenuItem.Name = "apriToolStripMenuItem";
            this.apriToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.apriToolStripMenuItem.Text = "&Apri";
            // 
            // salvaToolStripMenuItem
            // 
            this.salvaToolStripMenuItem.Name = "salvaToolStripMenuItem";
            this.salvaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.salvaToolStripMenuItem.Text = "&Salva";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
            // 
            // stampaToolStripMenuItem
            // 
            this.stampaToolStripMenuItem.Name = "stampaToolStripMenuItem";
            this.stampaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.stampaToolStripMenuItem.Text = "Stam&pa";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // modificaToolStripMenuItem
            // 
            this.modificaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aggiungiToolStripMenuItem,
            this.modificaToolStripMenuItem1,
            this.rimuoviToolStripMenuItem});
            this.modificaToolStripMenuItem.Name = "modificaToolStripMenuItem";
            this.modificaToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.modificaToolStripMenuItem.Text = "&Modifica";
            // 
            // aggiungiToolStripMenuItem
            // 
            this.aggiungiToolStripMenuItem.Name = "aggiungiToolStripMenuItem";
            this.aggiungiToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aggiungiToolStripMenuItem.Text = "Aggiungi";
            // 
            // modificaToolStripMenuItem1
            // 
            this.modificaToolStripMenuItem1.Name = "modificaToolStripMenuItem1";
            this.modificaToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.modificaToolStripMenuItem1.Text = "Modifica";
            // 
            // rimuoviToolStripMenuItem
            // 
            this.rimuoviToolStripMenuItem.Name = "rimuoviToolStripMenuItem";
            this.rimuoviToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.rimuoviToolStripMenuItem.Text = "Rimuovi";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem3.Text = "&?";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 471);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DocumentListView _documentListView;
        private System.Windows.Forms.DataGridView _dataGridView;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ImageList _smallImageList;
        private System.Windows.Forms.ImageList _largeImageList;
        private System.Windows.Forms.ToolStripMenuItem nuovoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem apriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salvaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem stampaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem modificaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aggiungiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rimuoviToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
    }
}