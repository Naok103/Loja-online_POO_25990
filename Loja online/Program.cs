﻿using Dados;
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

            #region LER
            
            produtos = regras.LerProduto(produtos, @"dadosprodutos");
            marcas = regras.LerMarcas(marcas, @"dadosmarcas");
            stocks = regras.LerStocks(stocks, @"dadosstock");
            clientes = regras.LerClientes(clientes, @"dadosclientes");
            funcionarios = regras.LerFuncionario(funcionarios, @"dadosfuncionario");
            managers = regras.LerManager(managers, @"dadosmanager");
            campanhas = regras.LerCampanhas(@"dadoscampanhas", @"dadosprodutocampanha", campanhas, produtos);
            fornecedores = regras.LerFornecedores(fornecedores, @"dadosfornecedores");
            vendas = regras.LerVendas(vendas, @"dadosvendas", @"dadosvendaproduto");

            /*
            produtos = regras.LerProdutoB(produtos, @"dadosprodutosB");
            marcas = regras.LerMarcasB(marcas, @"dadosmarcasB");
            stocks = regras.LerStocksB(stocks, @"dadosstockB");
            clientes = regras.LerClientesB(clientes, @"dadosclientesB");
            funcionarios = regras.LerFuncionarioB(funcionarios, @"dadosfuncionarioB");
            managers = regras.LerManagerB(managers, @"dadosmanagerB");
            campanhas = regras.LerCampanhasB(@"dadoscampanhasB",campanhas);
            fornecedores = regras.LerFornecedoresB(fornecedores, @"dadosfornecedoresB");
            vendas = regras.LerVendasB(vendas, @"dadosvendasB");
            */

            #endregion

            menu.MenuPrincipal1(produtos, marcas, stocks, clientes, funcionarios, managers, vendas, campanhas, fornecedores, regras);

            #region GRAVAR

            regras.GravarProduto(produtos, @"dadosprodutos");
            regras.GravarMarcas(marcas, @"dadosmarcas");
            regras.GuardarClientes(clientes, @"dadosclientes");
            regras.GuardarVendas(vendas, @"dadosvendas", @"dadosvendaproduto");
            regras.GravarStocks(stocks, @"dadosstock");
            regras.GuardarFuncionario(funcionarios, @"dadosfuncionario");
            regras.GuardarManager(managers, @"dadosmanager");
            regras.GravarCampanha(@"dadoscampanhas", @"dadosprodutocampanha", campanhas);
            regras.GuardarFornecedores(fornecedores, @"dadosfornecedores");

            regras.GravarProdutoB(produtos, @"dadosprodutosB");
            regras.GravarMarcasB(marcas, @"dadosmarcasB");
            regras.GuardarClientesB(clientes, @"dadosclientesB");
            regras.GuardarVendasB(vendas, @"dadosvendasB");
            regras.GravarStocksB(stocks, @"dadosstockB");
            regras.GuardarFuncionarioB(funcionarios, @"dadosfuncionarioB");
            regras.GuardarManagerB(managers, @"dadosmanagerB");
            regras.GravarCampanhaB(@"dadoscampanhasB", campanhas);
            regras.GuardarFornecedoresB(fornecedores, @"dadosfornecedoresB");

            #endregion

            Environment.Exit(0);
        }
    }
}
