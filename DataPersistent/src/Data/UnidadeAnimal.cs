using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace DataPersistent
{
    public class UnidadeAnimalDAO : IProvideSQL<UnidadeAnimal>
    {
        public UnidadeAnimalDAO(string path) : base(path) { }

        public override void insert(UnidadeAnimal data)
        {
            var sql = $"insert into UnidadeAnimal (nome, UAEntrada, UASaida, DataEntrada, DataSaida, Raca, ValorUA)" +
                     $"Values('{data.nome}','{data.uaEntrada}','{data.uaSaida}','{data.dataEntrada}','{data.dataSaida}','{data.raca}','{data.valor}');";
            base.runSQLWithOutReturn(sql);
        }

        public override void update(UnidadeAnimal data)
        {
            var sql =
            $"UPDATE UnidadeAnimal SET NOME = '{data.nome}',  UAEntrada = '{data.uaEntrada}', UASaida = '{data.uaSaida}'," +
            $"DataSaida = '{data.dataSaida}', DataEntrada = '{data.dataEntrada}', Raca = '{data.raca}',ValorUa = '{data.valor}' " +
            $"where id='{data.id}'";
            base.runSQLWithOutReturn(sql);
        }

        public override void delete(UnidadeAnimal data)
        {
            var sql = $"delete from UnidadeAnimal where id='{data.id}'";
            base.runSQLWithOutReturn(sql);
        }

        public override void createTable()
        {
            string sql = @"  CREATE TABLE UnidadeAnimal (
                            ID          INTEGER PRIMARY KEY,
                            NOME        TEXT,
                            UAEntrada   REAL,
                            UASaida     REAL,
                            DataSaida   TEXT,
                            DataEntrada TEXT,
                            Raca        TEXT,
                            ValorUa     REAL
                        );";
            base.runSQLWithOutReturn(sql);
        }

        public override UnidadeAnimal selectById(int id)
        {
            string sql = $"SELECT id,NOME,UAEntrada,UASaida,DataEntrada,DataSaida,Raca,ValorUa FROM UnidadeAnimal where id = '{id}';";
            UnidadeAnimal temp = null;
            using (var c = new SQLiteConnection(connection))
            {
                c.Open();
                using (var cmd = new SQLiteCommand(sql, c))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {


                            var a = reader.GetInt32(0);
                            var b = reader.GetString(1);
                            var d = reader.GetFloat(2);
                            var e = reader.GetFloat(3);
                            var f = reader.GetString(4);
                            var g = reader.GetString(5);
                            var h = reader.GetString(6);
                            var i = reader.GetFloat(7);

                            temp = new UnidadeAnimal(a, b, d, e, long.Parse(f), long.Parse(g), h, i);

                        }
                    }
                }
            }
            return temp;

        }



        public override List<UnidadeAnimal> selectEverything()
        {
            var tempList = new List<UnidadeAnimal>();
            string sql = $"SELECT id,NOME,UAEntrada,UASaida,DataSaida,DataEntrada,Raca,ValorUa FROM UnidadeAnimal;";
            using (var c = new SQLiteConnection(connection))
            {
                c.Open();
                using (var cmd = new SQLiteCommand(sql, c))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            

                            var a = reader.GetInt32(0);
                            var b = reader.GetString(1);
                            var d = reader.GetFloat(2);
                            var e = reader.GetFloat(3);
                            var f = reader.GetString(4);
                            var g = reader.GetString(5);
                            var h = reader.GetString(6);
                            var i = reader.GetFloat(7);

                            tempList.Add( new UnidadeAnimal(a, b, d, e, long.Parse(f), long.Parse(g), h, i));

                        }
                    }
                }
            }
            return tempList;
        }

        public Dictionary<int, string> selectIdAndString()
        {
            string sql = $"select id, nome from UnidadeAnimal;";
            return base.selectIdAndString(sql);
        }
    }


    public class UnidadeAnimal
    {

        public int id { get; set; }
        public string nome { get; set; }
        public float uaEntrada { get; set; }
        public float uaSaida { get; set; }
        public long dataEntrada { get; set; }
        public long dataSaida { get; set; }
        public string raca { get; set; }
        public float valor { get; set; }


        public UnidadeAnimal(string nome, float uaEntrada, float uaSaida, long dataEntrada, long dataSaida, string raca, float valor) {
            this.nome = nome;
            this.uaEntrada = uaEntrada;
            this.uaSaida = uaSaida;
            this.dataEntrada = dataEntrada;
            this.dataSaida = dataSaida;
            this.raca = raca;
            this.valor = valor;
        }

        public UnidadeAnimal(int id, string nome, float uaEntrada, float uaSaida, long dataEntrada, long dataSaida, string raca, float valor) {
            this.id = id;
            this.nome = nome;
            this.uaEntrada = uaEntrada;
            this.uaSaida = uaSaida;
            this.dataEntrada = dataEntrada;
            this.dataSaida = dataSaida;
            this.raca = raca;
            this.valor = valor;
        }

    }
}
