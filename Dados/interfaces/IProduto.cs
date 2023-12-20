using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objetos;

namespace Dados
{
    /// <summary>
    /// Purpose: classe para declarar os metodos relacionados com produto
    /// Created by: Rafael silva
    /// Created on: 21/11/2023 11:21:32
    /// </summary>
    internal interface IProduto
    {
        /// <summary>
        /// Funcao para adicionar um produto a lista
        /// </summary>
        /// <param name="p">variavael para um produto</param>
        /// <returns>retorna true se o produto for adicionado ou false se nao</returns>
        bool InserirProduto(Produto p);

        /// <summary>
        /// Funcao para alterar um produto
        /// </summary>
        /// <param name="id">variavel para o id do produto</param>
        /// <param name="t">variavel que determina que propriedade do produto deve ser alterada</param>
        /// <param name="nome">variavel para o nome do produto</param>
        /// <param name="categoria">variavel para a categoria do produto</param>
        /// <param name="preco">variavel para o preco do produto</param>
        /// <param name="garantia">variavel para a garantia do produto</param>
        /// <returns>retorna true se for alterado uma propriedade do produto e false se nao</returns>
        bool AlterarProduto(int id, int t, string nome, string categoria, int preco, int garantia);

        /// <summary>
        /// Funcao para retirar um produto da loja 
        /// </summary>
        /// <param name="id">variavel para o id do produto</param>
        /// <returns>retorna true se o produto foi retirado ou false se nao</returns>
        bool RetirarProduto(int id);

        /// <summary>
        /// Funcao para verificar se um produto ja existe
        /// </summary>
        /// <param name="id">variavel para o id do produto</param>
        /// <returns>retorna true se o produto existe e false se nao</returns>
        bool ExisteProduto(int id);

        /// <summary>
        /// Funcao para guardar os produtos num ficheiro binario
        /// </summary>
        /// <param name="d">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool GuardarProdutoB(string d);

        /// <summary>
        /// Funcao para ler os produtos de um ficheiro binario
        /// </summary>
        /// <param name="d">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool LerProdutoB(string d);

        /// <summary>
        /// Funcao para guardar os produtos num ficheiro de texto
        /// </summary>
        /// <param name="d">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool GuardarProduto(string d);

        /// <summary>
        /// Funcao para ler os produtos de um ficheiro de texto
        /// </summary>
        /// <param name="d">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool LerProduto(string d);

        /// <summary>
        /// Funcao para devolver um produto
        /// </summary>
        /// <param name="id">variavel para o id do produto</param>
        /// <returns></returns>
        bool DevolverProduto(int id);// desenvolver

        /// <summary>
        /// Funcao para trocar um produto
        /// </summary>
        /// <param name="id">variavel para o id do produto</param>
        /// <returns></returns>
        bool TrocarProduto(int id);// desenvolver

        /// <summary>
        /// funcao para buscar o proximo id do produto
        /// </summary>
        /// <param name="id">variavel para o id do produto</param>
        /// <returns>retorna o id</returns>
        int ID(int id);

    }
}
