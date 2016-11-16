using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataPersistent;

namespace ControlePecuarista.src.Controls
{
    public partial class GastosUserControl : UserControl
    {
        private int currentID;
        private GastosDAO currentGastosDao;
        private Gastos currentGastos;

        private List<string> referentList;
        private MaquinarioDAO maquinarioDao;
        private UnidadeAnimalDAO unidadeAnimalDao;
        private CombustiveisDAO combustiveisDao;
        private PastagemDAO pastagemDao;






        public GastosUserControl(string id = null)
        {



            InitializeComponent();
            currentID = -1;
            currentGastosDao = new GastosDAO(MainWindow.currentPath);
            tipoComboBox.DataSource = Enum.GetValues(typeof(GastosType));

            maquinarioDao = new MaquinarioDAO(MainWindow.currentPath);
            unidadeAnimalDao = new UnidadeAnimalDAO(MainWindow.currentPath);
            combustiveisDao = new CombustiveisDAO(MainWindow.currentPath);
            pastagemDao = new PastagemDAO(MainWindow.currentPath);


            if (id != null)
            {
                currentID = int.Parse(id);
                currentGastos = currentGastosDao.selectById(currentID);
                nomeTextBox.Text = currentGastos.nome;
                tipoComboBox.SelectedIndex = (int) currentGastos.idCategoria;
                refreshList();
                referenteComboBox.SelectedIndex = (int) currentGastos.idRef - 1;
            }
        }


        private void selectedIndex(object sender, EventArgs e)
        {
            refreshList();

        }

        void refreshList() {
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

        private void button1_Click(object sender, EventArgs e)
        {
          throw new Exception();
            if (currentID != -1)
            {
              currentGastos.nome = nomeTextBox.Text ;
              currentGastos.idCategoria = tipoComboBox.SelectedIndex ;
              currentGastos.idRef = referenteComboBox.SelectedIndex;
              currentGastosDao.update(currentGastos);
            }
            else{
              currentGastos = new Gastos();
              currentGastos.nome = nomeTextBox.Text ;
              currentGastos.idCategoria = tipoComboBox.SelectedIndex ;
              currentGastos.idRef = referenteComboBox.SelectedIndex;
              currentGastosDao.insert(currentGastos);
            }
            MainWindow.updateTreeNodesAction();
            MessageBox.Show(this, "Pastagem adicionada com sucesso.");
            Dispose();
        }
    }
}
