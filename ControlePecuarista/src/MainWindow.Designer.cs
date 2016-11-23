namespace ControlePecuarista
{
    partial class MainWindow
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
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opcoesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gastoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unidadeAnimalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoPastagemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.combustivelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pastagemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerarRelatorioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 24);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.treeView2);
            this.splitContainer3.Size = new System.Drawing.Size(449, 366);
            this.splitContainer3.SplitterDistance = 148;
            this.splitContainer3.TabIndex = 0;
            // 
            // treeView2
            // 
            this.treeView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView2.Location = new System.Drawing.Point(0, 0);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(148, 366);
            this.treeView2.TabIndex = 0;
            this.treeView2.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView2_NodeMouseDoubleClick);
            this.treeView2.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView2_NodeMouseDoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcoesToolStripMenuItem,
            this.iniciarToolStripMenuItem,
            this.gerarRelatorioToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(449, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Resize += new System.EventHandler(this.menuStrip1_Resize);
            // 
            // opcoesToolStripMenuItem
            // 
            this.opcoesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoToolStripMenuItem1,
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.sairToolStripMenuItem});
            this.opcoesToolStripMenuItem.Name = "opcoesToolStripMenuItem";
            this.opcoesToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.opcoesToolStripMenuItem.Text = "Opcoes";
            // 
            // novoToolStripMenuItem1
            // 
            this.novoToolStripMenuItem1.Image = global::ControlePecuarista.Resource1.ic_description_black_24dp_1x;
            this.novoToolStripMenuItem1.Name = "novoToolStripMenuItem1";
            this.novoToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.novoToolStripMenuItem1.Text = "Novo";
            this.novoToolStripMenuItem1.Click += new System.EventHandler(this.novoToolStripMenuItem1_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::ControlePecuarista.Resource1.ic_folder_black_24dp_1x;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Abrir";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(100, 6);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Image = global::ControlePecuarista.Resource1.ic_exit_to_app_black_24dp_1x;
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // iniciarToolStripMenuItem
            // 
            this.iniciarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoToolStripMenuItem,
            this.gastoToolStripMenuItem,
            this.unidadeAnimalToolStripMenuItem,
            this.tipoPastagemToolStripMenuItem,
            this.combustivelToolStripMenuItem,
            this.pastagemToolStripMenuItem});
            this.iniciarToolStripMenuItem.Name = "iniciarToolStripMenuItem";
            this.iniciarToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.iniciarToolStripMenuItem.Text = "Adicionar";
            // 
            // novoToolStripMenuItem
            // 
            this.novoToolStripMenuItem.Name = "novoToolStripMenuItem";
            this.novoToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.novoToolStripMenuItem.Text = "Maquinario";
            this.novoToolStripMenuItem.Click += new System.EventHandler(this.MaquinarioAdicioanr);
            // 
            // gastoToolStripMenuItem
            // 
            this.gastoToolStripMenuItem.Name = "gastoToolStripMenuItem";
            this.gastoToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.gastoToolStripMenuItem.Text = "Gasto";
            this.gastoToolStripMenuItem.Click += new System.EventHandler(this.GastoAdicionar);
            // 
            // unidadeAnimalToolStripMenuItem
            // 
            this.unidadeAnimalToolStripMenuItem.Name = "unidadeAnimalToolStripMenuItem";
            this.unidadeAnimalToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.unidadeAnimalToolStripMenuItem.Text = "Unidade Animal";
            this.unidadeAnimalToolStripMenuItem.Click += new System.EventHandler(this.UnidadeAnimalAdicionar);
            // 
            // tipoPastagemToolStripMenuItem
            // 
            this.tipoPastagemToolStripMenuItem.Name = "tipoPastagemToolStripMenuItem";
            this.tipoPastagemToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.tipoPastagemToolStripMenuItem.Text = "Tipo Pastagem";
            this.tipoPastagemToolStripMenuItem.Click += new System.EventHandler(this.TipoPastagemAdicionar);
            // 
            // combustivelToolStripMenuItem
            // 
            this.combustivelToolStripMenuItem.Name = "combustivelToolStripMenuItem";
            this.combustivelToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.combustivelToolStripMenuItem.Text = "Combustivel";
            this.combustivelToolStripMenuItem.Click += new System.EventHandler(this.CombustivelAdicionar);
            // 
            // pastagemToolStripMenuItem
            // 
            this.pastagemToolStripMenuItem.Name = "pastagemToolStripMenuItem";
            this.pastagemToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.pastagemToolStripMenuItem.Text = "Pastagem";
            this.pastagemToolStripMenuItem.Click += new System.EventHandler(this.PastagemAdicionar);
            // 
            // gerarRelatorioToolStripMenuItem
            // 
            this.gerarRelatorioToolStripMenuItem.Name = "gerarRelatorioToolStripMenuItem";
            this.gerarRelatorioToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.gerarRelatorioToolStripMenuItem.Text = "Gerar Relatorio";
            this.gerarRelatorioToolStripMenuItem.Click += new System.EventHandler(this.gerarRelatorioToolStripMenuItem_Click);
            // 
            // newFileDialog
            // 
            this.newFileDialog.DefaultExt = "cdp";
            this.newFileDialog.Filter = "Controle Pecuarista(*.cdp)|*";
            this.newFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.newFileOk);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "Controle Pecuarista (*.cdp)|*.cdp|Todos os arquivos (*.*)|*.*";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.loadFileOk);
            // 
            // MainWindow
            // 
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(449, 390);
            this.Controls.Add(this.splitContainer3);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.splitContainer3.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem iniciarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gastoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unidadeAnimalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opcoesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog newFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem novoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem gerarRelatorioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoPastagemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem combustivelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pastagemToolStripMenuItem;
    }
}

