using System;
using Regras;
using System.Security.Policy;
using Dados;
using objetos;
using Objetos;


namespace Loja_online
{
    /// <summary>
    /// Purpose: classe para os menus
    /// Created by: Rafael silva
    /// Created on: 02/12/2023 14:59:10
    /// </summary>
    public class Menu
    {
        public void MenuPrincipal(Produtos produtos, Marcas marcas, Stocks stocks, Clientes clientes, Funcionarios funcionarios, Managers managers, Vendas vendas, Campanhas campanhas) 
        {
            int op;
            Console.WriteLine("Escolha uma opcao:");
            Console.WriteLine(" 0- Sair \n 1- Produto \n 2- Marca \n 3- Cliente \n 4- Venda \n 5- Stock \n 6- Campanha \n 7- Funcioanrio \n 8- Manager");
            op = int.Parse(Console.ReadLine());
            do
            {
                switch (op)
                {
                    case 1:
                        MenuProduto(produtos, marcas, stocks, clientes, funcionarios, managers, vendas, campanhas);
                        break;
                    case 2:
                        MenuMarca(produtos, marcas, stocks, clientes, funcionarios, managers, vendas, campanhas);
                        break;
                    case 3:
                        MenuCliente(produtos, marcas, stocks, clientes, funcionarios, managers, vendas, campanhas);
                        break;
                    case 4:
                        MenuVenda(produtos, marcas, stocks, clientes, funcionarios, managers, vendas, campanhas);
                        break;
                    case 5:
                        MenuStock(produtos, marcas, stocks, clientes, funcionarios, managers, vendas, campanhas);
                        break;
                    case 6:
                        MenuCampanha(produtos, marcas, stocks, clientes, funcionarios, managers, vendas, campanhas);
                        break;
                    case 7:
                        MenuFuncionario(produtos, marcas, stocks, clientes, funcionarios, managers, vendas, campanhas);
                        break;
                    case 8:
                        MenuManager(produtos, marcas, stocks, clientes, funcionarios, managers, vendas, campanhas);
                        break;
                    case 0:
                        break;
                }
            } while (op != 0);
            Environment.Exit(0);
        }

        public void MenuMarca(Produtos produtos, Marcas marcas, Stocks stocks, Clientes clientes, Funcionarios funcionarios, Managers managers, Vendas vendas, Campanhas campanhas)
        {
            IO io = new IO();
            RegrasNegocio regras = new RegrasNegocio();

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
                        regras.InserirMarca(marcas);
                        break;
                    case 2:
                        Console.WriteLine("Qual o id da Marca que deseja alterar?");
                        id = int.Parse(Console.ReadLine());
                        regras.AlterarMarca(id, marcas);
                        break;
                    case 3:
                        Console.WriteLine("Qual o id da Marca que deseja alterar?");
                        id = int.Parse(Console.ReadLine());
                        regras.RetirarMarca(id, marcas);
                        break;
                    case 4:
                        io.MostrarMarcas(marcas);
                        break;
                    case 5:
                        regras.GravarMarcas(marcas, @"dadosmarcas");
                        break;
                }
            } while (op != 0);

            MenuPrincipal(produtos, marcas, stocks, clientes, funcionarios, managers, vendas, campanhas);
        }

        public void MenuProduto(Produtos produtos, Marcas marcas, Stocks stocks, Clientes clientes, Funcionarios funcionarios, Managers managers, Vendas vendas, Campanhas campanhas)
        {
            IO io = new IO();
            RegrasNegocio regras = new RegrasNegocio();

            int op;
            int id;
            bool aux;
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
                        regras.InserirProduto(marcas, produtos, id);
                        break;
                    case 2:
                        Console.WriteLine("Qual o id do Produto que deseja alterar?");
                        id = int.Parse(Console.ReadLine());
                        regras.AlterarProduto(id, produtos);
                        break;
                    case 3:
                        Console.WriteLine("Qual o id do Produto que deseja acabar com a venda?");
                        id = int.Parse(Console.ReadLine());
                        regras.RetirarProduto(id, produtos);
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
                        Console.WriteLine("Qual o id da marca que deseja ver os produtos?");
                        id = int.Parse(Console.ReadLine());
                        io.MostrarProdutosMarca(produtos, id);
                        break;
                    case 8:
                        regras.GravarProduto(produtos, @"dadosprodutos");
                        break;

                }
            } while (op != 0);
            
            MenuPrincipal(produtos, marcas, stocks, clientes, funcionarios, managers, vendas, campanhas);
        }

        public void MenuCliente(Produtos produtos, Marcas marcas, Stocks stocks, Clientes clientes, Funcionarios funcionarios, Managers managers, Vendas vendas, Campanhas campanhas)
        {
            IO io = new IO();
            RegrasNegocio regras = new RegrasNegocio();

            int opcao, id;
            do
            {
                Console.WriteLine("Escolha uma opcao:");
                Console.WriteLine(" 0- Menu Principal\n1- Inserir Cliente\n2- Alterar Cliente\n3- Retirar Cliente\n4- Mostrar Clientes\n5- Mostrar Cliente\n6- Guardar Clientes");
                opcao = int.Parse(Console.ReadLine());
                switch(opcao) 
                {
                    case 1:
                        regras.InserirCliente(clientes);
                        break;
                    case 2:
                        Console.WriteLine("Qual o id do Cliente que deseja alterar?");
                        id = int.Parse(Console.ReadLine());
                        regras.AlterarCliente(id, clientes);
                        break;
                    case 3:
                        Console.WriteLine("Qual o id do Cliente que deseja retirar?");
                        id = int.Parse(Console.ReadLine());
                        regras.RetirarCliente(id, clientes);
                        break;
                    case 4:
                        io.MostrarClientes(clientes);
                        break; 
                    case 5:
                        Console.WriteLine("Qual o id do Cliente que deseja ver?");
                        id = int.Parse(Console.ReadLine());
                        io.MostrarCliente(clientes, id);
                        break;
                    case 6:
                        regras.GuardarClientes(clientes, @"dadosclientes");
                        break;
                }
            } while (opcao != 0);
            
            MenuPrincipal(produtos, marcas, stocks, clientes, funcionarios, managers, vendas, campanhas);
        }

        public void MenuVenda(Produtos produtos, Marcas marcas, Stocks stocks, Clientes clientes, Funcionarios funcionarios, Managers managers, Vendas vendas, Campanhas campanhas) 
        {
            IO io = new IO();
            RegrasNegocio regras = new RegrasNegocio();

            int opcao, id;
            do
            {
                Console.WriteLine("Escolha uma opcao:");
                Console.WriteLine(" 0- Menu Principal\n1- RealizarVenda\n2- Mostrar Venda\n3- Mostrar Venda Cliente\n4- Guardar Manager");
                opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        //regras.RealizarVenda(vendas,produtos,clientes);
                        break;
                    case 2:
                        io.MostrarVendas(vendas);
                        break;
                    case 3:
                        Console.WriteLine("Qual o id do Cliente que deseja ver as vendas?");
                        id = int.Parse(Console.ReadLine());
                        io.MostrarVendasCliente(vendas, id);
                        break;
                    case 4:
                        regras.GuardarVendas(vendas, @"dadosvendas");
                        break;
                }
            } while (opcao != 0);

            MenuPrincipal(produtos, marcas, stocks, clientes, funcionarios, managers, vendas, campanhas);
        }

        public void MenuStock(Produtos produtos, Marcas marcas, Stocks stocks, Clientes clientes, Funcionarios funcionarios, Managers managers, Vendas vendas, Campanhas campanhas)
        {

            IO io = new IO();
            RegrasNegocio regras = new RegrasNegocio();

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
                        regras.InserirStock(stocks, produtos);
                        break;
                    case 2:
                        Console.WriteLine("Qual o id do Produto que deseja acabar com o stock do mesmo?");
                        id = int.Parse(Console.ReadLine());
                        regras.AcabarStock(stocks, id);
                        break;
                    case 3:
                        regras.AdicionarStock(stocks, produtos);
                        break;
                    case 4:
                        regras.RetirarStock(stocks, produtos);
                        break;
                    case 5:
                        io.MostrarStock(stocks);
                        break;
                    case 6:
                        Console.WriteLine("Qual o id do Produto que deseja ver o stock?");
                        id = int.Parse(Console.ReadLine());
                        io.MostrarStockProduto(stocks, id);
                        break;
                    case 7:
                        regras.GravarStocks(stocks, @"dadosstock");
                        break;
                }
            } while (op != 0);

            MenuPrincipal(produtos, marcas, stocks, clientes, funcionarios, managers, vendas, campanhas);
        }

        public void MenuCampanha(Produtos produtos, Marcas marcas, Stocks stocks, Clientes clientes, Funcionarios funcionarios, Managers managers, Vendas vendas, Campanhas campanhas)
        {
            IO io = new IO();
            RegrasNegocio regras = new RegrasNegocio();

            int opcao, id;
            string nome;
            do
            {
                Console.WriteLine("Escolha uma opcao:");
                Console.WriteLine(" 0- Menu Principal\n1- Inserir Campanha\n2- Alterar Campanha\n3- Retirar Campanha\n4- Adicionar Produto a Campanha\n5- Retirar Produto da Campanha\n6- Mostrar Campanha\n7- Mostrar Produtos da Campanha\n8- Guardar Campanha");
                opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        regras.InserirCampanha(campanhas);
                        break;
                    case 2:
                        Console.WriteLine("Qual o nome da Campanha que deseja alterar?");
                        nome = Console.ReadLine();
                        regras.AlterarCampanha(nome,campanhas);
                        break;
                    case 3:
                        Console.WriteLine("Qual o nome da Campanha que deseja retirar?");
                        nome = Console.ReadLine();
                        regras.RetirarCampanha(nome, campanhas);
                        break;
                    case 4:
                        Console.WriteLine("Qual o id do Produto que deseja adicionar a Campanha?");
                        id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Qual o nome da Campanha que deseja adicionar o produto?");
                        nome = Console.ReadLine();
                        regras.AdicionarProdutoCampanha(id, nome, produtos, campanhas);
                        break;
                    case 5:
                        Console.WriteLine("Qual o id do Produto que deseja adicionar a Campanha?");
                        id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Qual o nome da Campanha que deseja adicionar o produto?");
                        nome = Console.ReadLine();
                        regras.RetirarProdutoCampanha(id, nome, produtos, campanhas);
                        break;
                    case 6:
                        io.MostrarCampanha(campanhas);
                        break;
                    case 7:
                        Console.WriteLine("Qual o nome da Campanha que deseja ver os Produtos?");
                        nome = Console.ReadLine();
                        io.MostrarProdutoCampanha(nome, campanhas);
                        break;
                    case 8:
                        regras.GravarCampanha(@"dadoscampanhas", @"dadosprodutocampanha", campanhas);
                        break;
                }
            } while (opcao != 0);

            MenuPrincipal(produtos, marcas, stocks, clientes, funcionarios, managers, vendas, campanhas);
        }

        public void MenuFuncionario(Produtos produtos, Marcas marcas, Stocks stocks, Clientes clientes, Funcionarios funcionarios, Managers managers, Vendas vendas, Campanhas campanhas)
        {
            IO io = new IO();
            RegrasNegocio regras = new RegrasNegocio();

            int opcao, id;
            do
            {
                Console.WriteLine("Escolha uma opcao:");
                Console.WriteLine(" 0- Menu Principal\n1- Inserir Funcionario\n2- Alterar Funcionario\n3- Retirar Funcionario\n4- Mostrar Funcionario\n5- Guardar Funcionario");
                opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        regras.InserirFuncionario(funcionarios);
                        break;
                    case 2:
                        Console.WriteLine("Qual o id do Cliente que deseja alterar?");
                        id = int.Parse(Console.ReadLine());
                        regras.AlterarFuncionario(funcionarios, id);
                        break;
                    case 3:
                        Console.WriteLine("Qual o id do Cliente que deseja retirar?");
                        id = int.Parse(Console.ReadLine());
                        regras.RetirarFuncionario(funcionarios, id);
                        break;
                    case 4:
                        io.MostrarFuncionarios(funcionarios);
                        break;
                    case 5:
                        regras.GuardarFuncionario(funcionarios, @"dadosfuncionario");
                        break;
                }
            } while (opcao != 0);

            MenuPrincipal(produtos, marcas, stocks, clientes, funcionarios, managers, vendas, campanhas);
        }

        public void MenuManager(Produtos produtos, Marcas marcas, Stocks stocks, Clientes clientes, Funcionarios funcionarios, Managers managers, Vendas vendas, Campanhas campanhas)
        {
            IO io = new IO();
            RegrasNegocio regras = new RegrasNegocio();

            int opcao, id;
            do
            {
                Console.WriteLine("Escolha uma opcao:");
                Console.WriteLine(" 0- Menu Principal\n1- Inserir Manager\n2- Alterar Manager\n3- Retirar Manager\n4- Mostrar Manager\n5- Guardar Manager");
                opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        regras.InserirManager(managers);
                        break;
                    case 2:
                        Console.WriteLine("Qual o id do Cliente que deseja alterar?");
                        id = int.Parse(Console.ReadLine());
                        regras.AlterarManager(managers, id);
                        break;
                    case 3:
                        Console.WriteLine("Qual o id do Cliente que deseja retirar?");
                        id = int.Parse(Console.ReadLine());
                        regras.RetirarManager(managers, id);
                        break;
                    case 4:
                        io.MostrarManagers(managers);
                        break;
                    case 5:
                        regras.GuardarManager(managers, @"dadosmanager");
                        break;
                }
            } while (opcao != 0);

            MenuPrincipal(produtos, marcas, stocks, clientes, funcionarios, managers, vendas, campanhas);

            
        }
    }
}

