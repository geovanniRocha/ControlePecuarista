using System;

namespace DataPersistent
{
    internal class Program {

        private static void Main(string[] args) {
            var path = @"D:\mydb.db3";
            var combustiveisDao = new CombustiveisDAO(path);
            var maquinarioDao = new MaquinarioDAO(path);

            Console.ReadKey();
        }

        private static string random(int maxSize = 8) {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[maxSize];
            var random = new Random();

            for (var i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new string(stringChars);
            return finalString;
        }
    }
}