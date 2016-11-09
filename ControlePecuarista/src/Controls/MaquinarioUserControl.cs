using DataPersistent;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ControlePecuarista.src
{
    public partial class MaquinarioUserControl : UserControl
    {
        private int currentID;
        private Maquinario currentMaquinario;
        private MaquinarioDAO maquinarioDao;
        private CombustiveisDAO combustiveisDao;

        public MaquinarioUserControl(string id = null)
        {
            InitializeComponent();
            currentID = -1;
            maquinarioDao = new MaquinarioDAO(MainWindow.currentPath);
            combustiveisDao = new CombustiveisDAO(MainWindow.currentPath);
            comboBox1.DataSource = combustiveisDao.selectIdAndString().Values.ToArray();

            if (id != null)
            {
                currentID = int.Parse(id);
                currentMaquinario = maquinarioDao.selectById(int.Parse(id));
                textBox1.Text = currentMaquinario.nome;
                textBox2.Text = currentMaquinario.descricao;
                comboBox1.SelectedIndex = currentMaquinario.combustivel_id - 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentID != -1) // Update
            {
                currentMaquinario.nome = textBox1.Text;
                currentMaquinario.descricao = textBox2.Text;
                currentMaquinario.combustivel_id = comboBox1.SelectedIndex + 1;
                maquinarioDao.update(currentMaquinario);
            }
            else
            {
                currentMaquinario = new Maquinario();
                currentMaquinario.nome = textBox1.Text;
                currentMaquinario.descricao = textBox2.Text;
                currentMaquinario.combustivel_id = comboBox1.SelectedIndex + 1;
                DebugDLL.Debug.debug("select index:" + comboBox1.SelectedIndex);
                maquinarioDao.insert(currentMaquinario);
            }

            MainWindow.updateTreeNodesAction();
            Dispose();
        }
    }
}