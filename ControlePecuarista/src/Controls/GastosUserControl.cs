using DataPersistent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ControlePecuarista.src.Controls
{
    public partial class GastosUserControl : UserControl {
        private readonly CombustiveisDAO combustiveisDao;
        private Gastos currentGastos;
        private readonly GastosDAO currentGastosDao;
        private readonly int currentID;
        private GastosDAO gastosDao;
        private readonly MaquinarioDAO maquinarioDao;
        private readonly PastagemDAO pastagemDao;

        private List<string> referentList;
        private readonly UnidadeAnimalDAO unidadeAnimalDao;

        public GastosUserControl(string id = null) {
            InitializeComponent();

            currentID = -1;
            currentGastosDao = new GastosDAO(MainWindow.currentPath);
            tipoComboBox.DataSource = Enum.GetValues(typeof(GastosType));

            maquinarioDao = new MaquinarioDAO(MainWindow.currentPath);
            unidadeAnimalDao = new UnidadeAnimalDAO(MainWindow.currentPath);
            combustiveisDao = new CombustiveisDAO(MainWindow.currentPath);
            pastagemDao = new PastagemDAO(MainWindow.currentPath);
            gastosDao = new GastosDAO(MainWindow.currentPath);
            tipoComboBox.SelectedIndex = -1;
            button2.Enabled = false;
            if (id != null)
            {
                currentID = int.Parse(id);
                currentGastos = currentGastosDao.selectById(currentID);
                nomeTextBox.Text = currentGastos.nome;
                tipoComboBox.SelectedIndex = (int) currentGastos.idCategoria;
                refreshList();
                if (tipoComboBox.SelectedIndex > 0) referenteComboBox.SelectedIndex = currentGastos.idRef - 1;
                else referenteComboBox.SelectedIndex = -1;
                button2.Enabled = true;
            }
        }

        private void selectedIndex(object sender, EventArgs e) {
            refreshList();
        }

        private void refreshList() {
            if (tipoComboBox.SelectedIndex == -1) return;
            switch (tipoComboBox.SelectedIndex)
            {
                case 0:
                    // DebugDLL.Debug.debug("Maq");
                    referentList = maquinarioDao.selectIdAndString().Values.ToList();
                    break;

                case 1:
                    //  DebugDLL.Debug.debug("Comb");
                    referentList = combustiveisDao.selectIdAndString().Values.ToList();
                    break;

                case 2:
                    // DebugDLL.Debug.debug("Past");
                    referentList = pastagemDao.selectIdAndString().Values.ToList();
                    break;

                case 3:
                    // DebugDLL.Debug.debug("UA");
                    referentList = unidadeAnimalDao.selectIdAndString().Values.ToList();
                    break;

                case 4:
                    // DebugDLL.Debug.debug("Outros");
                    referentList = new List<string>();
                    referentList.Add("Outros");
                    break;
            }
            referenteComboBox.DataSource = referentList;
        }

        private void button1_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(nomeTextBox.Text))
            {
                MessageBox.Show(this, "Insira um nome para identificar o gasto.");
            }
            else
            {
                //throw new Exception();
                if (currentID != -1)
                {
                    currentGastos.nome = nomeTextBox.Text;
                    currentGastos.idCategoria = (GastosType) tipoComboBox.SelectedIndex;
                    currentGastos.idRef = referenteComboBox.SelectedIndex + 1;
                    currentGastos.descricao = descricaoTextBox3.Text;
                    currentGastosDao.update(currentGastos);
                }
                else
                {
                    currentGastos = new Gastos();
                    currentGastos.nome = nomeTextBox.Text;
                    currentGastos.idCategoria = (GastosType) tipoComboBox.SelectedIndex;
                    currentGastos.idRef = referenteComboBox.SelectedIndex + 1;
                    currentGastos.descricao = descricaoTextBox3.Text;
                    currentGastosDao.insert(currentGastos);
                }
                MainWindow.updateTreeNodesAction();
                MessageBox.Show(this, "Gasto adicionado com sucesso.");
                Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DatalheGastosWindow windows =  new DatalheGastosWindow(currentID);
            windows.Show();
            
        }
    }
}