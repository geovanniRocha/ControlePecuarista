using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace DataPersistent
{
    class CombustiveisDAO : IProvideSQL<Combustiveis>
    {
        public override void insert(Combustiveis data)
        {
            string sql = $"INSERT INTO combustiveis (nome,descricao)" +
                         $"VALUES('{data.nome.ToString()}', '{data.descricao.ToString()}'); ";
            Console.WriteLine(sql);
            using (SQLiteConnection c = new SQLiteConnection(base.connection))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                {
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public override void update(Combustiveis data)
        {
            string sql = $"INSERT INTO combustiveis (nome,descricao)" +
                         $"VALUES('{data.nome.ToString()}', '{data.descricao.ToString()}'); ";
            Console.WriteLine(sql);
            using (SQLiteConnection c = new SQLiteConnection(base.connection))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                {
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public override void delete(Combustiveis data) {
            string sql = $"delete from combustiveis where id='{data.id.ToString()}'";
            Console.WriteLine(sql);
            using (SQLiteConnection c = new SQLiteConnection(base.connection))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                {
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public override Combustiveis selectById(int id)
        {
            string sql = $"select id, nome, descricao from combustiveis where id='{id.ToString()}'";
            Console.WriteLine(sql);
            Combustiveis temp = null;
            using (SQLiteConnection c = new SQLiteConnection(base.connection))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.FieldCount);
                            
                            var tempId = reader.GetInt32(0);
                            var tempNome = reader.GetString(1);
                            var tempDescricao = reader.GetString(2);
                            temp = new Combustiveis(tempId, tempNome, tempDescricao);
                            Console.WriteLine(temp.ToString());
                        }
                    }
                }


            }
            return temp;
        }

        public override void createTable()
        {
            string sql = @"CREATE TABLE combustiveis (
                        id        INTEGER PRIMARY KEY AUTOINCREMENT,
                        nome      STRING,
                        descricao STRING
                        );";
            Console.WriteLine(sql);
            using (SQLiteConnection c = new SQLiteConnection(base.connection))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                {
                    cmd.ExecuteNonQuery();
                }

            }
        }
    }

    class Combustiveis
    {
        public Combustiveis(string nome, string descricao)
        {
            this.nome = nome;
            this.descricao = descricao;
        }


        public Combustiveis(int id, string nome, string descricao)
        {
            this.id = id;
            this.nome = nome;
            this.descricao = descricao;
        }

        public int id;
        public string nome { get; set; }
        public string descricao { get; set; }


    }
}
