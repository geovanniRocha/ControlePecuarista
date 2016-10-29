using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace DataPersistent
{
    public class CombustiveisDAO : IProvideSQL<Combustivel>
    {
        public CombustiveisDAO(string path) : base(path) { }

        public override void insert(Combustivel data)
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

        public override void update(Combustivel data)
        {
            string sql = $"INSERT INTO combustiveis (nome,descricao)" +
                         $"VALUES('{data.nome.ToString()}', '{data.descricao.ToString()}'); ";
            using (SQLiteConnection c = new SQLiteConnection(base.connection))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                {
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public override void delete(Combustivel data)
        {
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
        
        public override Combustivel selectById(int id)
        {
            string sql = $"select id, nome, descricao from combustiveis where id='{id.ToString()}'";
            Console.WriteLine(sql);
            Combustivel temp = null;
            using (SQLiteConnection c = new SQLiteConnection(base.connection))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader.HasRows)
                            while (reader.Read())
                            {
                                Console.WriteLine(reader.FieldCount);

                                var tempId = reader.GetInt32(0);
                                var tempNome = reader.GetString(1);
                                var tempDescricao = reader.GetString(2);
                                temp = new Combustivel(tempId, tempNome, tempDescricao);
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
            using (SQLiteConnection c = new SQLiteConnection(connection))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                {
                    cmd.ExecuteNonQuery();
                }

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A list with ID and Nome</returns>
        public override Dictionary<int, string> selectIdAndString() {
            Dictionary<int, string> combustiveisList = new Dictionary<int, string>();

            string sql = $"select id, nome from combustiveis";
            Console.WriteLine(sql);
            Combustivel temp = null;
            using (SQLiteConnection c = new SQLiteConnection(base.connection))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader.HasRows)
                            while (reader.Read())
                            {

                                var tempId = reader.GetInt32(0);
                                var tempNome = reader.GetString(1);
                                combustiveisList.Add(tempId, tempNome);
                            }
                    }
                }
            }
            return combustiveisList;
        }
    }

    public class Combustivel
    {
        public Combustivel(string nome, string descricao)
        {
            this.nome = nome;
            this.descricao = descricao;
        }


        public Combustivel(int id, string nome, string descricao)
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
