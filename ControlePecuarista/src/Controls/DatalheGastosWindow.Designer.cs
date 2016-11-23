namespace ControlePecuarista.src.Controls
{
    partial class DatalheGastosWindow
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
            this.arrobaEntradaTextBox = new System.Windows.Forms.TextBox();
            this.arrobaSaidaTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.detalhesRichTextBox = new System.Windows.Forms.RichTextBox();
            this.totalGasto = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // arrobaEntradaTextBox
            // 
            this.arrobaEntradaTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.arrobaEntradaTextBox.Location = new System.Drawing.Point(152, 17);
            this.arrobaEntradaTextBox.Name = "arrobaEntradaTextBox";
            this.arrobaEntradaTextBox.Size = new System.Drawing.Size(149, 20);
            this.arrobaEntradaTextBox.TabIndex = 0;
            this.arrobaEntradaTextBox.Leave += new System.EventHandler(this.arrobaEntradaTextBoxLeave);
            // 
            // arrobaSaidaTextBox
            // 
            this.arrobaSaidaTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.arrobaSaidaTextBox.Location = new System.Drawing.Point(152, 45);
            this.arrobaSaidaTextBox.Name = "arrobaSaidaTextBox";
            this.arrobaSaidaTextBox.Size = new System.Drawing.Size(149, 20);
            this.arrobaSaidaTextBox.TabIndex = 1;
            this.arrobaSaidaTextBox.Leave += new System.EventHandler(this.arrobaSaidaTextBoxLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Valor do arroba de entrada";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Valor do arroba de saida";
            // 
            // detalhesRichTextBox
            // 
            this.detalhesRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detalhesRichTextBox.Location = new System.Drawing.Point(16, 112);
            this.detalhesRichTextBox.Name = "detalhesRichTextBox";
            this.detalhesRichTextBox.Size = new System.Drawing.Size(285, 199);
            this.detalhesRichTextBox.TabIndex = 4;
            this.detalhesRichTextBox.Text = "";
            // 
            // totalGasto
            // 
            this.totalGasto.AutoSize = true;
            this.totalGasto.Location = new System.Drawing.Point(13, 71);
            this.totalGasto.Name = "totalGasto";
            this.totalGasto.Size = new System.Drawing.Size(68, 13);
            this.totalGasto.TabIndex = 5;
            this.totalGasto.Text = "Total Gasto: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Detalhes";
            // 
            // DatalheGastosWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 323);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.totalGasto);
            this.Controls.Add(this.detalhesRichTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.arrobaSaidaTextBox);
            this.Controls.Add(this.arrobaEntradaTextBox);
            this.Name = "DatalheGastosWindow";
            this.Text = "DatalheGastosWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox arrobaEntradaTextBox;
        private System.Windows.Forms.TextBox arrobaSaidaTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox detalhesRichTextBox;
        private System.Windows.Forms.Label totalGasto;
        private System.Windows.Forms.Label label3;
    }
}