using Data_Persistent;
using System;
using System.Runtime.Serialization.Json;
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
            Debug.instace.log("");
            var cp = new DataStorage.ControlePecuarista();

            cp.insertGastos(new DataTypes.Gastos(cp.gastoList.Count, "Um", null, 0, null));
            cp.insertGastos(new DataTypes.Gastos(cp.gastoList.Count, "Quatro", null, 0, null));
            cp.insertGastos(new DataTypes.Gastos(cp.gastoList.Count, "Cinco", null, 0, null));

            cp.insertMaquinario(new DataTypes.Maquinario(cp.maquinarioList.Count, "Maquina1", null, 0));
            cp.insertMaquinario(new DataTypes.Maquinario(cp.maquinarioList.Count, "Maquina2", null, 0));
            cp.insertMaquinario(new DataTypes.Maquinario(cp.maquinarioList.Count, "Maquina3", null, 0));

            cp.insertCombustivel(new DataTypes.Combustivel(cp.maquinarioList.Count, "Gasolina"));
            cp.insertCombustivel(new DataTypes.Combustivel(cp.maquinarioList.Count, "Alcool"));
            cp.insertCombustivel(new DataTypes.Combustivel(cp.maquinarioList.Count, "h2o"));

            for (int i = 0; i < 10; i++)
                cp.insertPastagem(new DataTypes.Pastagem(cp.pastagemList.Count));

            for (int i = 0; i < 10; i++)
                cp.insertTipoPastagem(new DataTypes.TipoPastagem(cp.tipoPastagemList.Count, "Grama"));

            

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow(cp));
        }
    }
}