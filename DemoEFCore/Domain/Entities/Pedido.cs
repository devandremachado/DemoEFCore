using DemoEFCore.Domain.Enums;
using System;
using System.Collections.Generic;

namespace DemoEFCore.Domain.Entities
{
    public class Pedido
    {
        public Pedido(int clienteId, DateTime iniciadoEm, DateTime finalizadoEm, ETipoFrete tipoFrete, EStatusPedido status, string observacao, ICollection<PedidoItem> itens)
        {
            ClienteId = clienteId;
            IniciadoEm = iniciadoEm;
            FinalizadoEm = finalizadoEm;
            TipoFrete = tipoFrete;
            Status = status;
            Observacao = observacao;
            Itens = itens;
        }

        protected Pedido() { }

        public int Id { get; private set; }
        public int ClienteId { get; private set; }
        public Cliente Cliente { get; private set; }
        public DateTime IniciadoEm { get; private set; }
        public DateTime FinalizadoEm { get; private set; }
        public ETipoFrete TipoFrete { get; private set; }
        public EStatusPedido Status { get; private set; }
        public string Observacao { get; private set; }
        public ICollection<PedidoItem> Itens { get; private set; }
    }
}
