using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace DataPersistent
{
    public class CombustiveisDAO : IProvideSQL<Combustivel> {

        public CombustiveisDAO(string path) : base(path)
        {

        }

        public override void insert(Combustivel data) {
            var sql = $"INSERT INTO combustiveis (nome,descricao)" +
                      $"VALUES('{data.nome}', '{data.descricao}'); ";
            runSQLWithOutReturn(sql);
        }

        public override void update(Combustivel data) {
            string sql =
                $"UPDATE combustiveis set nome='{data.nome}', descricao='{data.descricao}' where id='{data.id}'; ";
            runSQLWithOutReturn(sql);
        }

        public override void delete(Combustivel data) {
            string sql = $"delete from combustiveis where id='{data.id}'";
            runSQLWithOutReturn(sql);
        }

        public override Combustivel selectById(int id) {
            string sql = $"select id, nome, descricao from combustiveis where id='{id}'";
            Combustivel temp = null;
            using (var c = new SQLiteConnection(connection))
            {
                c.Open();
                using (var cmd = new SQLiteCommand(sql, c))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                            while (reader.Read())
                            {
                                var tempId = reader.GetInt32(0);
                                var tempNome = reader.GetString(1);
                                var tempDescricao = reader.GetString(2);
                                temp = new Combustivel(tempId, tempNome, tempDescricao);
                            }
                    }
                }
            }
            return temp;
        }

        public override List<Combustivel> selectEverything() {
            throw new NotImplementedException();
        }

        public override void createTable() {
            var sql = @"CREATE TABLE combustiveis (
                        id        INTEGER PRIMARY KEY AUTOINCREMENT,
                        nome      STRING,
                        descricao STRING
                        );";
            runSQLWithOutReturn(sql);
        }

        /// <summary>
        /// </summary>
        /// <returns>A list with ID and Nome</returns>
        public Dictionary<int, string> selectIdAndString() {
            string sql = $"select id, nome from combustiveis";
            return selectIdAndString(sql);
        }
    }

    public class Combustivel {
        public int id;

        public Combustivel(string nome, string descricao) {
            this.nome = nome;
            this.descricao = descricao;
        }

        public Combustivel(int id, string nome, string descricao) {
            this.id = id;
            this.nome = nome;
            this.descricao = descricao;
        }

        public string nome { get; set; }
        public string descricao { get; set; }
    }
}
