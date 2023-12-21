using Dados;
using Objetos;
using Regras;
using System;


namespace Loja_online
{
     class Program
    {
        static void Main(string[] args)
        {
            Produtos produtos = new Produtos();
            Marcas marcas = new Marcas();
            Stocks stocks = new Stocks();
            Clientes clientes = new Clientes();
            Funcionarios funcionarios = new Funcionarios();
            Managers managers = new Managers();
            Vendas vendas = new Vendas();
            Campanhas campanhas = new Campanhas();
            RegrasNegocio regras = new RegrasNegocio();
            Fornecedores fornecedores = new Fornecedores();
            Menu menu = new Menu();

            produtos = regras.LerProduto(produtos, @"dadosprodutos");
            clientes = regras.LerClientes(clientes, @"dadosclientes");
            marcas = regras.LerMarcas(marcas, @"dadosmarcas");
            stocks = regras.LerStocks(stocks, @"dadosstock");
            funcionarios = regras.LerFuncionario(funcionarios, @"dadosfuncionario");
            managers = regras.LerManager(managers, @"dadosmanager");
            campanhas = regras.LerCampanhas(@"dadoscampanhas", @"dadosprodutocampanha", campanhas, produtos);
            fornecedores = regras.LerFornecedores(fornecedores, @"dadosfornecedores");

            /*
            regras.LerVendas(vendas, @"dadosvendas");
            */

            menu.MenuPrincipal(produtos, marcas, stocks, clientes, funcionarios, managers, vendas, campanhas, fornecedores);

            regras.GravarProduto(produtos, @"dadosprodutos");
            regras.GravarMarcas(marcas, @"dadosmarcas");
            regras.GuardarClientes(clientes, @"dadosclientes");
            regras.GuardarVendas(vendas, @"dadosvendas");
            regras.GravarStocks(stocks, @"dadosstock");
            regras.GuardarFuncionario(funcionarios, @"dadosfuncionario");
            regras.GuardarManager(managers, @"dadosmanager");
            regras.GravarCampanha(@"dadoscampanhas", @"dadosprodutocampanha", campanhas);
            regras.GuardarFornecedores(fornecedores, @"dadosfornecedores");
        }
    }
}
