namespace Data_Persistent
{
    public static class DataTypes
    {
        #region Types

        public class Maquinario
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
        }

        public class Gastos
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
        }

        public class Combustivel
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
        }

        public class Pastagem
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
        }

        public class TipoPastagem
        {
            public int id { get; set; }
            public string nome { get; set; }

            public TipoPastagem(int id, string nome)
            {
                this.id = id;
                this.nome = nome;
            }
        }

        public class UnidadeAnimal
        {
            public int id { get; set; }
            public string nome { get; set; }
        }

        #endregion Types
    }
}