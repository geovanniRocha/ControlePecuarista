using System;
using System.IO;
using System.Windows.Forms;
using DataPersistent;
using GeradorRelatorio;

namespace ControlePecuarista
{
    internal static class Program {

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        /// TODO GERAR RELATORIO
        [STAThread]
        private static void Main() {

            //TODO ver por que quando insere gasto o valor é ZERO(0)           



            Application.Run(new MainWindow());
        }
    }
}