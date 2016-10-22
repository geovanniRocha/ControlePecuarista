using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace DataPersistent
{
    class MaquinarioDao : IProvideSQL<Maquinario>
    {
        public MaquinarioDao() : base() { }

        public override void insert(Maquinario data)
        {
            string sql = $"INSERT INTO maquinarios (nome,descricao,valor,combustivel_id)" +
                         $"VALUES('{data.nome.ToString()}', '{data.descricao.ToString()}', '{data.valor.ToString()}', '{data.combustivel_id.ToString()}'); ";
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

        public override void update(Maquinario data)
        {

            string sql = $"Update combustiveis set nome='{data.nome.ToString()}', descricao='{data.descricao.ToString()}'  where id='{data.id.ToString()}';";
            using (SQLiteConnection c = new SQLiteConnection(base.connection))
            {
                c.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public override void delete(Maquinario data)
        {

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

        public override Maquinario selectById(int id)
        {

            string sql = $"select id, nome, descricao, valor, combustivel_id from maquinarios where id='{id.ToString()}'";
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
                            var tempValor = reader.GetString(3);
                            var tempComb = reader.GetInt32(4);
                            temp = new Maquinario(tempid, tempnome, tempdescricao, tempValor, tempComb);
                            Console.WriteLine(temp.ToString());
                        }
                    }
                }
               

            }
            return temp;

        }

        public override void createTable()
        {

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

    }


    class Maquinario
    {

        public string nome { get; set; }
        public string descricao { get; set; }
        public int id { get; private set; }
        public string valor { get; set; }
        public int combustivel_id { get; set; }

        public Maquinario(int id, string nome, string descricao, string valor, int combustivelId)
        {
            this.nome = nome;
            this.descricao = descricao;
            this.id = id;
            this.valor = valor;
            combustivel_id = combustivelId;
        }
        public Maquinario(string nome, string descricao, string valor, int combustivelId)
        {
            this.nome = nome;
            this.descricao = descricao;
            this.valor = valor;
            combustivel_id = combustivelId;
        }

        public override string ToString()
        {
            return $"{this.id}:{this.nome}:{this.descricao}:{ this.valor }:{combustivel_id}:{base.ToString()}";
        }
    }

}
