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
    public partial class PastagemUserControl : UserControl
    {
        private int currentID;
        private Pastagem currentPastagem;
        private PastagemDAO currentPastagemDao;
        private TipoPastagemDAO currentTipoPastagemDao;


        public PastagemUserControl(string id = null)
        {
            InitializeComponent();
            currentID = -1;
            currentPastagemDao = new PastagemDAO(MainWindow.currentPath);
            currentTipoPastagemDao = new TipoPastagemDAO(MainWindow.currentPath);
            tipoPastoComboBox.DataSource = currentTipoPastagemDao.selectIdAndString().Values.ToArray();

            if (id != null)
            {
                currentID = int.Parse(id);
                currentPastagem = currentPastagemDao.selectById(currentID);
                nomePastoTextBox.Text = currentPastagem.nome;
                areaUtilTextBox.Text = currentPastagem.areaUtil.ToString();
                tipoPastoComboBox.SelectedIndex = currentPastagem.tipoPastagemID;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (currentID != -1)//UPDATE
            {
                currentPastagem.nome = nomePastoTextBox.Text;
                currentPastagem.areaUtil = int.Parse(areaUtilTextBox.Text);
                currentPastagem.tipoPastagemID = tipoPastoComboBox.SelectedIndex;
            }
            else
            {
                var nome = nomePastoTextBox.Text;
                var areaUtil = float.Parse(areaUtilTextBox.Text);
                var tipoPastagemID = tipoPastoComboBox.SelectedIndex;
                currentPastagem = new Pastagem(nome, areaUtil, tipoPastagemID);
                currentPastagemDao.insert(currentPastagem);
            }
            MainWindow.updateTreeNodesAction();
            MessageBox.Show(this, "Pastagem adicionada com sucesso.");
            Dispose();
        }
    }
}
