using System.Collections.Generic;
using System.Data.SQLite;

namespace DataPersistent
{
    public class GastosDAO : IProvideSQL<Gastos> {

        public GastosDAO(string path) : base(path)
        {

        }

        public override void insert(Gastos data) {
            var sql =
                $" INSERT INTO gastos (Nome,IDCategoria,IDRef, Valor, Descricao) VALUES('{data.nome}'," +
                $" '{(int) data.idCategoria}', '{data.idRef}', '{data.valor}', '{data.descricao}'); ";
            runSQLWithOutReturn(sql);
        }

        public override void update(Gastos data) {
            var sql =
                $"UPDATE gastos set nome ='{data.nome}', IDCategoria='{(int) data.idCategoria}'," +
                $"  IDRef='{data.idRef}', Valor='{data.valor}', Descricao='{data.descricao}'   where id='{data.id}';";

            runSQLWithOutReturn(sql);
        }

        public override void delete(Gastos data) {
            var sql = $"DELETE from gastos where id='{data.id}'";
            runSQLWithOutReturn(sql);
        }

        public float selectSumGastosById(int id) {
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

        public override void createTable() {
            var sql = @"  CREATE TABLE gastos (
    ID          INTEGER PRIMARY KEY AUTOINCREMENT,
    Nome        TEXT,
    IDCategoria INTEGER DEFAULT (0),
    IDRef       INTEGER DEFAULT (0),
    Valor       REAL,
    Descricao   TEXT
);";
            runSQLWithOutReturn(sql);
        }

        public override Gastos selectById(int id) {
            string sql = $"select id,Nome,IDCategoria,IDRef, Valor, Descricao from Gastos where id='{id}'";
            Gastos temp = null;
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
                            var IDCategoria = reader.GetInt32(2);
                            var IDRef = reader.GetInt32(3);
                            var valor = reader.GetFloat(4);
                            var desc = reader.GetString(5);

                            temp = new Gastos(tempid, tempnome, IDCategoria, IDRef, valor, desc);
                        }
                    }
                }
            }
            return temp;
        }

        public override List<Gastos> selectEverything() {
            string sql = $"select id,Nome,IDCategoria,IDRef, Valor, Descricao from Gastos;";
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
                            var tempid = reader.GetInt32(0);
                            var tempnome = reader.GetString(1);
                            var IDCategoria = reader.GetInt32(2);
                            var IDRef = reader.GetInt32(3);
                            var valor = reader.GetFloat(4);
                            var desc = reader.GetString(5);

                            temp.Add(new Gastos(tempid, tempnome, IDCategoria, IDRef, valor, desc));
                        }
                    }
                }
            }
            return temp;
        }

        public Dictionary<int, string> selectIdAndString() {
            string sql = $"select id,Nome,IDCategoria,IDRef, Valor, Descricao from Gastos;";

            return base.selectIdAndString(sql);
        }
    }

    public class Gastos {

        public Gastos()
        {

        }

        public Gastos(string nome, int idCategoria, int idRef, float valor, string descricao) {
            this.nome = nome;
            this.idCategoria = (GastosType) idCategoria;
            this.idRef = idRef;
            this.valor = valor;
            this.descricao = descricao;
        }

        public Gastos(int id, string nome, int idCategoria, int idRef, float valor, string descricao) {
            this.id = id;
            this.nome = nome;
            this.idCategoria = (GastosType) idCategoria;
            this.idRef = idRef;
            this.valor = valor;
            this.descricao = descricao;
        }

        public Gastos(int id, string nome, GastosType idCategoria, int idRef, float valor, string descricao) {
            this.id = id;
            this.nome = nome;
            this.idCategoria = idCategoria;
            this.idRef = idRef;
            this.valor = valor;
            this.descricao = descricao;
        }

        public Gastos(string nome, GastosType idCategoria, int idRef, float valor, string descricao) {
            this.nome = nome;
            this.idCategoria = idCategoria;
            this.idRef = idRef;
            this.valor = valor;
            this.descricao = descricao;
        }

        public int id { get; }
        public string nome { get; set; }
        public GastosType idCategoria { get; set; }
        public int idRef { get; set; }
        public float valor { get; set; }
        public string descricao { get; set; }
    }

    public enum GastosType {
        Maquinario,
        Combustivel,
        Pastagem,
        UnidadeAnimal,
        Outros
    }
}