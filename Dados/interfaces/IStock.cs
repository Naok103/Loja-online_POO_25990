using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objetos;

namespace Dados
{
    /// <summary>
    /// Purpose: Classe para enunciar os metodos relacionados com Stock
    /// Created by: Rafael silva
    /// Created on: 21/11/2023 10:56:34
    /// </summary>
    internal interface IStock
    {
        /// <summary>
        /// Funcao para adicionar um stock a lista
        /// </summary>
        /// <param name="s">variavel para um stock</param>
        /// <returns>retorna true se o stock foi adicionado ou false se nao</returns>
        bool InserirStock(Stock s);

        /// <summary>
        /// Funcao para retirar um stock da lista
        /// </summary>
        /// <param name="id">variavel para o id do stock</param>
        /// <returns>retorna true se o stock foi retirado ou false se nao</returns>
        bool AcabarStock(int id);

        /// <summary>
        /// Funcao para verificar se um stock ja existe
        /// </summary>
        /// <param name="id">variavel para o id do stock</param>
        /// <returns>retorna true se o stock existe ou false se nao</returns>
        bool ExisteStock(int id);

        /// <summary>
        /// Funcao para adicionar produtos a um stock ja existente
        /// </summary>
        /// <param name="id">variavel para o id do produto</param>
        /// <param name="quantidade">variavel para a quantidade do produto a ser adicioanda ao stock</param>
        /// <returns>retorna true se os produto/s foi/foram adicionado/s ou false se nao</returns>
        bool AdicionarStock(int id, int quantidade);

        /// <summary>
        /// Funcao para retirar produtos de um stock ja exixtente
        /// </summary>
        /// <param name="id">variavel para o id do produto</param>
        /// <param name="quantidade">variavel para a quantidade do produto a ser retirada do stock</param>
        /// <returns>retorna true se os produto/s foi/foram retirado/s ou false se nao</returns>
        bool RetirarStock(int id, int quantidade);

        /// <summary>
        /// funcao para buscar o proximo id do stock
        /// </summary>
        /// <param name="id">variavel para o id do stock</param>
        /// <returns>retorna o id</returns>
        int ID(int id);

        /// <summary>
        /// Funcao para guardar o stock num ficheiro binario
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool GravarStockB(string m);

        /// <summary>
        /// Funcao para ler o stock de um ficheiro binario
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool LerStockB(string m);

        /// <summary>
        /// Funcao para guardar o stock num ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool GravarStock(string m);

        /// <summary>
        /// Funcao para ler o stock de um ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool LerStock(string m);


    }
}
