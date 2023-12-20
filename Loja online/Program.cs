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
            Menu menu = new Menu();

            regras.LerProduto(produtos, @"dadosprodutos");
            regras.LerClientes(clientes, @"dadosclientes");
            regras.LerMarcas(marcas, @"dadosmarcas");
            regras.LerStocks(stocks, @"dadosstock");
            regras.LerFuncionario(funcionarios, @"dadosfuncionario");
            regras.LerManager(managers, @"dadosmanager");
            regras.LerCampanhas(@"dadoscampanhas", @"dadosprodutocampanha", campanhas, produtos);

            /*
            regras.LerVendas(vendas, @"dadosvendas");
            */

            menu.MenuPrincipal(produtos, marcas, stocks, clientes, funcionarios, managers, vendas, campanhas);

            regras.GravarProduto(produtos, @"dadosprodutos");
            regras.GravarMarcas(marcas, @"dadosmarcas");
            regras.GuardarClientes(clientes, @"dadosclientes");
            regras.GuardarVendas(vendas, @"dadosvendas");
            regras.GravarStocks(stocks, @"dadosstock");
            regras.GuardarFuncionario(funcionarios, @"dadosfuncionario");
            regras.GuardarManager(managers, @"dadosmanager");
            regras.GravarCampanha(@"dadoscampanhas", @"dadosprodutocampanha", campanhas);
        }
    }
}
