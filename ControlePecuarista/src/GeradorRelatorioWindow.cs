using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataPersistent;
using GeradorRelatorio;

namespace ControlePecuarista.src
{
    public partial class GeradorRelatorioWindow : Form
    {
        private HTMLBuilder a;
        public GeradorRelatorioWindow()
        {
            InitializeComponent();
            a=new HTMLBuilder();
            //TODO V2-> Inserir um table sorter em Gastos.
            //TODO V2-> Gerar toda a documentacao em varios HTMLS (Index.html, gastos.html)
            //TODO V2-> Incluindo JavaScript, JQuery, Bootstrap, Cada um em um tipo de pasta(JS, CSS)
            //TODO V2-> Gerar um menu lateral para facil acesso a funcoes;

        }

        private void button1_Click(object sender, EventArgs e) {
            saveFileDialog1.ShowDialog(MainWindow.ActiveForm);
        }

        void gerador() {
            a.clear();

            var path = MainWindow.currentPath;
            CombustiveisDAO combustiveisDao = new CombustiveisDAO(path);
            MaquinarioDAO maquinarioDao = new DataPersistent.MaquinarioDAO(path);
            PastagemDAO pastagemDao = new DataPersistent.PastagemDAO(path);
            TipoPastagemDAO tipoPastagemDao = new DataPersistent.TipoPastagemDAO(path);
            GastosDAO gastosDao = new DataPersistent.GastosDAO(path);
            UnidadeAnimalDAO unidadeAnimalDao = new DataPersistent.UnidadeAnimalDAO(path);
            Misc miscDao = new Misc(path);



            a.initDiv("", "division");

            if (maquinariosCheckBox.Checked)
                a.addButton("Maquinarios");
            if (pastagemCheckBox.Checked)
                a.addButton("Pastagem");
            if (gastoCheckBox.Checked)
                a.addButton("Gastos");
            if (UAcheckBox.Checked)
                a.addButton("Unidade Animal");


            a.endDiv();

            if (maquinariosCheckBox.Checked)
            {

                a.initDiv("Maquinarios", "separator");
                a.addMaquinariosTable(maquinarioDao.selectEverything());
                a.endDiv();
            }


            if (pastagemCheckBox.Checked)
            {
                a.initDiv("Pastagem", "separator");
                a.addPastagemTable(pastagemDao.selectEverything());
                a.endDiv(); 
            }


            if (gastoCheckBox.Checked)
            {
                a.initDiv("Gastos", "separator");
                a.addGastosTable(gastosDao.selectEverything());
                a.endDiv(); 
            }


            if (UAcheckBox.Checked)
            {
                a.initDiv("Unidade Animal", "Separator");
                a.addUnidadeAnimalTable(unidadeAnimalDao.selectEverything());
                a.endDiv(); 
            }
            

            a.css();
           
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
             a = new HTMLBuilder();
            gerador();
            System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
            string toWrite = a.toHTML();
            fs.Write(System.Text.Encoding.UTF8.GetBytes(toWrite), 0, toWrite.Length);
            fs.Close();
            MessageBox.Show(this, "Relatorio gerado com sucesso.");
            Dispose();
        }
    }
}
