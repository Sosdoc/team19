namespace Team19.Presentation
{
    partial class FormRiepilogo
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
            this._soggettiCombo = new System.Windows.Forms.ComboBox();
            this._riepilogoDataGrid = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this._checkPagate = new System.Windows.Forms.CheckBox();
            this._checkNonPagate = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._riepilogoDataGrid)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this._soggettiCombo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._riepilogoDataGrid, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.017544F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.98245F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(421, 359);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // _soggettiCombo
            // 
            this._soggettiCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this._soggettiCombo.FormattingEnabled = true;
            this._soggettiCombo.Location = new System.Drawing.Point(3, 3);
            this._soggettiCombo.Name = "_soggettiCombo";
            this._soggettiCombo.Size = new System.Drawing.Size(415, 21);
            this._soggettiCombo.TabIndex = 0;
            // 
            // _riepilogoDataGrid
            // 
            this._riepilogoDataGrid.AllowUserToAddRows = false;
            this._riepilogoDataGrid.AllowUserToDeleteRows = false;
            this._riepilogoDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._riepilogoDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._riepilogoDataGrid.Location = new System.Drawing.Point(3, 26);
            this._riepilogoDataGrid.Name = "_riepilogoDataGrid";
            this._riepilogoDataGrid.ReadOnly = true;
            this._riepilogoDataGrid.Size = new System.Drawing.Size(415, 300);
            this._riepilogoDataGrid.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this._checkPagate);
            this.flowLayoutPanel1.Controls.Add(this._checkNonPagate);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 332);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(415, 24);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // _checkPagate
            // 
            this._checkPagate.AutoSize = true;
            this._checkPagate.Dock = System.Windows.Forms.DockStyle.Left;
            this._checkPagate.Location = new System.Drawing.Point(3, 3);
            this._checkPagate.Name = "_checkPagate";
            this._checkPagate.Size = new System.Drawing.Size(60, 17);
            this._checkPagate.TabIndex = 0;
            this._checkPagate.Text = "Pagate";
            this._checkPagate.UseVisualStyleBackColor = true;
            // 
            // _checkNonPagate
            // 
            this._checkNonPagate.AutoSize = true;
            this._checkNonPagate.Dock = System.Windows.Forms.DockStyle.Left;
            this._checkNonPagate.Location = new System.Drawing.Point(69, 3);
            this._checkNonPagate.Name = "_checkNonPagate";
            this._checkNonPagate.Size = new System.Drawing.Size(83, 17);
            this._checkNonPagate.TabIndex = 1;
            this._checkNonPagate.Text = "Non Pagate";
            this._checkNonPagate.UseVisualStyleBackColor = true;
            // 
            // FormRiepilogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 359);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormRiepilogo";
            this.Text = "FormRiepilogo";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._riepilogoDataGrid)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox _soggettiCombo;
        private System.Windows.Forms.DataGridView _riepilogoDataGrid;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox _checkPagate;
        private System.Windows.Forms.CheckBox _checkNonPagate;
    }
}