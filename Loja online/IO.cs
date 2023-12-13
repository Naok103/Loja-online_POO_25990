using Objetos;
using Dados;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Collections;
using System.ComponentModel;
using System.Runtime;
using System.Diagnostics.Contracts;

namespace Loja_online
{
    /// <summary>
    /// Purpose: classe com funcoes que interagem com a consola
    /// Created by: Rafael silva
    /// Created on: 14/11/2023 21:57:46
    /// </summary>
    public class IO
    {
        #region CLIENTE

        public void MostrarClientes(Clientes clientes) 
        {
            foreach (Cliente cliente in clientes)
            {
                Console.WriteLine("Nome: {0}, Id: {1}, Contacto: {2}, Nif: {3}, Morada: {4}", cliente.Nome, cliente.Id, cliente.Contacto, cliente.Nif, cliente.Morada);
            }
        }

        public void MostrarCliente(Clientes clientes, int id)
        {
            foreach (Cliente cliente in clientes)
            {
                if(cliente.Id == id)
                {
                    Console.WriteLine("Nome: {0}, Id: {1}, Contacto: {2}, Nif: {3}, Morada: {4}", cliente.Nome, cliente.Id, cliente.Contacto, cliente.Nif, cliente.Morada);
                }
            }
        }

        public void DadosClientes(out string nome, out int contacto, out int nif, out string morada)
        {
            Console.WriteLine("Qual o nome do cliente?");
            nome = Console.ReadLine();
            Console.WriteLine("Qual o contacto do cliente?");
            contacto = int.Parse(Console.ReadLine());
            Console.WriteLine("Qual o nif do cliente?");
            nif = int.Parse(Console.ReadLine());
            Console.WriteLine("Qual a morada do cliente?");
            morada = Console.ReadLine();
        }

        public void AlterarDadosC(out int d, out string nome, out int contacto, out int nif, out string morada)
        {
            nome = "";
            nif = 0;
            contacto = 0;
            morada = "";
            d = 0;
            int a;
            do
            {
                Console.WriteLine("Que dados deseja alterar (0 - sair, 1 - nome, 2 - contacto, 3 - nif, 4 - morada)?");
                a = int.Parse(Console.ReadLine());

                if (a == 1)
                {
                    Console.WriteLine("Qual o novo nome do cliente?");
                    nome = Console.ReadLine();
                    d = a;
                }
                else if (a == 2)
                {
                    Console.WriteLine("Qual o novo contacto do cliente?");
                    contacto = int.Parse(Console.ReadLine());
                    d = a;
                }
                else if (a == 3)
                {
                    Console.WriteLine("Qual o novo nif do cliente?");
                    nif = int.Parse(Console.ReadLine());
                    d = a;
                }
                else if (a == 4)
                {
                    Console.WriteLine("Qual a nova morada do cliente?");
                    morada = Console.ReadLine();
                    d = a;
                }
                else if (a != 0)
                {
                    Console.WriteLine("Escolha um numero correto");
                }
            } while (a != 0);
        }

        #endregion

        #region PRODUTO

        public void MostrarProdutos(Produtos p)
        {
            foreach(Produto produto in p)
            {
                Console.WriteLine("Id Produto: {1}, Nome: {2}, Categoria: {3}, Preco: {4}, Garantia: {5}, Id Marca: {6}", produto.Id, produto.Nome, produto.Categoria, produto.Preco, produto.Garantia, produto.IdM);
            }
        }

        public void MostrarProdutosMarca(Produtos p, int id)
        {
            foreach (Produto produto in p)
            {
                if(produto.IdM == id)
                {
                    Console.WriteLine("Id Produto: {1}, Nome: {2}, Categoria: {3}, Preco: {4}, Garantia: {5}, Id Marca: {6}", produto.Id, produto.Nome, produto.Categoria, produto.Preco, produto.Garantia, produto.IdM);
                }
            }
        }

        public void DadosProdutos(out string nome, out string categoria, out int preco, out int garantia)
        {
            Console.WriteLine("Qual o nome do produto?");
            nome = Console.ReadLine();
            Console.WriteLine("Qual a categoria a qual o produto pertence?");
            categoria = Console.ReadLine();
            Console.WriteLine("Qual o preco do produto?");
            preco = int.Parse(Console.ReadLine());
            Console.WriteLine("Qual a garantia do produto?");
            garantia = int.Parse(Console.ReadLine());
        }

        public void AlterarDadosP(out string nome, out string categoria, out int preco, out int garantia, out int i)
        {
            categoria = "";
            nome = "";
            i = 0;
            preco = 0;
            garantia= 0;
            int a;
            do
            {
                Console.WriteLine("Que dados deseja alterar (0 - sair, 1 - nome, 2 - categoria, 3 - preco, 4 - garantia)?");
                a = int.Parse(Console.ReadLine());

                if (a == 1)
                {
                    Console.WriteLine("Qual o novo nome da marca?");
                    nome = Console.ReadLine();
                    i = a;
                }
                else if (a == 2)
                {
                    Console.WriteLine("Qual o novo site da marca?");
                    categoria = Console.ReadLine();
                    i = a;
                }
                else if (a == 3)
                {
                    Console.WriteLine("Qual o novo site da marca?");
                    preco = int.Parse(Console.ReadLine());
                    i = a;
                }
                else if (a == 4)
                {
                    Console.WriteLine("Qual o novo site da marca?");
                    garantia = int.Parse(Console.ReadLine());
                    i = a;
                }
                else if (a != 0)
                {
                    Console.WriteLine("Escolha um numero correto");
                }
            } while (a != 0);
        }
    

        #endregion

        #region MARCA

        public void MostrarMarcas(Marcas m)
        {
            foreach (Marca marca in m)
            {
                Console.WriteLine("Id: {0}, Nome: {1}, Site: {2}", marca.Id, marca.Nome, marca.Site);
            }
        }

        public void DadosMarca(out string nome, out string site)
        {
            Console.WriteLine("Qual o nome da marca?");
            nome = Console.ReadLine();
            Console.WriteLine("Qual o site da marca?");
            site = Console.ReadLine();
        }

        public void AlterarDadosM(out string nome, out string site, out int i)
        {
            site = "";
            nome = "";
            i = 0;
            int a;
            do
            {
                Console.WriteLine("Que dados deseja alterar (0 - sair, 1 - nome, 2 - site )?");
                a = int.Parse(Console.ReadLine());
                
                if (a == 1)
                {
                    Console.WriteLine("Qual o novo nome da marca?");
                    nome = Console.ReadLine();
                    i = a;
                }
                else if (a == 2)
                {
                    Console.WriteLine("Qual o novo site da marca?");
                    site = Console.ReadLine();
                    i = a;
                }
                else if(a != 0)
                {
                    Console.WriteLine("Escolha um numero correto");
                }
            } while (a != 0); 
        }

        #endregion

        #region VENDA

        public void MostrarVendas(Venda v) { }

        public void MostrarVendasCliente(Venda v, Cliente c) { }

        #endregion

        #region STOCK

        public void MostrarStock(Stocks s)
        {
            foreach (Stock stock in s)
            {
                Console.WriteLine("Id stock: {0}, Quantidade: {1}, Id Produto: {2}", stock.ID, stock.Quantidade, stock.IDP);
            }
        }

        public void MostrarStockProduto(Stocks s, int id) 
        {
            foreach (Stock stock in s)
            {
                if(stock.IDP == id)
                {
                    Console.WriteLine("Id stock: {0}, Quantidade: {1}, Id Produto: {2}", stock.ID, stock.Quantidade, stock.IDP);
                }
            }
        }

        public void DadosStock(out int idP, out int quantidade)
        {
            Console.WriteLine("Qual o id do Produto?");
            idP = int.Parse(Console.ReadLine());
            Console.WriteLine("Qual a quantidade do Produto?");
            quantidade = int.Parse(Console.ReadLine());
        }

        #endregion

        #region CAMPANHA

        public void MostrarCampanha(Campanha c) { }

        #endregion

        #region FUNCIONARIO



        #endregion

        #region MANAGER



        #endregion
    }
}

