namespace Team19.Presentation
{
    partial class InsertForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._detailsBox = new System.Windows.Forms.GroupBox();
            this._buttonPanel = new System.Windows.Forms.Panel();
            this._cancelButton = new System.Windows.Forms.Button();
            this._okButton = new System.Windows.Forms.Button();
            this._subtypeCombo = new System.Windows.Forms.ComboBox();
            this._detailsPanel = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this._detailsBox.SuspendLayout();
            this._buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this._subtypeCombo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._buttonPanel);
            this.splitContainer1.Panel2.Controls.Add(this._detailsBox);
            this.splitContainer1.Size = new System.Drawing.Size(500, 407);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 0;
            // 
            // _detailsBox
            // 
            this._detailsBox.Controls.Add(this._detailsPanel);
            this._detailsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._detailsBox.Location = new System.Drawing.Point(0, 0);
            this._detailsBox.Name = "_detailsBox";
            this._detailsBox.Size = new System.Drawing.Size(500, 378);
            this._detailsBox.TabIndex = 0;
            this._detailsBox.TabStop = false;
            // 
            // _buttonPanel
            // 
            this._buttonPanel.Controls.Add(this._okButton);
            this._buttonPanel.Controls.Add(this._cancelButton);
            this._buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._buttonPanel.Location = new System.Drawing.Point(0, 343);
            this._buttonPanel.Name = "_buttonPanel";
            this._buttonPanel.Size = new System.Drawing.Size(500, 35);
            this._buttonPanel.TabIndex = 1;
            // 
            // _cancelButton
            // 
            this._cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._cancelButton.Location = new System.Drawing.Point(413, 9);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 0;
            this._cancelButton.Text = "Annulla";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _okButton
            // 
            this._okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._okButton.Location = new System.Drawing.Point(333, 9);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 1;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            // 
            // _subtypeCombo
            // 
            this._subtypeCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this._subtypeCombo.FormattingEnabled = true;
            this._subtypeCombo.Location = new System.Drawing.Point(0, 0);
            this._subtypeCombo.Name = "_subtypeCombo";
            this._subtypeCombo.Size = new System.Drawing.Size(500, 21);
            this._subtypeCombo.TabIndex = 0;
            // 
            // _detailsPanel
            // 
            this._detailsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._detailsPanel.Location = new System.Drawing.Point(3, 16);
            this._detailsPanel.Name = "_detailsPanel";
            this._detailsPanel.Size = new System.Drawing.Size(494, 359);
            this._detailsPanel.TabIndex = 0;
            // 
            // InsertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 407);
            this.Controls.Add(this.splitContainer1);
            this.Name = "InsertForm";
            this.Text = "InsertForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this._detailsBox.ResumeLayout(false);
            this._buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel _buttonPanel;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.GroupBox _detailsBox;
        private System.Windows.Forms.ComboBox _subtypeCombo;
        private System.Windows.Forms.FlowLayoutPanel _detailsPanel;
    }
}