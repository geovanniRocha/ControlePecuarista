using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using DataPersistent;

namespace GeradorRelatorio
{
    class Program
    {
        static void Main(string[] args) {

            var valor = 001;
            var valorFormatado = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valor);
            Console.WriteLine(valorFormatado);
            //var path = @"D:\mydb.db3";
            //var maquinariosDao = new DataPersistent.MaquinarioDAO(path);

            //var a = new HTMLBuilder();
            //a.addButton("Maquinarios");
            //a.initDiv("Maquinarios");
            //a.addMaquinariosTable(maquinariosDao.selectEverything());
            //a.endDiv();

            //Console.WriteLine(a.toHTML());
            Console.ReadLine();
        }
    }
}
