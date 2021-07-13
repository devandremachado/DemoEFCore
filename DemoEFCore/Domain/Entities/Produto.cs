using DemoEFCore.Domain.Enums;

namespace DemoEFCore.Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string CodigoBarras { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public ETipoProduto TipoProduto { get; set; }
        public bool Ativo { get; set; }
    }
}
