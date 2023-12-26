using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objetos;

namespace Dados
{
    /// <summary>
    /// Purpose: Classe para enunciar os metodos relacionados com Vendas
    /// Created by: Rafael silva
    /// Created on: 21/11/2023 10:55:58
    /// </summary>
    internal interface IVenda
    {
        /// <summary>
        /// Funcao para adicionar uma venda a lista de vendas
        /// </summary>
        /// <param name="v">variavel para uma venda</param>
        /// <returns></returns>
        bool AdicionarVenda(Venda v);

        /// <summary>
        /// Funcao para adicionar produtos e as suas quantidades vendidas a um dicionario de uma venda
        /// </summary>
        /// <param name="q"> variavel array para a quantidade vendida de cada produto</param>
        /// <param name="id">variavel array para os ids dos produtos vendidos</param>
        /// <param name="id">variavel para o id da venda</param>
        /// <returns></returns>
        bool AdicionarProdutos(int[] p, int[] q, int id);

        /// <summary>
        /// Funcao para calcular
        /// </summary>
        /// <param name="q"> variavel array para a quantidade vendida de cada produto</param>
        /// <param name="p">variavel array para os ids dos produtos vendidos</param>
        /// <param name="id">variavel para o id da venda</param>
        /// <param name="preco">variavel para o preco da venda</param>
        /// <param name="produtos">variavel para a lista de produtos</param>
        /// <returns></returns>
        double CalculaPreco(int[] p, int[] q, int id, double preco, Produtos produtos);

        /// <summary>
        /// funcao para buscar o proximo id da venda
        /// </summary>
        /// <param name="id">variavel para o id da venda</param>
        /// <returns>retorna o id</returns>
        int ID(int id);

        /// <summary>
        /// Funcao para guardar as vendas num ficheiro binario
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool GuardarVendaB(string m);

        /// <summary>
        /// Funcao para ler as vendas de um ficheiro binario
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool LerVendaB(string m);

        /// <summary>
        /// Funcao para guardar as vendas num ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool GuardarVenda(string m);

        /// <summary>
        /// Funcao para ler as vendas de um ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool LerVenda(string m);
    }
}
