using objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dados
{
    /// <summary>
    /// Purpose: classe para enunciar funcoes relacioandas com o manager
    /// Created by: Rafael silva
    /// Created on: 16/12/2023 15:22:24
    /// </summary>
    internal interface IManager
    {
        /// <summary>
        /// Funcao para adicionar um manager a lista
        /// </summary>
        /// <param name="manager">variavel para o manager</param>
        /// <returns>retorna true se for adicionado e false se nao</returns>
        bool InserirManager(Manager manager);

        /// <summary>
        /// Funcao para verificar se um manager ja existe
        /// </summary>
        /// <param name="id">variavel para o id do manager</param>
        /// <returns>retorna true se o manager existe e false se nao</returns>
        bool ExisteManager(int id);

        /// <summary>
        /// Funcao para alterar um manager
        /// </summary>
        /// <param name="id">variavel para o id do manager</param>
        /// <param name="t">variavel array que determina que propriedade do manager deve ser alterada</param>
        /// <param name="nome">variavel para o nome do manager</param>
        /// <param name="contacto">variavel para o contacto do manager</param>
        /// <param name="nif">variavel para o nif do manager</param>
        /// <param name="pass">variavel para a pass do manager</param>
        /// <returns>retorna true se for alterado uma propriedade do manager e false se nao</returns>
        bool AlterarManager(int id, int[] t, string nome, int contacto, int nif, string pass);

        /// <summary>
        /// Funcao para retirar um manager
        /// </summary>
        /// <param name="id">variavel para o id do manager</param>
        /// <returns>retorna true se removeu o manager ou false se nao</returns>
        bool RetirarManager(int id);

        /// <summary>
        /// funcao para buscar o proximo id do manager
        /// </summary>
        /// <param name="id">variavel para o id do manager</param>
        /// <returns>retorna o id</returns>
        int ID(int id);

        /// <summary>
        /// Funcao para guardar os managers num ficheiro binario
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool GuardarManagerB(string m);

        /// <summary>
        /// Funcao para ler os managers de um ficheiro binario
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool LerManagerB(string m);

        /// <summary>
        /// Funcao para guardar os managers num ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool GuardarManager(string m);

        /// <summary>
        /// Funcao para ler os managers de um ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool LerManager(string m);
    }
}

