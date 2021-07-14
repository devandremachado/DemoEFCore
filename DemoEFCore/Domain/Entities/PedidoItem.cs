namespace DemoEFCore.Domain.Entities
{
    public class PedidoItem
    {
        public PedidoItem(int produtoId, int quantidade, decimal valor, decimal desconto)
        {
            ProdutoId = produtoId;
            Quantidade = quantidade;
            Valor = valor;
            Desconto = desconto;
        }

        protected PedidoItem() { }

        public int Id { get; set; }
        public int PedidoId { get; private set; }
        public Pedido Pedido { get; private set; }
        public int ProdutoId { get; private set; }
        public Produto Produto { get; private set; }
        public int Quantidade { get; private set; }
        public decimal Valor { get; private set; }
        public decimal Desconto { get; private set; }
    }
}
