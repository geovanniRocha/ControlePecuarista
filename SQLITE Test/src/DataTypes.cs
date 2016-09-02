namespace Data_Persistent
{
    public static class DataTypes
    {
        #region Types

        public class Maquinario
        {
            public int id { get; set; }
            public string nome { get; set; }
            public string descricao { get; set; }
            public int valor { get; set; }

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
        }

        public class Gastos
        {
            public int id { get; set; }
            public string nome { get; set; }
            public string descricao { get; set; }
            public int valor { get; set; }
            public string data { get; set; }


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
        }

        public class Combustivel
        {
            public int id { get; set; }
        }

        public class Pastagem
        {
            public int id { get; set; }
        }

        public class TipoPastagem
        {
            public int id { get; set; }
        }

        public class UnidadeAnimal
        {
            public int id { get; set; }
        }

        #endregion Types
    }
}