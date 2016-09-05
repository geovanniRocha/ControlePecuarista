using Data_Persistent;
using System;
using System.Windows.Forms;
using ControlePecuarista.src;

namespace ControlePecuarista
{
    public partial class MainWindow : Form
    {
        DataStorage.ControlePecuarista controlePecuarista;

        public MainWindow(DataStorage.ControlePecuarista controlePecuarista)
        {
            this.controlePecuarista = controlePecuarista;

            InitializeComponent();
            
            }

        private void updateTreeNodes()
        {
            treeView2.Nodes.Clear();
            
            #region GastosNode

            var gastosNode = new TreeNode("Gastos");
            for (var i = 0; i < controlePecuarista.gastoList.Count; i++)
                gastosNode.Nodes.Insert(i, controlePecuarista.gastoList[i].nome);
            treeView2.Nodes.Add(gastosNode);

            #endregion GastosNode

            #region MaquinarioNode

            var maquinarioNode = new TreeNode("Maquinario");
            for (var i = 0; i < controlePecuarista.maquinarioList.Count; i++)
                maquinarioNode.Nodes.Insert(i, controlePecuarista.maquinarioList[i].nome);
            treeView2.Nodes.Add(maquinarioNode);

            #endregion MaquinarioNode

            #region CombustivelNode

            var combustivelNode = new TreeNode("Combustivel");
            for (var i = 0; i < controlePecuarista.combustivelList.Count; i++)
                combustivelNode.Nodes.Insert(i, controlePecuarista.combustivelList[i].nome);
            treeView2.Nodes.Add(combustivelNode);

            #endregion combustivelNode

            #region PastagemNode

            var pastagemNode = new TreeNode("Pastagem");
            for (var i = 0; i < controlePecuarista.pastagemList.Count; i++)
                pastagemNode.Nodes.Insert(i, controlePecuarista.pastagemList[i].nome);
            treeView2.Nodes.Add(pastagemNode);

            #endregion pastagemNode

            #region TipoPastagemNode

            var tipoPastagemNode = new TreeNode("Tipo de Pastagem");
            for (var i = 0; i < controlePecuarista.tipoPastagemList.Count; i++)
                tipoPastagemNode.Nodes.Insert(i, controlePecuarista.tipoPastagemList[i].nome);
            treeView2.Nodes.Add(tipoPastagemNode);

            #endregion tipoPastagemNode

            #region unidadeAnimalNode

            var unidadeAnimalNode = new TreeNode("Unidade Animal");
            for (var i = 0; i < controlePecuarista.unidadeAnimalList.Count; i++)
                unidadeAnimalNode.Nodes.Insert(i, controlePecuarista.unidadeAnimalList[i].nome);
            treeView2.Nodes.Add(unidadeAnimalNode);

            #endregion unidadeAnimalNode
            
        }
        
        #region Form Functions Handler

        private void Form2_Load(object sender, EventArgs e)
        {
            updateTreeNodes();
        }

        private void treeView2_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent == null)
                return;

            switch (e.Node.Parent.Text)
            {
                case @"Gastos":
                    Debug.instace.error(controlePecuarista.findGastoByID(e.Node.Index).ToString());
                    var temp1 = new UserControl1();
                    splitContainer3.Panel2.Controls.Clear();
                    splitContainer3.Panel2.Controls.Add(temp1);

                    break;
                case @"Maquinario":
                    Debug.instace.danger(controlePecuarista.maquinarioList[e.Node.Index].ToString());
                    var temp2 = new UserControl2();
                    splitContainer3.Panel2.Controls.Clear();
                    splitContainer3.Panel2.Controls.Add(temp2);
                    break;
                case @"Combustivel":
                    Debug.instace.nice(controlePecuarista.combustivelList[e.Node.Index].ToString());

                    break;
                case @"Pastagem":
                    Debug.instace.log(controlePecuarista.findPastagemByID(e.Node.Index).ToString());

                    break;
                case @"Tipo de Pastagem":
                    Debug.instace.log(controlePecuarista.findTipoPastagemByID(e.Node.Index).ToString());

                    break;
                case @"Unidade Animal":
                    Debug.instace.log(controlePecuarista.findUnidadeNAnimalByID(e.Node.Index).ToString());

                    break;
            }
           // Debug.instace.danger(DataStorage.jsonSerialize(controlePecuarista));



        }

        private void opcoesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.instace.error(sender.ToString());
        }


        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var a = DataStorage.jsonSerialize(controlePecuarista);
            DataStorage.writeFile(a, "huehe.txt");
        }
    }


    #endregion Form Functions Handler
}