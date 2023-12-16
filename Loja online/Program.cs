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
            Menu menu = new Menu();

            menu.MenuPrincipal(produtos, marcas, stocks, clientes, funcionarios);
        }
    }
}
