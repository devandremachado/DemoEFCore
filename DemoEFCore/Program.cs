using DemoEFCore.Data;
using DemoEFCore.Domain.Entities;
using DemoEFCore.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoEFCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var sair = false;

            do
            {
                Console.Clear();
                Console.WriteLine("Operações EF: \n");
                Console.WriteLine("1 - Incluir Cliente");
                Console.WriteLine("2 - Incluir Produto");
                Console.WriteLine("3 - Incluir Varios Produtos");
                Console.WriteLine("4 - Incluir Produto e Cliente");
                Console.WriteLine("5 - Obter Todos Produto");
                Console.WriteLine("6 - Obter Primeiro Produto");
                Console.WriteLine("7 - Incluir Pedido");
                Console.WriteLine("8 - Obter Todos Pedidos");
                Console.WriteLine("9 - Atualizar Cliente");
                Console.WriteLine("10 - Atualizar Cliente Campos Dinamicos");
                Console.WriteLine("11 - Remover Cliente");
                Console.WriteLine("\n0 - Sair");

                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "0":
                        sair = true;
                        break;

                    case "1":
                        IncluirCliente();
                        break;

                    case "2":
                        IncluirProduto();
                        break;

                    case "3":
                        IncluirVariosProdutos();
                        break;

                    case "4":
                        IncluirProdutoECliente();
                        break;

                    case "5":
                        ObterTodosProdutos();
                        break;

                    case "6":
                        ObterPrimeiroProduto();
                        break;

                    case "7":
                        IncluirPedido();
                        break;

                    case "8":
                        ObterTodosPedidos();
                        break;

                    case "9":
                        AtualizarCliente();
                        break;

                    case "10":
                        AtualizarClienteCamposDinamicos();
                        break;


                    case "11":
                        RemoverCliente();
                        break;


                    default:
                        Console.WriteLine("Errrrrou");
                        break;
                }

            } while (sair != true);
        }

        private static void IncluirCliente()
        {
            using var db = new ApplicationContext();

            var cliente = new Cliente("Cliente A", "123", "123", "SP", "São Paulo", "clienteA@gmail.com");

            db.Clientes.Add(cliente);
            db.SaveChanges();
        }

        private static void IncluirProduto()
        {
            using var db = new ApplicationContext();

            var produto = new Produto("Produto A", "11", 10m, ETipoProduto.MercadoriaParaRevenda, true);

            db.Produtos.Add(produto);
            db.SaveChanges();
        }

        private static void IncluirVariosProdutos()
        {
            using var db = new ApplicationContext();

            var produtos = new List<Produto>
            {
                new Produto("Produto B", "22", 10m, ETipoProduto.MercadoriaParaRevenda, true),
                new Produto("Produto C", "33", 10m, ETipoProduto.MercadoriaParaRevenda, true),
                new Produto("Produto D", "44", 10m, ETipoProduto.MercadoriaParaRevenda, true)
            };

            db.Produtos.AddRange(produtos);
            db.SaveChanges();
        }

        private static void IncluirProdutoECliente()
        {
            using var db = new ApplicationContext();

            var produto = new Produto("Produto E", "55", 20m, ETipoProduto.Servico, true);
            var cliente = new Cliente("Cliente B", "321", "13214777", "SP", "São Paulo", "ClienteB@gmail.com");

            db.AddRange(produto, cliente);
            db.SaveChanges();
        }

        private static void ObterTodosProdutos()
        {
            using var db = new ApplicationContext();

            var produtos = db.Produtos.ToList();

            Console.WriteLine(produtos.Count());
        }

        private static void ObterPrimeiroProduto()
        {
            using var db = new ApplicationContext();

            var produto = db.Produtos.Where(p => p.Id == 1).FirstOrDefault();

            if (produto == null) return;

            Console.WriteLine(produto.Descricao);
        }

        private static void IncluirPedido()
        {
            using var db = new ApplicationContext();

            var cliente = db.Clientes.FirstOrDefault();
            var produto = db.Produtos.FirstOrDefault();

            var itens = new List<PedidoItem>
            {

                new PedidoItem(produto.Id, 5, 100, 0),
                new PedidoItem(produto.Id, 3, 25, 0)
            };

            var pedido = new Pedido(cliente.Id, DateTime.Now, DateTime.Now, ETipoFrete.SemFrete, EStatusPedido.Analise, "Pedido Teste", itens);

            db.Pedidos.Add(pedido);
            db.SaveChanges();

        }

        private static void ObterTodosPedidos()
        {
            using var db = new ApplicationContext();

            var pedidos = db
                .Pedidos
                .Include(c => c.Cliente)
                .Include(i => i.Itens)
                    .ThenInclude(p =>p.Produto)
                .ToList();

            Console.WriteLine(pedidos.Count());
        }

        private static void AtualizarCliente()
        {
            using var db = new ApplicationContext();

            var cliente = db.Clientes.FirstOrDefault(c => c.Id == 1);

            if (cliente == null) return;

            cliente.AlterarNome("Cliente A Update");

            db.SaveChanges();
        }

        private static void AtualizarClienteCamposDinamicos()
        {
            using var db = new ApplicationContext();

            var cliente = db.Clientes.FirstOrDefault(c => c.Id == 1);

            if (cliente == null) return;

            var objCliente = new
            {
                Nome = "Cliente Dinamico",
                Telefone = "777"
            };

            // A query de update é montada dinamicamente, apenas com os campos informados no objeto anonimo
            db.Entry(cliente).CurrentValues.SetValues(objCliente);

            db.SaveChanges();
        }

        private static void RemoverCliente()
        {
            using var db = new ApplicationContext();

            var cliente = db.Clientes.FirstOrDefault();

            if (cliente == null) return;

            db.Clientes.Remove(cliente);
            db.SaveChanges();
        }
    }
}
