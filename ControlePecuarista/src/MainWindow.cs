
using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ControlePecuarista.src;


namespace ControlePecuarista
{
    public partial class MainWindow : Form
    {

        public static string currentPath;
        private DataPersistent.MaquinarioDAO maquinarioDao;
        private DataPersistent.CombustiveisDAO combustiveisDao;

        //using static to enable crossClass use.
        //Action to enable updateTreeNodes in others UserControlls
        //See MaquinarioUserControl onButtonClick for details
        public static Action updateTreeNodesAction;

        public MainWindow()
        {
            currentPath = null;
            InitializeComponent();
            //set function to Action
            updateTreeNodesAction = updateTreeNodes;
            iniciarToolStripMenuItem.Enabled = false;

        }

        void initDaos()
        {
            if (currentPath == null) return;
            maquinarioDao = new DataPersistent.MaquinarioDAO(currentPath);
            combustiveisDao = new DataPersistent.CombustiveisDAO(currentPath);
        }


        #region Form Functions Handler

        #region Form
        private void Form2_Load(object sender, EventArgs e)
        {
            //updateTreeNodes();
        }
        #endregion

        #region treeView

        public void updateTreeNodes()
        {
            treeView2.Nodes.Clear();

            #region GastosNode

            var gastosNode = new TreeNode("Gastos");
            treeView2.Nodes.Add(gastosNode);

            #endregion GastosNode

            #region MaquinarioNode

            var maquinarioNode = new TreeNode("Maquinario");
            var selectedIdAndStringFromDb = maquinarioDao.selectIdAndString();
            foreach (var b in selectedIdAndStringFromDb)
            {
                maquinarioNode.Nodes.Add(b.Key + "", b.Value);
            }
            treeView2.Nodes.Add(maquinarioNode);


            #endregion MaquinarioNode

            #region CombustivelNode

            var combustivelNode = new TreeNode("Combustivel");
            treeView2.Nodes.Add(combustivelNode);

            #endregion combustivelNode

            #region PastagemNode

            var pastagemNode = new TreeNode("Pastagem");
            treeView2.Nodes.Add(pastagemNode);

            #endregion pastagemNode

            #region TipoPastagemNode

            var tipoPastagemNode = new TreeNode("Tipo de Pastagem");
            treeView2.Nodes.Add(tipoPastagemNode);

            #endregion tipoPastagemNode

            #region unidadeAnimalNode

            var unidadeAnimalNode = new TreeNode("Unidade Animal");
            treeView2.Nodes.Add(unidadeAnimalNode);

            #endregion unidadeAnimalNode

        }

        private void treeView2_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {


            if (e.Node.Parent == null)
                return;

            switch (e.Node.Parent.Text)
            {

                case @"Gastos":

                    var temp2 = new Gastos();
                    splitContainer3.Panel2.Controls.Clear();
                    splitContainer3.Panel2.Controls.Add(temp2);

                    break;

                case @"Maquinario":
                   
                    var temp1 = new MaquinarioUserControl(e.Node.Name);
                    splitContainer3.Panel2.Controls.Clear();
                    splitContainer3.Panel2.Controls.Add(temp1);
                    break;

                case @"Combustivel":


                    break;
                case @"Pastagem":


                    break;
                case @"Tipo de Pastagem":


                    break;
                case @"Unidade Animal":


                    break;


            }
            // Debug.instance.danger(DataStorage.jsonSerialize(controlePecuarista));


        }

        private void createDataBase()
        {
            maquinarioDao.createTable();
            combustiveisDao.createTable();
        }

        #endregion

        #region  MenuBar


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }
        private void loadFileOk(object sender, System.ComponentModel.CancelEventArgs e)
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

        }

       

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }


        #endregion


    }


    #endregion Form Functions Handler


}