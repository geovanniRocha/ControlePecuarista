using System;
using System.Globalization;
using System.IO;
using DataPersistent;

namespace GeradorRelatorio
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            var path = @"D:\hue.cdp";
            CombustiveisDAO combustiveisDao = new CombustiveisDAO(path);
            MaquinarioDAO maquinarioDao = new DataPersistent.MaquinarioDAO(path);
            PastagemDAO pastagemDao = new DataPersistent.PastagemDAO(path);
            TipoPastagemDAO tipoPastagemDao =new DataPersistent.TipoPastagemDAO(path);
            GastosDAO gastosDao =new DataPersistent.GastosDAO(path);
            UnidadeAnimalDAO unidadeAnimalDao =new DataPersistent.UnidadeAnimalDAO(path);


            var a = new HTMLBuilder();
            a.addButton("Maquinarios");
            a.addButton("Pastagem");
            a.addButton("Gastos");
            a.addButton("Unidade Animal");

            a.initDiv("Maquinarios");
            a.addMaquinariosTable(maquinarioDao.selectEverything());
            a.endDiv();

            
            a.initDiv("Pastagem");
            a.addPastagemTable(pastagemDao.selectEverything());
            a.endDiv();

            
            a.initDiv("Gastos");
            a.addGastosTable(gastosDao.selectEverything());
            a.endDiv();

            
            a.initDiv("Unidade Animal");
            a.addUnidadeAnimalTable(unidadeAnimalDao.selectEverything());
            a.endDiv();


            using (StreamWriter writer =
                new StreamWriter(@"D:Relato.html"))
            {
                writer.WriteLine(a.toHTML());
            }



            Console.ReadLine();
        }
    }
}