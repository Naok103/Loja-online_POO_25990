using objetos;
using Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dados
{
    /// <summary>
    /// Purpose: classe para enunciar funcoes relacioandas com o fornecedo
    /// Created by: Rafael silva
    /// Created on: 21/12/2023 14:48:52
    /// </summary>
    public interface IFornecedor
    {
        /// <summary>
        /// Funcao para adicionar um fornecedor a lista
        /// </summary>
        /// <param name="f">variavel para o fornecedor</param>
        /// <returns>retorna true se for adicionado e false se nao</returns>
        bool AdicionarFornecedor(Fornecedor f);

        /// <summary>
        /// Funcao para alterar um fornecedor
        /// </summary>
        /// <param name="id">variavel para o id do fornecedor</param>
        /// <param name="d">variavel que determina que propriedade do fornecedor deve ser alterada</param>
        /// <param name="nome">variavel para o nome do fornecedor</param>
        /// <param name="contacto">variavel para o contacto do fornecedor</param>
        /// <param name="nif">variavel para o nif do fornecedor</param>
        /// <param name="morada">variavel para a morada do fornecedor</param>
        /// <param name="email">variavel para o email do fornecedor</param>
        /// <returns>retorna true se for alterado uma propriedade do fornecedor e false se nao</returns>
        bool AlterarFornecedor(int id, int[] d, string nome, int contacto, int nif, string morada, string email);

        /// <summary>
        /// Funcao para verificar se um fornecedor ja existe
        /// </summary>
        /// <param name="id">variavel para o id do fornecedor</param>
        /// <returns>retorna true se o fornecedor existe e false se nao</returns>
        bool ExisteFornecedor(int id);

        /// <summary>
        /// Funcao para retirar um fornecedor
        /// </summary>
        /// <param name="id">variavel para o id do fornecedor</param>
        /// <returns>retorna true se removeu o fornecedor ou false se nao</returns>
        bool RetirarFornecedor(int id);

        /// <summary>
        /// funcao para buscar o proximo id do fornecedor
        /// </summary>
        /// <param name="id">variavel para o id do fornecedor</param>
        /// <returns>retorna o id</returns>
        int ID(int id);

        /// <summary>
        /// Funcao para guardar os fornecedores num ficheiro binario
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool GravarFornecedorB(string m);

        /// <summary>
        /// Funcao para ler os fornecedores de um ficheiro binario
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool LerFornecedorB(string m);

        /// <summary>
        /// Funcao para guardar os fornecedores num ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool GravarFornecedor(string m);

        /// <summary>
        /// Funcao para ler os fornecedores de um ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool LerFornecedor(string m);
    }
}

