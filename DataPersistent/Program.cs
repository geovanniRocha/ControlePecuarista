using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataPersistent
{
    class Program
    {
        static void Main(string[] args) {

            var path = @"D:\mydb.db3";
            CombustiveisDAO combustiveisDao = new CombustiveisDAO(path);
            MaquinarioDAO maquinarioDao = new MaquinarioDAO(path);

            //combustiveisDao.createTable();
            Combustivel a = combustiveisDao.selectById(1);
                

            Console.WriteLine("Done");
            Console.ReadKey();

        }

        static string random(int maxSize = 8)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[maxSize];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }
    }
}
