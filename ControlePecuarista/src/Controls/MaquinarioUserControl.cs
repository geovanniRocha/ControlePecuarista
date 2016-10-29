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

namespace ControlePecuarista.src
{
    public partial class MaquinarioUserControl : UserControl
    {

        private int currentID;
        private DataPersistent.Maquinario currentMaquinario;
        private DataPersistent.MaquinarioDAO maquinarioDao;
       

        public MaquinarioUserControl(string id = null)//TODO MAKE THIS RIGHT
        {
            InitializeComponent();
            currentID = -1;
            maquinarioDao = new MaquinarioDAO(MainWindow.currentPath);

            if (id != null)
            {
                currentID = int.Parse(id);

                DataPersistent.CombustiveisDAO temp2 = new CombustiveisDAO(MainWindow.currentPath   );
                comboBox1.DataSource = temp2.selectIdAndString().Values.ToArray();
                currentMaquinario = maquinarioDao.selectById(int.Parse(id));
                this.textBox1.Text = currentMaquinario.nome;
                this.textBox2.Text = currentMaquinario.descricao;
                this.comboBox1.SelectedIndex = currentMaquinario.combustivel_id;
             }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentID != -1) // Update
            {
                currentMaquinario.nome = this.textBox1.Text;
                currentMaquinario.descricao = this.textBox2.Text;
                currentMaquinario.combustivel_id = this.comboBox1.SelectedIndex;
                maquinarioDao.update(currentMaquinario);

            }
            else // Create
            {
                //currentMaquinario = new Maquinario();
                //maquinarioDao.insert(currentMaquinario);
            }

            MainWindow.updateTreeNodesAction();
            this.Dispose();
        }
    }
}
