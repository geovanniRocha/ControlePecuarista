using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace DataPersistent
{
    public class TipoPastagemDAO : IProvideSQL<TipoPastagem> {

        public TipoPastagemDAO(string path) : base(path){}

        public override void insert(TipoPastagem data) {
            var sql = $"INSERT INTO tipoPastagem (Nome) VALUES ('{data.nome}');";
            base.runSQLWithOutReturn(sql);
        }

        public override void update(TipoPastagem data) {
            var sql = $"UPDATE tipoPastagem SET Nome = '{data.nome}' WHERE id='{data.id}';";
            DebugDLL.Debug.error(sql);
            base.runSQLWithOutReturn(sql);
        }

        public override void delete(TipoPastagem data) {
            var sql = $"DELETE FROM tipoPastagem  WHERE ID = '{data.id}';";
            base.runSQLWithOutReturn(sql);
        }

        public override void createTable() {
            var sql = @" CREATE TABLE tipoPastagem (ID   INTEGER PRIMARY KEY,  Nome TEXT );";
            runSQLWithOutReturn(sql);
        }

        public override TipoPastagem selectById(int id) {
            string sql = $"select id, nome from tipoPastagem where id ='{id}';";
            TipoPastagem temp = null;
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
                            temp = new TipoPastagem(tempid, tempnome);
                        }
                    }
                }
            }
            return temp;


        }

        public override List<TipoPastagem> selectEverything() {
            throw new NotImplementedException();
        }

        public Dictionary<int, string> selectIdAndString() {
          string sql = $"select id, nome from tipoPastagem;";
          return base.selectIdAndString(sql);
        }
    }

    public class TipoPastagem {

        public TipoPastagem(int id, string nome) {
            this.id = id;
            this.nome = nome;
        }

        public TipoPastagem(string nome) {
            this.nome = nome;
        }

        public int id { get; set; }
        public string nome { get; set; }
    }
}
