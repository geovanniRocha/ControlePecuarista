using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace DataPersistent
{
    public class MaquinarioDAO : IProvideSQL<Maquinario> {

        public MaquinarioDAO(string path) : base(path)
        {

        }

        public override void insert(Maquinario data) {
            var sql = $"INSERT INTO maquinarios (nome,descricao,combustivel_id)" +
                      $"VALUES('{data.nome}', '{data.descricao}', '{data.combustivel_id}'); ";
            DebugDLL.Debug.debug(sql);
            runSQLWithOutReturn(sql);
        }

        public override void update(Maquinario data) {
            string sql =
                $"Update maquinarios set nome='{data.nome}', descricao='{data.descricao}' , combustivel_id ='{data.combustivel_id}'  where id='{data.id}';";
            runSQLWithOutReturn(sql);
        }

        public override void delete(Maquinario data) {
            string sql = $"delete from maquinarios where id='{data.id}'";
            runSQLWithOutReturn(sql);
        }

        public override void createTable() {
            var sql = @"CREATE TABLE maquinarios (
                            id             INTEGER PRIMARY KEY AUTOINCREMENT,
                            nome           TEXT,
                            descricao      TEXT,
                            valor          TEXT,
                            combustivel_id INTEGER
                            );";
            runSQLWithOutReturn(sql);
        }

        public override Maquinario selectById(int id) {
            string sql = $"select id, nome, descricao, combustivel_id from maquinarios where id='{id}'";
            Maquinario temp = null;
            using (var c = new SQLiteConnection(connection))
            {
                c.Open();
                using (var cmd = new SQLiteCommand(sql, c))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var tempid = reader.GetInt32(0);
                            var tempnome = reader.GetString(1);
                            var tempdescricao = reader.GetString(2);
                            var tempComb = reader.GetInt32(3);
                            temp = new Maquinario(tempid, tempnome, tempdescricao, tempComb);
                        }
                    }
                }
            }
            return temp;
        }

        public  Dictionary<int, string> selectIdAndString() {
            string sql = $"select id, nome from maquinarios;";
            return base.selectIdAndString(sql);
        }

        public override List<Maquinario> selectEverything() {
            var tempList = new List<Maquinario>();
            string sql = $"select id, nome, descricao from maquinarios;";
            Maquinario temp = null;
            using (var c = new SQLiteConnection(connection))
            {
                c.Open();
                using (var cmd = new SQLiteCommand(sql, c))
                {
                    using (var reader = cmd.ExecuteReader())
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

    public class Maquinario {

        public Maquinario(int id, string nome, string descricao, int combustivelId) {
            this.id = id;
            this.nome = nome;
            this.descricao = descricao;
            combustivel_id = combustivelId;
        }

        public Maquinario(string nome, string descricao, int combustivelId) {
            this.nome = nome;
            this.descricao = descricao;
            combustivel_id = combustivelId;
        }

        public Maquinario() {}
        public int id { get; }

        public string nome { get; set; }
        public string descricao { get; set; }

        public int combustivel_id { get; set; }

        public override string ToString() {
            return $"{id}:{nome}:{descricao}:{combustivel_id}";
        }
    }
}
