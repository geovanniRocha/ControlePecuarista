using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace DataPersistent
{
    public  class Misc
    {
        private readonly SQLiteConnection connection;

        public Misc(string path) {
            connection = new SQLiteConnection($"Data Source={path}; Version=3;");
        }


        public List<Gastos> listAllGastosByIdAsc(int id)
        {
            string sql = $"select g.nome, g.Descricao, g.Valor from gastos g inner join UnidadeAnimal ua on(g.IDRef=ua.id) where g.IDCategoria=3 and ua.ID = {id} order by valor ASC;";
            var temp = new List<Gastos>();
            using (var c = new SQLiteConnection(connection))
            {
                c.Open();
                using (var cmd = new SQLiteCommand(sql, c))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tempNome = reader.GetString(0);
                            var tempDescricao = reader.GetString(1);
                            var valor = reader.GetFloat(2);

                            temp.Add(new Gastos(tempNome, tempDescricao, valor));
                        }
                    }
                }
            }
            return temp;
        }

        public float selectSumGastosById(int id)
        {
            var sql =
                $"select sum(g.Valor) from gastos g inner join UnidadeAnimal ua on(g.IDRef=ua.id)  where g.IDCategoria=3 and ua.ID = {id}";
            float sumGasto = 0;
            using (var c = new SQLiteConnection(connection))
            {
                c.Open();
                using (var cmd = new SQLiteCommand(sql, c))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sumGasto = reader.GetFloat(0);
                        }
                    }
                }
            }
            return sumGasto;
        }


       public string selectNomeByidRefFromGastos(int id, string tableName) {
            var sql =$"select nome from {tableName} g where id = {id}";
            string nome="";
            using (var c = new SQLiteConnection(connection))
            {
                c.Open();
                using (var cmd = new SQLiteCommand(sql, c))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            nome = reader.GetString(0);
                        }
                    }
                }
            }
            return nome;
        }
    }
}
