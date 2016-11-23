using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace DataPersistent
{
    public class PastagemDAO : IProvideSQL<Pastagem> {

        public PastagemDAO(string path) : base(path)
        {

        }

        public override void insert(Pastagem data) {
            var sql =
                $"insert into pastagem(nome, areaUtil, IDTipoPastagem) values('{data.nome}','{data.areaUtil}', '{data.tipoPastagemID}');";
            runSQLWithOutReturn(sql);
        }

        public override void update(Pastagem data) {
            var sql =
                $"update pastagem set nome='{data.nome}, areaUtil = '{data.areaUtil}', IDTipoPastagem = '{data.tipoPastagemID}' where id = '{data.id}'";
            runSQLWithOutReturn(sql);
        }

        public override void delete(Pastagem data) {
            var sql = $"delete from pastagem where id='{data.id}'";
            runSQLWithOutReturn(sql);
        }

        public override void createTable() {
            var sql = @" CREATE TABLE pastagem (
                        ID             INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nome           TEXT,
                        AreaUtil       REAL,
                        IDTipoPastagem INTEGER
                         );";
            runSQLWithOutReturn(sql);
        }

        public override Pastagem selectById(int id) {
            string sql = $"select id, nome,areautil, IDTipoPastagem from pastagem where id ='{id}';";
            Pastagem temp = null;
            using (var c = new SQLiteConnection(connection))
            {
                c.Open();
                using (var cmd = new SQLiteCommand(sql, c))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            temp = new Pastagem(reader.GetInt32(0),reader.GetString(1), reader.GetFloat(2), reader.GetInt32(3));
                        }
                    }
                }
            }
            return temp;
        }

        public override List<Pastagem> selectEverything() {
            var tempList = new List<Pastagem>();
            string sql = $"select p.id, p.nome,p.areautil, p.IDTipoPastagem, tp.Nome from pastagem p  inner join tipoPastagem tp on p.IDTipoPastagem = tp.id-1;";
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
                            tempList.Add(new Pastagem(reader.GetInt32(0), reader.GetString(1), reader.GetFloat(2), reader.GetInt32(3), reader.GetString(4)));
                        }
                    }
                }
            }
            return tempList;
        }

        public Dictionary<int, string> selectIdAndString() {
            string sql = $"select id, nome from pastagem;";
            return base.selectIdAndString(sql);
        }
    }

    public class Pastagem {

        public Pastagem(int id, string nome, float areaUtil, int tipoPastagemId) {
            this.id = id;
            this.nome = nome;
            this.areaUtil = areaUtil;
            tipoPastagemID = tipoPastagemId;
        }
        public Pastagem(int id, string nome, float areaUtil, int tipoPastagemId, string tipoPastagemNome) {
            this.id = id;
            this.nome = nome;
            this.areaUtil = areaUtil;
            tipoPastagemID = tipoPastagemId;
            this.tipoPastagemNome = tipoPastagemNome;
        }

        public Pastagem(string nome, float areaUtil, int tipoPastagemId) {
            this.nome = nome;
            this.areaUtil = areaUtil;
            tipoPastagemID = tipoPastagemId;
        }

        public int id { get; set; }
        public string nome { get; set; }
        public float areaUtil { get; set; }
        public int tipoPastagemID { get; set; }
        public string tipoPastagemNome { get; set; }
    }
}
