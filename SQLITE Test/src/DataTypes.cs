namespace Data_Persistent
{
    public static class DataTypes
    {
        #region Types

        public abstract class Types
        {
            public abstract string SQLQuery();

        }

        public class Maquinario : Types
        {
            public Maquinario(int id, string nome, string descricao, int valor)
            {
                this.id = id;
                this.nome = nome;
                this.descricao = descricao;
                this.valor = valor;
            }

            public Maquinario()
            {
            }

            public int id { get; set; }
            public string nome { get; set; }
            public string descricao { get; set; }
            public int valor { get; set; }

            public override string ToString()
            {
                return $"{id}, {nome ?? "null"}, {descricao ?? "null"}, {valor}";
            }

            public override string SQLQuery()
            {
                return "Select maquinarios.nome,Combustiveis.nome ,maquinarios.id from Maquinarios inner join Combustiveis where Maquinarios.combustivel_id = Combustiveis.id order by maquinarios.id asc;";
            }
        }

        public class Gastos: Types
        {
            public Gastos()
            {
            }

            public Gastos(int id, string nome, string descricao, int valor, string data)
            {
                this.id = id;
                this.nome = nome;
                this.descricao = descricao;
                this.valor = valor;
                this.data = data;
            }

            public int id { get; set; }
            public string nome { get; set; }
            public string descricao { get; set; }
            public int valor { get; set; }
            public string data { get; set; }

            public override string ToString()
            {
                return $"{id}, {nome ?? "Null"}, {descricao ?? "Null"}, {valor}, {data ?? "Null"}";
            }

            public override string SQLQuery()
            {
                throw new System.NotImplementedException();
            }
        }

        public class Combustivel : Types
        {
            public int id { get; set; }
            public string nome { get; set; }

            public Combustivel()
            {
                
            }

            public Combustivel(int id, string nome)
            {
                this.id = id;
                this.nome = nome;
            }

            public override string ToString()
            {
                return $"{id}, {nome??"null"}";
            }

            public override string SQLQuery()
            {
                throw new System.NotImplementedException();
            }
        }

        public class Pastagem : Types
        {
            public int id { get; set; }
            public string nome { get; set; }

            public Pastagem()
            {
                
            }

            public Pastagem(int id, string nome)
            {
                this.id = id;
                this.nome = nome;
            }

            public Pastagem(int id)
            {
                this.id = id;
                this.nome = "Pastagem " + id;
            }

            public override string SQLQuery()
            {
                throw new System.NotImplementedException();
            }
        }

        public class TipoPastagem : Types
        {
            public int id { get; set; }
            public string nome { get; set; }

            public TipoPastagem(int id, string nome)
            {
                this.id = id;
                this.nome = nome;
            }

            public override string SQLQuery()
            {
                throw new System.NotImplementedException();
            }
        }

        public class UnidadeAnimal : Types 
        {
            public int id { get; set; }
            public string nome { get; set; }

            public UnidadeAnimal(int id, string nome)
            {
                this.id = id;
                this.nome = nome;
            }

            public override string SQLQuery()
            {

                throw new System.NotImplementedException();

            }
        }

        #endregion Types
    }
}