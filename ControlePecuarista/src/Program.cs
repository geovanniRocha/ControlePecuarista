using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data_Persistent;

namespace ControlePecuarista
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DataStorage.ControlePecuarista cp = new DataStorage.ControlePecuarista();
            cp.insertGastos(new DataTypes.Gastos(cp.gastoList.Count+1, "1", null, 0, null));
            cp.insertGastos(new DataTypes.Gastos(cp.gastoList.Count+1, "2", null, 0, null));
            cp.insertGastos(new DataTypes.Gastos(cp.gastoList.Count+1, "3", null, 0, null));
            cp.insertGastos(new DataTypes.Gastos(cp.gastoList.Count+1, "4", null, 0, null));
            cp.insertGastos(new DataTypes.Gastos(cp.gastoList.Count+1, "5", null, 0, null));
            cp.insertGastos(new DataTypes.Gastos(cp.gastoList.Count+1, "6", null, 0, null));
            cp.insertGastos(new DataTypes.Gastos(cp.gastoList.Count+1, "7", null, 0, null));



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2(cp));
        }
    }
}
