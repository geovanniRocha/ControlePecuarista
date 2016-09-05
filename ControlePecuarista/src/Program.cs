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
            Debug.instace.log("");
            var numberOfItens = 200;
            var cp = new DataStorage.ControlePecuarista();
            for (var i = 0; i < numberOfItens; i++)
                cp.insertGastos(new DataTypes.Gastos(cp.gastoList.Count, "Gasto " + i, null, 0, null));

            for (var i = 0; i < numberOfItens; i++)
                cp.insertMaquinario(new DataTypes.Maquinario(cp.maquinarioList.Count, "Maquina" + i, null, 0));

            for (var i = 0; i < numberOfItens; i++)
                cp.insertCombustivel(new DataTypes.Combustivel(cp.maquinarioList.Count, "Combustivel" + i));

            for (var i = 0; i < numberOfItens; i++)
                cp.insertPastagem(new DataTypes.Pastagem(cp.pastagemList.Count));

            for (var i = 0; i < numberOfItens; i++)
                cp.insertTipoPastagem(new DataTypes.TipoPastagem(cp.tipoPastagemList.Count, "Grama"));

            for (var i = 0; i < numberOfItens; i++)
                cp.insertUnidadeAnimal(new DataTypes.UnidadeAnimal(cp.unidadeAnimalList.Count, "UA " + i));

           
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow(cp));
        }
    }
}