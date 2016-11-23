namespace ControlePecuarista.src
{
    partial class GeradorRelatorioWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.gastoCheckBox = new System.Windows.Forms.CheckBox();
            this.maquinariosCheckBox = new System.Windows.Forms.CheckBox();
            this.UAcheckBox = new System.Windows.Forms.CheckBox();
            this.pastagemCheckBox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Relatorios a gerar";
            // 
            // gastoCheckBox
            // 
            this.gastoCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gastoCheckBox.AutoSize = true;
            this.gastoCheckBox.Location = new System.Drawing.Point(16, 29);
            this.gastoCheckBox.Name = "gastoCheckBox";
            this.gastoCheckBox.Size = new System.Drawing.Size(59, 17);
            this.gastoCheckBox.TabIndex = 1;
            this.gastoCheckBox.Text = "Gastos";
            this.gastoCheckBox.UseVisualStyleBackColor = true;
            // 
            // maquinariosCheckBox
            // 
            this.maquinariosCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maquinariosCheckBox.AutoSize = true;
            this.maquinariosCheckBox.Location = new System.Drawing.Point(16, 52);
            this.maquinariosCheckBox.Name = "maquinariosCheckBox";
            this.maquinariosCheckBox.Size = new System.Drawing.Size(83, 17);
            this.maquinariosCheckBox.TabIndex = 2;
            this.maquinariosCheckBox.Text = "Maquinarios";
            this.maquinariosCheckBox.UseVisualStyleBackColor = true;
            // 
            // UAcheckBox
            // 
            this.UAcheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UAcheckBox.AutoSize = true;
            this.UAcheckBox.Location = new System.Drawing.Point(16, 75);
            this.UAcheckBox.Name = "UAcheckBox";
            this.UAcheckBox.Size = new System.Drawing.Size(100, 17);
            this.UAcheckBox.TabIndex = 3;
            this.UAcheckBox.Text = "Unidade Animal";
            this.UAcheckBox.UseVisualStyleBackColor = true;
            // 
            // pastagemCheckBox
            // 
            this.pastagemCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pastagemCheckBox.AutoSize = true;
            this.pastagemCheckBox.Location = new System.Drawing.Point(16, 98);
            this.pastagemCheckBox.Name = "pastagemCheckBox";
            this.pastagemCheckBox.Size = new System.Drawing.Size(73, 17);
            this.pastagemCheckBox.TabIndex = 5;
            this.pastagemCheckBox.Text = "Pastagem";
            this.pastagemCheckBox.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(229, 274);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Gerar Relatorio";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "HTML (*.html)|*.html|Todos os arquivos (*.*)|*.*";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // GeradorRelatorioWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 309);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pastagemCheckBox);
            this.Controls.Add(this.UAcheckBox);
            this.Controls.Add(this.maquinariosCheckBox);
            this.Controls.Add(this.gastoCheckBox);
            this.Controls.Add(this.label1);
            this.Name = "GeradorRelatorioWindow";
            this.Text = "GeradorRelatorioWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox gastoCheckBox;
        private System.Windows.Forms.CheckBox maquinariosCheckBox;
        private System.Windows.Forms.CheckBox UAcheckBox;
        private System.Windows.Forms.CheckBox pastagemCheckBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}