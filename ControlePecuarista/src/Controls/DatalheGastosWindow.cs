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
        private Misc miscDao;
        private int currentUAId;
        private float valorArrobaEntrada;
        private float valorArrobaSaida;

        public DatalheGastosWindow(int id)  // <-  ID UO 
        {
            InitializeComponent();

            currentUAId = id;
            unidadeAnimalDao = new UnidadeAnimalDAO(MainWindow.currentPath);
            miscDao = new Misc(MainWindow.currentPath);

            var a = miscDao.listAllGastosByIdAsc(currentUAId);
            foreach (var b in a)
            {
                appendTextToDetalhes("Nome: " + b.nome, Color.Black, false);
                appendTextToDetalhes("\tDescricao: "+ b.descricao, Color.Black, false);
                appendTextToDetalhes("\tValor: " + b.valor, b.valor >= 0 ? Color.DarkGreen
                                                                       : Color.DarkRed );

            }
        }

        float calculaGanhoUAByID(int idUA, float valorArrobaEntrada, float valorArrobaSaida) {
            
            UnidadeAnimal ua = unidadeAnimalDao.selectById(idUA);

            float valorSaidaTotal = valorArrobaSaida * ((( ua.uaSaida- ua.uaEntrada)*450) / 30.0f) ;
            float valorEntradaTotal = valorArrobaEntrada * (ua.uaEntrada /30.0f);
            float gastoTotal = miscDao.selectSumGastosById(ua.id);

#if DEBUG
            DebugDLL.Debug.logger(" ", Color.DarkCyan);
            DebugDLL.Debug.logger("Valor Saida: " + valorSaidaTotal.ToString(), Color.DarkCyan);
            DebugDLL.Debug.logger("Valor Entrada: " + valorEntradaTotal.ToString(), Color.DarkMagenta);
            DebugDLL.Debug.logger("Gasto: " + gastoTotal.ToString(), Color.DarkOrange); 
#endif

            float ganho = valorEntradaTotal -  valorSaidaTotal + gastoTotal ;
            //throw  new NotImplementedException("Check calculo de saida, entrada e gasto total, valores estranhos");
            return ganho*-1;
        }

        private void arrobaEntradaTextBoxLeave(object sender, EventArgs e)
        {
            Regex pattern = new Regex("[0-9]{0,50}");
            if (pattern.IsMatch(arrobaEntradaTextBox.Text))
            {
                valorArrobaEntrada = float.Parse(string.IsNullOrEmpty(arrobaEntradaTextBox.Text) ? "0": arrobaEntradaTextBox.Text);
                float a = calculaGanhoUAByID(currentUAId, valorArrobaEntrada, valorArrobaSaida);
                totalGasto.Text = $"A: {a}";

            }
            else
            {
#if DEBUG
                DebugDLL.Debug.error("Invalid input"); 
#endif
            }
            
        }

        private void arrobaSaidaTextBoxLeave(object sender, EventArgs e) {
            Regex pattern = new Regex("[0-9]{0,50}");
            if (pattern.IsMatch(arrobaSaidaTextBox.Text))
            {
                valorArrobaSaida = float.Parse(string.IsNullOrEmpty(arrobaSaidaTextBox.Text) ? "0" : arrobaSaidaTextBox.Text);
                float a = calculaGanhoUAByID(currentUAId, valorArrobaEntrada, valorArrobaSaida);
                totalGasto.Text = $"B: {a}";
                //totalGasto.Text = $"Total Gasto: {a}";

            }
            else
            {
#if DEBUG
                DebugDLL.Debug.error("Invalid input"); 
#endif
            }
            
        }



        private void appendTextToDetalhes(string text, Color color, bool addNewLine = true)
        {
            if (addNewLine)
            {
                text += Environment.NewLine;
            }

            detalhesRichTextBox.SelectionStart = detalhesRichTextBox.TextLength;
            detalhesRichTextBox.SelectionLength = 0;

            detalhesRichTextBox.SelectionColor = color;
            detalhesRichTextBox.AppendText(text);
            detalhesRichTextBox.SelectionColor = detalhesRichTextBox.ForeColor;
        }

    }
}
