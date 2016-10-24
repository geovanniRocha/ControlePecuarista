
using System;
using System.IO;
using System.Windows.Forms;
using ControlePecuarista.src;

namespace ControlePecuarista
{
    public partial class MainWindow : Form
    {
        

        public MainWindow()
        {
            

            InitializeComponent();
            
            }

        private void updateTreeNodes()
        {
            treeView2.Nodes.Clear();
            
            #region GastosNode

            var gastosNode = new TreeNode("Gastos");
            treeView2.Nodes.Add(gastosNode);

            #endregion GastosNode

            #region MaquinarioNode

            var maquinarioNode = new TreeNode("Maquinario");

            #endregion MaquinarioNode

            #region CombustivelNode

            var combustivelNode = new TreeNode("Combustivel");

            #endregion combustivelNode

            #region PastagemNode

            var pastagemNode = new TreeNode("Pastagem");

            #endregion pastagemNode

            #region TipoPastagemNode

            var tipoPastagemNode = new TreeNode("Tipo de Pastagem");

            #endregion tipoPastagemNode

            #region unidadeAnimalNode

            var unidadeAnimalNode = new TreeNode("Unidade Animal");

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
                /*case @"Gastos":
                    Debug.error(controlePecuarista.findGastoByID(e.Node.Index).ToString());
                    var temp1 = new MaquinarioAdd(0);
                    splitContainer3.Panel2.Controls.Clear();
                    splitContainer3.Panel2.Controls.Add(temp1 );

                    break;
                case @"Maquinario":
                    Debug.danger(controlePecuarista.maquinarioList[e.Node.Index].ToString());
                    var temp2 = new UserControl2();
                    splitContainer3.Panel2.Controls.Clear();
                    splitContainer3.Panel2.Controls.Add(temp2);
                    break;
                case @"Combustivel":
                    Debug.nice(controlePecuarista.combustivelList[e.Node.Index].ToString());

                    break;
                case @"Pastagem":
                    Debug.log(controlePecuarista.findPastagemByID(e.Node.Index).ToString());

                    break;
                case @"Tipo de Pastagem":
                    Debug.log(controlePecuarista.findTipoPastagemByID(e.Node.Index).ToString());

                    break;
                case @"Unidade Animal":
                    Debug.log(controlePecuarista.findUnidadeNAnimalByID(e.Node.Index).ToString());

                    break;
                    */
                default:

                    break;
            }
           // Debug.instance.danger(DataStorage.jsonSerialize(controlePecuarista));



        }

        private void opcoesToolStripMenuItem_Click(object sender, EventArgs e)
        {
             
        }


        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            
        }
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void saveFileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            /*Stream stream = saveFileDialog1.OpenFile();
            var a = DataStorage.jsonSerialize(controlePecuarista);
            DataStorage.writeFile(stream, a, saveFileDialog1.FileName);*/
            
        }

        private void loadFileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Debug.nice("Load " + openFileDialog1.ToString());
            openFileDialog1.OpenFile();
        }

        private void novoToolStripMenuItem1_Click(object sender, EventArgs e) {
            saveFileDialog1.ShowDialog();
            Debug.log(saveFileDialog1.FileName);
        }
    }


    #endregion Form Functions Handler
}