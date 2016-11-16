using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataPersistent;

namespace ControlePecuarista.src.Controls
{
    public partial class TipoPastageUserControl : UserControl
    {
        private TipoPastagem currentTipoPastagem;
        private TipoPastagemDAO tipoPastagemDao = null;
        private int currentID;

        public TipoPastageUserControl(string id = null)
        {
            InitializeComponent();
            currentID = -1;
            tipoPastagemDao = new TipoPastagemDAO(MainWindow.currentPath);

            if (id != null)
            {
                currentID = int.Parse(id);
                currentTipoPastagem = tipoPastagemDao.selectById(int.Parse(id));
                textBox1.Text = currentTipoPastagem.nome;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentID != -1) // Update
            {
                if (tipoPastagemDao == null) DebugDLL.Debug.info("TipoPastagem Null");
                if (currentTipoPastagem == null) DebugDLL.Debug.info("currentTipoPastagem Null");
                currentTipoPastagem.nome = textBox1.Text;
                tipoPastagemDao.update(currentTipoPastagem);
            }
            else
            {
                currentTipoPastagem = new TipoPastagem(textBox1.Text);
                tipoPastagemDao.insert(currentTipoPastagem);
            }
            MainWindow.updateTreeNodesAction();
            MessageBox.Show(this, "Tipo de pastagem adicionado com sucesso.");
            Dispose();
        }
    }
}
