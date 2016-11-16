using DataPersistent;
using System;
using System.Windows.Forms;

namespace ControlePecuarista.src.Controls
{
    public partial class CombustivelUserControl : UserControl {
        private Combustivel currentCombustivel;
        private readonly CombustiveisDAO currentCombustivelDao;
        private readonly int currentID;

        public CombustivelUserControl(string id = null) {
            InitializeComponent();
            currentID = -1;
            currentCombustivelDao = new CombustiveisDAO(MainWindow.currentPath);
            if (id != null)
            {
                currentID = int.Parse(id);
                currentCombustivel = currentCombustivelDao.selectById(currentID);
                nomeTextBox.Text = currentCombustivel.nome;
                descricaoTextBox.Text = currentCombustivel.descricao;
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            if (currentID != -1)
            {
                currentCombustivel.nome = nomeTextBox.Text;
                currentCombustivel.descricao = descricaoTextBox.Text;
                currentCombustivelDao.update(currentCombustivel);
            }
            else
            {
                var nome = nomeTextBox.Text;
                var descricao = descricaoTextBox.Text;

                currentCombustivel = new Combustivel(nome, descricao);
                currentCombustivelDao.insert(currentCombustivel);
            }
            MainWindow.updateTreeNodesAction();
            MessageBox.Show(this, "Combustivel adicionado com sucesso.");
            Dispose();
        }
    }
}
