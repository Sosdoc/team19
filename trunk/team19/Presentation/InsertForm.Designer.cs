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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._subtypeCombo = new System.Windows.Forms.ComboBox();
            this._detailsBox = new System.Windows.Forms.GroupBox();
            this._detailsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._buttonPanel = new System.Windows.Forms.Panel();
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this._detailsBox.SuspendLayout();
            this._buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this._buttonPanel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this._detailsBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this._subtypeCombo, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.282208F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.71779F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(400, 356);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // _subtypeCombo
            // 
            this._subtypeCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this._subtypeCombo.FormattingEnabled = true;
            this._subtypeCombo.Location = new System.Drawing.Point(3, 3);
            this._subtypeCombo.Name = "_subtypeCombo";
            this._subtypeCombo.Size = new System.Drawing.Size(394, 21);
            this._subtypeCombo.TabIndex = 13;
            // 
            // _detailsBox
            // 
            this._detailsBox.AutoSize = true;
            this._detailsBox.Controls.Add(this._detailsPanel);
            this._detailsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._detailsBox.Location = new System.Drawing.Point(3, 29);
            this._detailsBox.Name = "_detailsBox";
            this._detailsBox.Size = new System.Drawing.Size(394, 286);
            this._detailsBox.TabIndex = 17;
            this._detailsBox.TabStop = false;
            // 
            // _detailsPanel
            // 
            this._detailsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._detailsPanel.Location = new System.Drawing.Point(3, 16);
            this._detailsPanel.Name = "_detailsPanel";
            this._detailsPanel.Size = new System.Drawing.Size(388, 267);
            this._detailsPanel.TabIndex = 0;
            // 
            // _buttonPanel
            // 
            this._buttonPanel.Controls.Add(this._okButton);
            this._buttonPanel.Controls.Add(this._cancelButton);
            this._buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._buttonPanel.Location = new System.Drawing.Point(3, 321);
            this._buttonPanel.Name = "_buttonPanel";
            this._buttonPanel.Size = new System.Drawing.Size(394, 32);
            this._buttonPanel.TabIndex = 18;
            // 
            // _okButton
            // 
            this._okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okButton.Location = new System.Drawing.Point(227, 6);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 1;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            // 
            // _cancelButton
            // 
            this._cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(313, 6);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 0;
            this._cancelButton.Text = "Annulla";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // InsertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(400, 356);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(200, 145);
            this.Name = "InsertForm";
            this.Text = "InsertForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this._detailsBox.ResumeLayout(false);
            this._buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox _subtypeCombo;
        private System.Windows.Forms.GroupBox _detailsBox;
        private System.Windows.Forms.FlowLayoutPanel _detailsPanel;
        private System.Windows.Forms.Panel _buttonPanel;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;





    }
}