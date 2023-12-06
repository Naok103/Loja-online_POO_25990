using System;
using Regras;
using System.Security.Policy;
using Dados;


namespace Loja_online
{
    /// <summary>
    /// Purpose:
    /// Created by: Rafael silva
    /// Created on: 02/12/2023 14:59:10
    /// </summary>
    internal class Menu
    {
        public void MenuPrincipal() 
        {
            int op;
            Console.WriteLine("Escolha uma opcao:");
            Console.WriteLine(" 0- Sair \n 1- Produto \n 2- Marca \n 3- Cliente \n 4- Venda \n 5- Stock \n 6- Campanha");
            op = int.Parse(Console.ReadLine());
            switch (op)
            {
                case 1:
                    MenuProduto();
                    break;
                case 2:
                    MenuMarca();
                    break;
                case 3:
                    MenuCliente();
                    break;
                case 4:
                    MenuVenda();
                    break;
                case 5:
                    MenuStock();
                    break; 
                case 6:
                    MenuCampanha();
                    break;
                case 0:
                    break;    
            }
        }

        public void MenuMarca()
        {
            IO io = new IO();
            Marcas marcas = new Marcas();
            RegrasNegocio regras = new RegrasNegocio();
            marcas = regras.LerMarcas(marcas, @"dadosmarcas");
            int op;
            int id;
            do
            {
                Console.WriteLine("Escolha uma opcao:");
                Console.WriteLine(" 0- Menu Principal\n1- Inserir Marca\n2- Alterar Marca\n3- Retirar Marca\n4- Mostrar marcas\n5- Guardar Marcas");
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        regras.InserirMarca();
                        break;
                    case 2:
                        Console.WriteLine("Qual o id da Marca que deseja alterar?");
                        id = int.Parse(Console.ReadLine());
                        regras.AlterarMarca(id);
                        break;
                    case 3:
                        Console.WriteLine("Qual o id da Marca que deseja alterar?");
                        id = int.Parse(Console.ReadLine());
                        regras.RetirarMarca(id);
                        break;
                    case 4:
                        io.MostrarMarcas(marcas);
                        break;
                    case 5:
                        regras.GravarMarcas(marcas, @"dadosmarcas");
                        break;
                }
            } while (op != 0);
            regras.GravarMarcas(marcas, @"dadosmarcas");
            MenuPrincipal();
        }

        public void MenuProduto()
        {
            IO io = new IO();
            Produtos produtos = new Produtos();
            Marcas marcas = new Marcas();
            RegrasNegocio regras = new RegrasNegocio();
            marcas = regras.LerMarcas(marcas, @"dadosmarcas");
            //produtos = regras.LerProdutos(produtos, @"dadosprodutos");
            int op;
            int id;
            do
            {
                Console.WriteLine("Escolha uma opcao:");
                Console.WriteLine(" 0- Menu Principal\n1- Inserir Produto\n2- Alterar Produto\n3- Retirar produto\n4- Devolver Produto\n5- Trocar Produtos\n6- Mostrar Produtos\n7- Mostrar Produtos de uma Marca\n8- Guardar Produto");
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Console.WriteLine("Qual o id da Marca ao qual o Produto que deseja adicionar pertence?");
                        id = int.Parse(Console.ReadLine());
                        regras.InserirProduto(marcas,id);
                        break;
                    case 2:
                        Console.WriteLine("Qual o id do Produto que deseja alterar?");
                        id = int.Parse(Console.ReadLine());
                        regras.AlterarProduto(id);
                        break;
                    case 3:
                        Console.WriteLine("Qual o id do Produto que deseja acabar com a venda?");
                        id = int.Parse(Console.ReadLine());
                        regras.RetirarProduto(id);
                        break;
                    case 4:
                        //desenvolver
                        break;
                    case 5:
                        //desenvolver
                        break;
                    case 6:
                        io.MostrarProdutos(produtos);
                        break;
                    case 7:
                        Console.WriteLine("Qual o id do Produto que deseja ver o stock?");
                        id = int.Parse(Console.ReadLine());
                        io.MostrarProdutosMarca(produtos, id);
                        break;
                    case 8:
                        regras.GravarProduto(produtos, @"dadosprodutos");
                        break;
                }
            } while (op != 0);
            regras.GravarProduto(produtos, @"dadosprodutos");
            MenuPrincipal();
        }

        public void MenuCliente()
        {

        }

        public void MenuVenda() 
        {

        }

        public void MenuStock()
        {

            IO io = new IO();
            Stocks stock = new Stocks();
            RegrasNegocio regras = new RegrasNegocio();
            //stock = regras.LerStocks(stock, @"dadosstock");
            int op;
            int id;
            do
            {
                Console.WriteLine("Escolha uma opcao:");
                Console.WriteLine(" 0- Menu Principal\n1- Inserir Stock\n2- Acabar Stock\n3- Adicionar Stock\n4- Retirar Stock\n5- Mostrar Stock\n6- Mostrar Stock de um Produto\n7- Guardar Stock");
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        regras.InserirStock();
                        break;
                    case 2:
                        Console.WriteLine("Qual o id do Produto que deseja acabar com o stock do mesmo?");
                        id = int.Parse(Console.ReadLine());
                        regras.AcabarStock(id);
                        break;
                    case 3:
                        regras.AdicionarStock();
                        break;
                    case 4:
                        regras.RetirarStock();
                        break;
                    case 5:
                        io.MostrarStock(stock);
                        break;
                    case 6:
                        Console.WriteLine("Qual o id do Produto que deseja ver o stock?");
                        id = int.Parse(Console.ReadLine());
                        io.MostrarStockProduto(stock, id);
                        break;
                    case 7:
                        regras.GravarStocks(stock, @"dadosstock");
                        break;
                }
            } while (op != 0);
            regras.GravarStocks(stock, @"dadosstock");
            MenuPrincipal();
        }

        public void MenuCampanha()
        {

        }
    }
}

