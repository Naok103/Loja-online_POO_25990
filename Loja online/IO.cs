﻿using Objetos;
using Dados;
using System;
using System.Collections.Generic;
using System.Security.Policy;

namespace Loja_online
{
    /// <summary>
    /// Purpose: classe com funcoes que interagem com a consola
    /// Created by: Rafael silva
    /// Created on: 14/11/2023 21:57:46
    /// </summary>
    public class IO
    {
        #region CLIENTES

        public void MostrarClientes(Cliente c) { }

        #endregion

        #region PRODUTO

        public void MostrarProdutos(Produto p) { }

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

        public void MostrarStock(Stock s) { }

        public void MostrarStockProduto(Stock s, Produto p) { }

        #endregion

        #region CAMPANHA

        public void MostrarCampanha(Campanha c) { }

        #endregion

       
    }
}

