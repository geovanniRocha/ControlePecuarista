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
            var sql = $"insert into UnidadeAnimal values(nome, UAEntrada, UASaida, DataEntrada, DataSaida, idRaca, ValorUA)" +
                     $"Values('{data.nome}','{data.uaEntrada}','{data.uaSaida}','{data.dataEntrada}','{data.dataSaida}','{data.raca}','{data.valor}');";
            base.runSQLWithOutReturn(sql);
        }

        public override void update(UnidadeAnimal data)
        {
            throw new NotImplementedException();
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
                            DataSaida   DATE,
                            DataEntrada DATE,
                            IdRaca      INTEGER,
                            ValorUa     REAL
                        );";
            base.runSQLWithOutReturn(sql);
        }

        public override UnidadeAnimal selectById(int id)
        {
            string sql = $"SELECT id,NOME,UAEntrada,UASaida,DataSaida,DataEntrada,IdRaca,ValorUa FROM UnidadeAnimal where id = '{id}';";
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
                            var h = reader.GetInt32(6);
                            var i = reader.GetFloat(7);



                            temp = new UnidadeAnimal(a,b,d,e,f,g,h,i);
                        }
                    }
                }
            }
            return temp;

        }



        public override List<UnidadeAnimal> selectEverything()
        {
            throw new NotImplementedException();
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
        public int raca { get; set; }
        public float valor { get; set; }


        public UnidadeAnimal(string nome, float uaEntrada, float uaSaida, string dataEntrada, string dataSaida, int raca, float valor) {
            this.nome = nome;
            this.uaEntrada = uaEntrada;
            this.uaSaida = uaSaida;
            this.dataEntrada = long.Parse(dataEntrada);
            this.dataSaida = long.Parse(dataSaida);
            this.raca = raca;
            this.valor = valor;
        }

        public UnidadeAnimal(int id, string nome, float uaEntrada, float uaSaida, string dataEntrada, string dataSaida, int raca, float valor) {
            this.id = id;
            this.nome = nome;
            this.uaEntrada = uaEntrada;
            this.uaSaida = uaSaida;
            this.dataEntrada = long.Parse(dataEntrada);
            this.dataSaida = long.Parse(dataSaida);
            this.raca = raca;
            this.valor = valor;
        }
    }
}
