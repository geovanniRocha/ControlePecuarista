using System;
using System.Globalization;

namespace GeradorRelatorio
{
    internal class Program {

        private static void Main(string[] args) {
            var valor = 001;
            var valorFormatado = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valor);
            //var path = @"D:\mydb.db3";
            //var maquinariosDao = new DataPersistent.MaquinarioDAO(path);

            //var a = new HTMLBuilder();
            //a.addButton("Maquinarios");
            //a.initDiv("Maquinarios");
            //a.addMaquinariosTable(maquinariosDao.selectEverything());
            //a.endDiv();

            Console.ReadLine();
        }
    }
}