namespace ControlePecuarista.src.Controls
{
    partial class PastagemUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nomePastoTextBox = new System.Windows.Forms.TextBox();
            this.areaUtilTextBox = new System.Windows.Forms.TextBox();
            this.tipoPastoComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome do Pasto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Área Util";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo do Pasto";
            // 
            // nomePastoTextBox
            // 
            this.nomePastoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nomePastoTextBox.Location = new System.Drawing.Point(83, 3);
            this.nomePastoTextBox.Name = "nomePastoTextBox";
            this.nomePastoTextBox.Size = new System.Drawing.Size(308, 20);
            this.nomePastoTextBox.TabIndex = 3;
            // 
            // areaUtilTextBox
            // 
            this.areaUtilTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.areaUtilTextBox.Location = new System.Drawing.Point(83, 29);
            this.areaUtilTextBox.Name = "areaUtilTextBox";
            this.areaUtilTextBox.Size = new System.Drawing.Size(308, 20);
            this.areaUtilTextBox.TabIndex = 4;
            // 
            // tipoPastoComboBox
            // 
            this.tipoPastoComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tipoPastoComboBox.FormattingEnabled = true;
            this.tipoPastoComboBox.Location = new System.Drawing.Point(83, 55);
            this.tipoPastoComboBox.Name = "tipoPastoComboBox";
            this.tipoPastoComboBox.Size = new System.Drawing.Size(308, 21);
            this.tipoPastoComboBox.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(316, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PastagemUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tipoPastoComboBox);
            this.Controls.Add(this.areaUtilTextBox);
            this.Controls.Add(this.nomePastoTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PastagemUserControl";
            this.Size = new System.Drawing.Size(394, 225);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nomePastoTextBox;
        private System.Windows.Forms.TextBox areaUtilTextBox;
        private System.Windows.Forms.ComboBox tipoPastoComboBox;
        private System.Windows.Forms.Button button1;
    }
}
