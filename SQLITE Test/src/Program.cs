using System;

namespace SQLITE_Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var cp = new DataStorage.ControlePecuarista();

                var t = new DataTypes.Maquinario
                {
                    id = 1,
                    descricao = "heue",
                    nome = "Nome",
                    valor = 10
                };
                cp.insertMaquinario(t);


                t = new DataTypes.Maquinario
                {
                    id = 2,
                    valor = 1000
                };
                cp.insertMaquinario(t);


                var c = new DataTypes.Gastos
                {
                    id = 1,
                    data = "10/10/10",
                    descricao = "WORKS!!"
                };
                cp.insertGastos(c);

                var b = DataStorage.jsonSerialize(cp);
                DataStorage.writeFile(b, "teste.txt");
                Console.WriteLine(b);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
            }

            Console.Read();
        }
    }
}