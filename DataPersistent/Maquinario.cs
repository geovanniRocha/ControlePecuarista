using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace DataPersistent
{
    public class MaquinarioDAO : IProvideSQL<Maquinario> {
        public MaquinarioDAO(string path) : base(path) {}

        public override void insert(Maquinario data) {
            string sql = $"INSERT INTO maquinarios (nome,descricao,combustivel_id)" +
                         $"VALUES('{data.nome.ToString()}', '{data.descricao.ToString()}', '{data.combustivel_id.ToString()}'); ";
            Console.WriteLine("Logger " + sql);
            using (SQLiteConnection c = new SQLiteConnection(base.connection))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public override void update(Maquinario data) {

            string sql =
                $"Update maquinarios set nome='{data.nome.ToString()}', descricao='{data.descricao.ToString()}' , combustivel_id ='{data.combustivel_id.ToString()}'  where id='{data.id.ToString()}';";
            Console.WriteLine("update sql: " + sql);
            using (SQLiteConnection c = new SQLiteConnection(base.connection))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public override void delete(Maquinario data) {

            string sql = $"delete from maquinarios where id='{data.id.ToString()}'";
            using (SQLiteConnection c = new SQLiteConnection(base.connection))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public override Maquinario selectById(int id) {

            string sql = $"select id, nome, descricao, combustivel_id from maquinarios where id='{id.ToString()}'";
            Console.WriteLine(sql);
            Maquinario temp = null;
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


                            var tempid = reader.GetInt32(0);
                            var tempnome = reader.GetString(1);
                            var tempdescricao = reader.GetString(2);
                            var tempComb = reader.GetInt32(3);
                            temp = new Maquinario(tempid, tempnome, tempdescricao, tempComb);
                            Console.WriteLine(temp.ToString());
                        }
                    }
                }


            }
            return temp;

        }

        public override void createTable() {

            string sql = @"CREATE TABLE maquinarios (
                            id             INTEGER PRIMARY KEY AUTOINCREMENT,
                            nome           TEXT,
                            descricao      TEXT,
                            valor          TEXT,
                            combustivel_id INTEGER
                            );";
            using (SQLiteConnection c = new SQLiteConnection(base.connection))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                {
                    cmd.ExecuteNonQuery();
                }
            }



        }

        public override Dictionary<int, string> selectIdAndString() {

            Dictionary<int, string> tempDictionary = new Dictionary<int, string>();
            string sql = $"select id, nome from maquinarios;";
            Console.WriteLine(sql);
            Maquinario temp = null;
            using (SQLiteConnection c = new SQLiteConnection(base.connection))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tempid = reader.GetInt32(0);
                            var tempnome = reader.GetString(1);
                            tempDictionary.Add(tempid, tempnome);
                        }
                    }
                }
            }
            return tempDictionary;

        }

        public override List<Maquinario> selectEverything() {
            var tempList = new List<Maquinario>();
            string sql = $"select id, nome, descricao from maquinarios;";
            Console.WriteLine(sql);
            Maquinario temp = null;
            using (SQLiteConnection c = new SQLiteConnection(base.connection))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tempList.Add(new Maquinario(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), 0));
                        }
                    }
                }
            }
            return tempList;
        }
    }

    public class Maquinario
    {
        public int id { get; private set; }


        public string nome { get; set; }
        public string descricao { get; set; }
    
        public int combustivel_id { get; set; }

        public Maquinario(int id, string nome, string descricao, int combustivelId) {
            this.id = id;
            this.nome = nome;
            this.descricao = descricao;
            combustivel_id = combustivelId;
        }

        public Maquinario(string nome, string descricao, int combustivelId)
        {
            this.nome = nome;
            this.descricao = descricao;
            combustivel_id = combustivelId;
        }

        public override string ToString()
        {
            return $"{this.id}:{this.nome}:{this.descricao}:{combustivel_id}";
        }
    }

}
