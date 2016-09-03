using Data_Persistent;
using System;
using System.Windows.Forms;

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

        #region Form  Functions Handler

        private void Form2_Load(object sender, EventArgs e)
        {
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

            textBox1.Text = DataStorage.jsonSerialize(controlePecuarista);
        }

        private void treeView2_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent == null)
                return;
            if (e.Node.Parent.Text == @"Gastos")
                textBox1.Text = controlePecuarista.findGastoByID(e.Node.Index).ToString();
            if (e.Node.Parent.Text == @"Maquinario")
                textBox1.Text = controlePecuarista.findMaquinarioById(e.Node.Index).ToString();
        }

        private void opcoesToolStripMenuItem_Click(object sender, EventArgs e){}
    }

    #endregion Form  Functions Handler
}