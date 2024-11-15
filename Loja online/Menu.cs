﻿using System;

using objetos;
using Objetos;
using Regras;
using Excecoes;
using Dados;


namespace Loja_online
{
    /// <summary>
    /// Purpose: classe para os menus
    /// Created by: Rafael silva
    /// Created on: 02/12/2023 14:59:10
    /// </summary>
    public class Menu
    {
        public void MenuPrincipal1(Produtos produtos, Marcas marcas, Stocks stocks, Clientes clientes, Funcionarios funcionarios, Managers managers, Vendas vendas, Campanhas campanhas, Fornecedores fornecedores, RegrasNegocio regras) 
        {
            
            int op, id;
            string pass;

            do
            {
                Console.WriteLine("Escolha uma opcao:");
                Console.WriteLine(" 0- Sair \n 1- Produto \n 2- Marca \n 3- Cliente \n 4- Venda \n 5- Stock \n 6- Campanha \n 7- Fornecedor \n 8- Manager");
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        MenuProduto(produtos, marcas, stocks, clientes, funcionarios, managers, vendas, campanhas, fornecedores, regras);
                        break;
                    case 2:
                        MenuMarca(produtos, marcas, stocks, clientes, funcionarios, managers, vendas, campanhas, fornecedores, regras);
                        break;
                    case 3:
                        MenuCliente(produtos, marcas, stocks, clientes, funcionarios, managers, vendas, campanhas, fornecedores, regras);
                        break;
                    case 4:
                        MenuVenda(produtos, marcas, stocks, clientes, funcionarios, managers, vendas, campanhas, fornecedores, regras);
                        break;
                    case 5:
                        MenuStock(produtos, marcas, stocks, clientes, funcionarios, managers, vendas, campanhas, fornecedores, regras);
                        break;
                    case 6:
                        MenuCampanha(produtos, marcas, stocks, clientes, funcionarios, managers, vendas, campanhas, fornecedores, regras);
                        break;
                    case 7:
                        MenuFornecedor(produtos, marcas, stocks, clientes, funcionarios, managers, vendas, campanhas, fornecedores, regras);
                        break;
                    case 8:
                        Console.WriteLine("Qual e o seu id?");
                        id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Qual a password ?");
                        pass = Console.ReadLine();
                        if (regras.Login(managers, id, pass))
                        {
                            MenuPrincipal2(produtos, marcas, stocks, clientes, funcionarios, managers, vendas, campanhas, fornecedores, regras);
                        }
                        break;
                    case 0:
                        break;
                }
            } while (op != 0);
            
            
        }

        public void MenuPrincipal2(Produtos produtos, Marcas marcas, Stocks stocks, Clientes clientes, Funcionarios funcionarios, Managers managers, Vendas vendas, Campanhas campanhas, Fornecedores fornecedores, RegrasNegocio regras)
        {
            int op;
            Console.WriteLine("Escolha uma opcao:");
            Console.WriteLine(" 0- Menu Principal \n 1- Funcionario \n 2- Manager");
            op = int.Parse(Console.ReadLine());
            do
            {
                switch (op)
                {
                    case 1:
                        MenuFuncionario(produtos, marcas, stocks, clientes, funcionarios, managers, vendas, campanhas, fornecedores, regras);
                        break;
                    case 2:
                        MenuManager(produtos, marcas, stocks, clientes, funcionarios, managers, vendas, campanhas, fornecedores, regras);
                        break;
                    case 0:
                        break;
                }
            } while (op != 0);
            
        }

        public void MenuMarca(Produtos produtos, Marcas marcas, Stocks stocks, Clientes clientes, Funcionarios funcionarios, Managers managers, Vendas vendas, Campanhas campanhas, Fornecedores fornecedores, RegrasNegocio regras)
        {
            IO io = new IO();

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
                        Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine("Qual o id da Marca que deseja alterar?");
                        id = int.Parse(Console.ReadLine());
                        regras.AlterarMarca(id, marcas);
                        Console.Clear();
                        break;
                    case 3:
                        Console.WriteLine("Qual o id da Marca que deseja alterar?");
                        id = int.Parse(Console.ReadLine());
                        regras.RetirarMarca(id, marcas);
                        Console.Clear();
                        break;
                    case 4:
                        io.MostrarMarcas(marcas);
                        
                        break;
                    case 5:
                        regras.GravarMarcas(marcas, @"dadosmarcas");
                        break;
                    case 0:
                        break;
                }
            } while (op != 0);
            Console.Clear();
            
        }

        public void MenuProduto(Produtos produtos, Marcas marcas, Stocks stocks, Clientes clientes, Funcionarios funcionarios, Managers managers, Vendas vendas, Campanhas campanhas, Fornecedores fornecedores, RegrasNegocio regras)
        {
            IO io = new IO();
            

            int op;
            int id, idv;
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

                        try
                        {
                            regras.InserirProduto(marcas, produtos, id);
                            break;
                        }
                        catch(ProdutosE e)
                        {
                            Console.WriteLine("Erro" + "-" + e.Message); 
                        }
                        Console.Clear();
                        break;

                    case 2:

                        Console.WriteLine("Qual o id do Produto que deseja alterar?");
                        id = int.Parse(Console.ReadLine());

                        try
                        {
                            regras.AlterarProduto(id, produtos);
                            break;
                        }
                        catch (ProdutosE e)
                        {
                            Console.WriteLine("Erro" + "-" + e.Message);
                        }
                        Console.Clear();
                        break;

                    case 3:

                        Console.WriteLine("Qual o id do Produto que deseja retirar da loja?");
                        id = int.Parse(Console.ReadLine());

                        regras.RetirarProduto(id, produtos);
                        Console.Clear();
                        break;

                    case 4:
                        Console.WriteLine("Qual o id do Produto que deseja devolver?");
                        id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Qual o id da venda em que consta o produto?");
                        idv = int.Parse(Console.ReadLine());

                        regras.DevolverProduto(id, idv, produtos, vendas, stocks);
                        Console.Clear();
                        break;
                    case 5:
                        regras.TrocarProduto(produtos, vendas, stocks);
                        Console.Clear();
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
                    case 0:
                        break;
                }
            } while (op != 0);
            Console.Clear();
            
        }

        public void MenuCliente(Produtos produtos, Marcas marcas, Stocks stocks, Clientes clientes, Funcionarios funcionarios, Managers managers, Vendas vendas, Campanhas campanhas, Fornecedores fornecedores, RegrasNegocio regras)
        {
            IO io = new IO();
            

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
                        Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine("Qual o id do Cliente que deseja alterar?");
                        id = int.Parse(Console.ReadLine());
                        regras.AlterarCliente(id, clientes);
                        Console.Clear();
                        break;
                    case 3:
                        Console.WriteLine("Qual o id do Cliente que deseja retirar?");
                        id = int.Parse(Console.ReadLine());
                        regras.RetirarCliente(id, clientes);
                        Console.Clear();
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
                    case 0:
                        break;
                }
            } while (opcao != 0);
            Console.Clear();
            
        }

        public void MenuVenda(Produtos produtos, Marcas marcas, Stocks stocks, Clientes clientes, Funcionarios funcionarios, Managers managers, Vendas vendas, Campanhas campanhas, Fornecedores fornecedores, RegrasNegocio regras) 
        {
            IO io = new IO();
            

            int opcao, id;
            do
            {
                Console.WriteLine("Escolha uma opcao:");
                Console.WriteLine(" 0- Menu Principal\n1- Realizar Venda\n2- Mostrar Venda\n3- Mostrar Venda Cliente\n4- Guardar Venda");
                opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        regras.RealizarVenda(vendas,clientes, stocks, produtos, campanhas);
                        Console.Clear();
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
                        regras.GuardarVendas(vendas, @"dadosvendas", @"dadosvendaproduto");
                        break;
                    case 0:
                        break;
                }
            } while (opcao != 0);
            Console.Clear();
            
        }

        public void MenuStock(Produtos produtos, Marcas marcas, Stocks stocks, Clientes clientes, Funcionarios funcionarios, Managers managers, Vendas vendas, Campanhas campanhas, Fornecedores fornecedores, RegrasNegocio regras)
        {

            IO io = new IO();
            

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

                        try
                        {
                            regras.InserirStock(stocks, produtos);
                            break;
                        }
                        catch(StockE e)
                        {
                            Console.WriteLine("Erro" + "-" + e.Message);
                        }
                        Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine("Qual o id do Produto que deseja acabar com o stock do mesmo?");
                        id = int.Parse(Console.ReadLine());
                        regras.AcabarStock(stocks, id);
                        Console.Clear();
                        break;
                    case 3:

                        try
                        {
                            regras.AdicionarStock(stocks, produtos);
                            break;
                        }
                        catch (StockE e)
                        {
                            Console.WriteLine("Erro" + "-" + e.Message);
                        }
                        Console.Clear();
                        break;
                    case 4:
                        regras.RetirarStock(stocks, produtos);
                        Console.Clear();
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
                    case 0:
                        break;
                }
            } while (op != 0);
            Console.Clear();
            
        }

        public void MenuCampanha(Produtos produtos, Marcas marcas, Stocks stocks, Clientes clientes, Funcionarios funcionarios, Managers managers, Vendas vendas, Campanhas campanhas, Fornecedores fornecedores, RegrasNegocio regras)
        {
            IO io = new IO();
            

            int opcao, idp, id;
            
            do
            {
                Console.WriteLine("Escolha uma opcao:");
                Console.WriteLine(" 0- Menu Principal\n1- Inserir Campanha\n2- Alterar Campanha\n3- Retirar Campanha\n4- Adicionar Produto a Campanha\n5- Retirar Produto da Campanha\n6- Mostrar Campanha\n7- Mostrar Produtos da Campanha\n8- Guardar Campanha");
                opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:

                        try
                        {
                            regras.InserirCampanha(campanhas);
                            Console.Clear();
                            break;
                        }
                        catch (CampanhaE e)
                        {
                            throw new CampanhaE("Erro" + "-" + e.Message);
                        }
                        
                    case 2:

                        Console.WriteLine("Qual o id da Campanha que deseja alterar?");
                        id = int.Parse(Console.ReadLine());

                        try
                        {
                            regras.AlterarCampanha(id, campanhas);
                            Console.Clear();
                            break;
                        }
                        catch (CampanhaE e)
                        {
                            throw new CampanhaE("Erro" + "-" + e.Message);
                        }
                        
                    case 3:

                        Console.WriteLine("Qual o id da Campanha que deseja alterar?");
                        id = int.Parse(Console.ReadLine());
                        regras.RetirarCampanha(id, campanhas);
                        Console.Clear();
                        break;
                    case 4:

                        Console.WriteLine("Qual o id do Produto que deseja adicionar a Campanha?");
                        idp = int.Parse(Console.ReadLine());
                        Console.WriteLine("Qual o id da Campanha que deseja alterar?");
                        id = int.Parse(Console.ReadLine());

                        try
                        {
                            regras.AdicionarProdutoCampanha(idp, id, produtos, campanhas);
                            Console.Clear();
                            break;
                        }
                        catch (CampanhaE e)
                        {
                            throw new CampanhaE("Erro" + "-" + e.Message);
                        }

                    case 5:
                        Console.WriteLine("Qual o id do Produto que deseja adicionar a Campanha?");
                        idp = int.Parse(Console.ReadLine());
                        Console.WriteLine("Qual o id da Campanha que deseja alterar?");
                        id = int.Parse(Console.ReadLine());

                        regras.RetirarProdutoCampanha(idp, id, produtos, campanhas);
                        Console.Clear();
                        break;
                    case 6:
                        io.MostrarCampanha(campanhas);
                        
                        break;

                    case 7:
                        Console.WriteLine("Qual o id da Campanha que deseja alterar?");
                        id = int.Parse(Console.ReadLine());

                        io.MostrarProdutoCampanha(id, campanhas);  
                        break;
                    case 8:
                        regras.GravarCampanha(@"dadoscampanhas", @"dadosprodutocampanha", campanhas);
                        break;
                    case 0:
                        break;
                }
            } while (opcao != 0);
            Console.Clear();
            
        }

        public void MenuFuncionario(Produtos produtos, Marcas marcas, Stocks stocks, Clientes clientes, Funcionarios funcionarios, Managers managers, Vendas vendas, Campanhas campanhas, Fornecedores fornecedores, RegrasNegocio regras)
        {
            IO io = new IO();
            

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
                        Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine("Qual o id do Cliente que deseja alterar?");
                        id = int.Parse(Console.ReadLine());
                        regras.AlterarFuncionario(funcionarios, id);
                        Console.Clear();
                        break;
                    case 3:
                        Console.WriteLine("Qual o id do Cliente que deseja retirar?");
                        id = int.Parse(Console.ReadLine());
                        regras.RetirarFuncionario(funcionarios, id);
                        Console.Clear();
                        break;
                    case 4:
                        io.MostrarFuncionarios(funcionarios);
                        
                        break;
                    case 5:
                        regras.GuardarFuncionario(funcionarios, @"dadosfuncionario");
                        break;
                    case 0:
                        break;
                }
            } while (opcao != 0);
            Console.Clear();
            
        }

        public void MenuManager(Produtos produtos, Marcas marcas, Stocks stocks, Clientes clientes, Funcionarios funcionarios, Managers managers, Vendas vendas, Campanhas campanhas, Fornecedores fornecedores, RegrasNegocio regras)
        {
            IO io = new IO();
            

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
                        Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine("Qual o id do Cliente que deseja alterar?");
                        id = int.Parse(Console.ReadLine());
                        regras.AlterarManager(managers, id);
                        Console.Clear();
                        break;
                    case 3:
                        Console.WriteLine("Qual o id do Cliente que deseja retirar?");
                        id = int.Parse(Console.ReadLine());
                        regras.RetirarManager(managers, id);
                        Console.Clear();
                        break;
                    case 4:
                        io.MostrarManagers(managers);
                        
                        break;
                    case 5:
                        regras.GuardarManager(managers, @"dadosmanager");
                        break;
                    case 0:
                        break;
                }
            } while (opcao != 0);
            Console.Clear();
        }

        public void MenuFornecedor(Produtos produtos, Marcas marcas, Stocks stocks, Clientes clientes, Funcionarios funcionarios, Managers managers, Vendas vendas, Campanhas campanhas, Fornecedores fornecedores, RegrasNegocio regras)
        {
            IO io = new IO();
            

            int opcao, id;
            do
            {
                Console.WriteLine("Escolha uma opcao:");
                Console.WriteLine(" 0- Menu Principal\n1- Inserir Fornecedor\n2- Alterar ClieFornecedornte\n3- Retirar Fornecedor\n4- Mostrar Fornecedores\n5- Mostrar Fornecedor\n6- Guardar Fornecedores");
                opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        regras.InserirFornecedor(fornecedores);
                        Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine("Qual o id do Cliente que deseja alterar?");
                        id = int.Parse(Console.ReadLine());
                        regras.AlterarFornecedor(id, fornecedores);
                        Console.Clear();
                        break;
                    case 3:
                        Console.WriteLine("Qual o id do Cliente que deseja retirar?");
                        id = int.Parse(Console.ReadLine());
                        regras.RetirarFornecedor(id, fornecedores);
                        Console.Clear();
                        break;
                    case 4:
                        io.MostrarFornecedores(fornecedores);
                        
                        break;
                    case 5:
                        Console.WriteLine("Qual o id do Cliente que deseja ver?");
                        id = int.Parse(Console.ReadLine());
                        io.MostrarFornecedor(fornecedores, id);
                        
                        break;
                    case 6:
                        regras.GuardarFornecedores(fornecedores, @"dadosfornecedores");
                        break;
                    case 0:
                        break;
                }
            } while (opcao != 0);
            Console.Clear();
            
        }
    }
}

