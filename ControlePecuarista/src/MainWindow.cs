using ControlePecuarista.src;
using DataPersistent;
using DebugDLL;
using GeradorRelatorio;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using ControlePecuarista.src.Controls;

namespace ControlePecuarista
{
    public partial class MainWindow : Form
    {
        public static string currentPath;

        //using static to enable crossClass use.
        //Action to enable updateTreeNodes in others UserControlls
        //See MaquinarioUserControl onButtonClick for details
        public static Action updateTreeNodesAction;

        private CombustiveisDAO combustiveisDao;
        private MaquinarioDAO maquinarioDao;
        private PastagemDAO pastagemDao;
        private TipoPastagemDAO tipoPastagemDao;
        private GastosDAO gastosDao;
        private UnidadeAnimalDAO unidadeAnimalDao;
        private UserControl selectedUserControl = null;
        #region ctor
        public MainWindow()
        {
            currentPath = null;
            InitializeComponent();
            //set function to Action
            updateTreeNodesAction = updateTreeNodes;
            iniciarToolStripMenuItem.Enabled = false;
        }

        private void initDaos()
        {
            if (currentPath == null) return;
            maquinarioDao = new MaquinarioDAO(currentPath);
            combustiveisDao = new CombustiveisDAO(currentPath);
            pastagemDao = new PastagemDAO(currentPath);
            tipoPastagemDao = new TipoPastagemDAO(currentPath);
            gastosDao = new GastosDAO(currentPath);
            unidadeAnimalDao = new UnidadeAnimalDAO(currentPath);
        }
        #endregion


        #region Form Functions Handler

        #region Form

        private void Form2_Load(object sender, EventArgs e)
        {
            //updateTreeNodes();
        }

        #endregion Form

        #region treeView

        public void updateTreeNodes()
        {
            treeView2.Nodes.Clear();

            #region GastosNode

            var gastosNode = new TreeNode("Gastos");
            var selectedIdAndStringFromDb = gastosDao.selectIdAndString();
            foreach (var b in selectedIdAndStringFromDb)
            {
                gastosNode.Nodes.Add(b.Key + "", b.Value);
            }
            treeView2.Nodes.Add(gastosNode);

            #endregion GastosNode

            #region MaquinarioNode

            var maquinarioNode = new TreeNode("Maquinario");
            selectedIdAndStringFromDb = maquinarioDao.selectIdAndString();
            foreach (var b in selectedIdAndStringFromDb)
            {
                maquinarioNode.Nodes.Add(b.Key + "", b.Value);
            }
            treeView2.Nodes.Add(maquinarioNode);

            #endregion MaquinarioNode

            #region CombustivelNode

            var combustivelNode = new TreeNode("Combustivel");
            selectedIdAndStringFromDb = combustiveisDao.selectIdAndString();
            foreach (var b in selectedIdAndStringFromDb)
            {
                combustivelNode.Nodes.Add(b.Key + "", b.Value);
            }
            treeView2.Nodes.Add(combustivelNode);

            #endregion CombustivelNode

            #region PastagemNode

            var pastagemNode = new TreeNode("Pastagem");
            selectedIdAndStringFromDb = pastagemDao.selectIdAndString();
            foreach (var b in selectedIdAndStringFromDb)
            {
                pastagemNode.Nodes.Add(b.Key + "", b.Value);
            }
            treeView2.Nodes.Add(pastagemNode);

            #endregion PastagemNode

            #region TipoPastagemNode

            var tipoPastagemNode = new TreeNode("Tipo de Pastagem");
            selectedIdAndStringFromDb = tipoPastagemDao.selectIdAndString();
            foreach (var b in selectedIdAndStringFromDb)
            {
                tipoPastagemNode.Nodes.Add(b.Key + "", b.Value);
            }
            treeView2.Nodes.Add(tipoPastagemNode);

            #endregion TipoPastagemNode

            #region unidadeAnimalNode

            var unidadeAnimalNode = new TreeNode("Unidade Animal");
            selectedIdAndStringFromDb = unidadeAnimalDao.selectIdAndString();
            foreach (var b in selectedIdAndStringFromDb)
            {
                unidadeAnimalNode.Nodes.Add(b.Key + "", b.Value);
            }
            treeView2.Nodes.Add(unidadeAnimalNode);

            #endregion unidadeAnimalNode
        }

        private void treeView2_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent == null) return;
            splitContainer3.Panel2.Controls.Clear();

            switch (e.Node.Parent.Text)
            {
                case @"Gastos":
                    selectedUserControl = new GastosUserControl(e.Node.Name);
                    break;

                case @"Maquinario":

                    selectedUserControl = new MaquinarioUserControl(e.Node.Name);
                    break;

                case @"Combustivel":

                    break;

                case @"Pastagem":

                    break;

                case @"Tipo de Pastagem":
                    selectedUserControl = new TipoPastageUserControl(e.Node.Name);
                    break;

                case @"Unidade Animal":
                    selectedUserControl = new UnidadeAnimalUserControl(e.Node.Name);
                    break;
            }
            if (selectedUserControl != null)
            {
                selectedUserControl.Size = splitContainer3.Panel2.Size;
               splitContainer3.Panel2.Controls.Add(selectedUserControl);

            }

        }

        private void createDataBase()
        {
            maquinarioDao.createTable();
            combustiveisDao.createTable();
            gastosDao.createTable();
            pastagemDao.createTable();
            tipoPastagemDao.createTable();
            unidadeAnimalDao.createTable();
        }

        #endregion treeView

        #region MenuBar

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void loadFileOk(object sender, CancelEventArgs e)
        {
            currentPath = openFileDialog.FileName;
            initDaos();
            updateTreeNodes();
            iniciarToolStripMenuItem.Enabled = true;
        }

        private void novoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            newFileDialog.ShowDialog();
        }

        private void newFileOk(object sender, CancelEventArgs e)
        {
            currentPath = newFileDialog.FileName;
            initDaos();
            createDataBase();
            updateTreeNodes();
            iniciarToolStripMenuItem.Enabled = true;
            novoToolStripMenuItem1.Enabled = false;

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion MenuBar




        private void gerarRelatorioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var a = new HTMLBuilder();
            a.addButton("Maquinarios");
            a.initDiv("Maquinarios");
            a.addMaquinariosTable(maquinarioDao.selectEverything());
            a.endDiv();
            a.css();
            Debug.warning(a.toHTML());
        }

        #region Adicionar DropDow

        private void MaquinarioAdicioanr(object sender, EventArgs e)
        {
            var temp = new MaquinarioUserControl();
            splitContainer3.Panel2.Controls.Clear();
            splitContainer3.Panel2.Controls.Add(temp);
            temp.Size = splitContainer3.Panel2.Size;
        }

        private void GastoAdicionar(object sender, EventArgs e)
        {
            var temp = new GastosUserControl();
            splitContainer3.Panel2.Controls.Clear();
            splitContainer3.Panel2.Controls.Add(temp);
            temp.Size = splitContainer3.Panel2.Size;
        }

        private void UnidadeAnimalAdicionar(object sender, EventArgs e)
        {
            var temp = new UnidadeAnimalUserControl();
            splitContainer3.Panel2.Controls.Clear();
            splitContainer3.Panel2.Controls.Add(temp);
            temp.Size = splitContainer3.Panel2.Size;
        }
        #endregion

        private void menuStrip1_Resize(object sender, EventArgs e)
        {
            if (selectedUserControl != null)
                selectedUserControl.Size = splitContainer3.Panel2.Size;
        }
    }

    #endregion Form Functions Handler
}