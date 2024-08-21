namespace papelaria.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Modelo { get; set; }
        public decimal ValorUnitario { get; set; }
    }

    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; } = "Caxias do Sul";
        public string Estado { get; set; } = "RS";
    }

    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public int CargoId { get; set; }
        public Cargo Cargo { get; set; }
    }

    public class Cargo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Salario { get; set; }
        public string Descricao { get; set; }
    }

    public class Venda
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
    }


}
