using Data_Persistent;
using System;
using System.Windows.Forms;

namespace ControlePecuarista
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var cp = new DataStorage.ControlePecuarista();
            cp.insertGastos(new DataTypes.Gastos(cp.gastoList.Count, "Um", null, 0, null));
            cp.insertGastos(new DataTypes.Gastos(cp.gastoList.Count, "Dois", null, 0, null));
            cp.insertGastos(new DataTypes.Gastos(cp.gastoList.Count, "Tres", null, 0, null));
            cp.insertGastos(new DataTypes.Gastos(cp.gastoList.Count, "Quatro", null, 0, null));
            cp.insertGastos(new DataTypes.Gastos(cp.gastoList.Count, "Cinco", null, 0, null));

            cp.insertMaquinario(new DataTypes.Maquinario(cp.maquinarioList.Count, "Maquina1", null, 0));
            cp.insertMaquinario(new DataTypes.Maquinario(cp.maquinarioList.Count, "Maquina2", null, 0));
            cp.insertMaquinario(new DataTypes.Maquinario(cp.maquinarioList.Count, "Maquina3", null, 0));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow(cp));
        }
    }
}