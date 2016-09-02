using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data_Persistent;

namespace ControlePecuarista
{
    public partial class Form2 : Form
    {
        private DataStorage.ControlePecuarista controlePecuarista;
        public Form2(DataStorage.ControlePecuarista controlePecuarista)
        {
            this.controlePecuarista = controlePecuarista;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            var gastosNode = new TreeNode("Gastos");
            for (int i = 0; i < controlePecuarista.gastoList.Count; i++)
            {
                gastosNode.Nodes.Insert(i, controlePecuarista.gastoList[i].nome);
            }
            treeView2.Nodes.Add(gastosNode);
            
        }
    }
}
