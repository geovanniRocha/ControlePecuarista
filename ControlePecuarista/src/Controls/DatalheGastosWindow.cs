using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataPersistent;

namespace ControlePecuarista.src.Controls
{
    public partial class DatalheGastosWindow : Form {
        
        private UnidadeAnimalDAO unidadeAnimalDao;
        private GastosDAO gastosDao;
        private int currentID;
        private float valorArrobaEntrada;
        private float valorArrobaSaida;

        public DatalheGastosWindow(int id)
        {
            InitializeComponent();

            currentID = id;
            unidadeAnimalDao = new UnidadeAnimalDAO(MainWindow.currentPath);
            gastosDao = new GastosDAO(MainWindow.currentPath);
        }

        float calculaGanhoUAByID(int id, float valorArrobaEntrada, float valorArrobaSaida) {
            int idRef =  gastosDao.selectById(id).idRef;
            UnidadeAnimal ua = unidadeAnimalDao.selectById(idRef);

            float valorSaidaTotal = valorArrobaSaida * ((ua.uaEntrada - ua.uaSaida) / 30 * 450);
            float valorEntradaTotal = valorArrobaEntrada * (ua.uaEntrada / 30);
            float gastoTotal = gastosDao.selectSumGastosById(ua.id);

            DebugDLL.Debug.logger(" ", Color.DarkCyan);
            DebugDLL.Debug.logger(valorSaidaTotal.ToString(), Color.DarkCyan);
            DebugDLL.Debug.logger(valorEntradaTotal.ToString(), Color.DarkMagenta);
            DebugDLL.Debug.logger(gastoTotal.ToString(), Color.DarkOrange);

            float ganho = valorSaidaTotal - valorEntradaTotal - gastoTotal;
            return ganho;
        }

        private void arrobaEntradaTextBoxLeave(object sender, EventArgs e)
        {
            Regex pattern = new Regex("[0-9]{0,50}");
            if (pattern.IsMatch(arrobaEntradaTextBox.Text))
            {
                valorArrobaEntrada = float.Parse(string.IsNullOrEmpty(arrobaEntradaTextBox.Text) ? "0": arrobaEntradaTextBox.Text);
                totalGasto.Text = $"Total Gasto: {calculaGanhoUAByID(currentID, valorArrobaEntrada , valorArrobaSaida)}";

            }
            else
            {
                DebugDLL.Debug.error("Invalid input");
            }
            
        }

        private void arrobaSaidaTextBoxLeave(object sender, EventArgs e) {
            Regex pattern = new Regex("[0-9]{0,50}");
            if (pattern.IsMatch(arrobaSaidaTextBox.Text))
            {
                valorArrobaSaida = float.Parse(string.IsNullOrEmpty(arrobaSaidaTextBox.Text) ? "0" : arrobaSaidaTextBox.Text);

                totalGasto.Text = $"Total Gasto: {calculaGanhoUAByID(currentID, valorArrobaEntrada, valorArrobaSaida)}";

            }
            else
            {
                DebugDLL.Debug.error("Invalid input");
            }
            
        }

    }
}
