using DemoEFCore.Domain.Enums;

namespace DemoEFCore.Domain.Entities
{
    public class Produto
    {
        public Produto(string descricao, string codigoBarras, decimal valor, ETipoProduto tipoProduto, bool ativo)
        {
            Descricao = descricao;
            CodigoBarras = codigoBarras;
            Valor = valor;
            TipoProduto = tipoProduto;
            Ativo = ativo;
        }

        protected Produto() { }

        public int Id { get; private set; }
        public string Descricao { get; private set; }
        public string CodigoBarras { get; private set; }
        public decimal Valor { get; private set; }
        public ETipoProduto TipoProduto { get; private set; }
        public bool Ativo { get; private set; }
    }
}
