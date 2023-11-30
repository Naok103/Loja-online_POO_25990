using Objetos;
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

