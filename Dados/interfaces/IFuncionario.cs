using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using objetos;


namespace Dados
{
    /// <summary>
    /// Purpose: classe para enunciar funcoes relacioandas com o funcionario
    /// Created by: Rafael silva
    /// Created on: 14/12/2023 16:37:20
    /// </summary>
    public interface IFuncionario
    {
        /// <summary>
        /// Funcao para adicionar um funcionario a lista
        /// </summary>
        /// <param name="g">variavel para o funcionarios</param>
        /// <returns>retorna true se for adicionado e false se nao</returns>
        bool InserirFuncionario(Funcionario funcionario);

        /// <summary>
        /// Funcao para verificar se um funcionario ja existe
        /// </summary>
        /// <param name="id">variavel para o id do funcionario</param>
        /// <returns>retorna true se o funcionario existe e false se nao</returns>
        bool ExisteFuncionario(int id);

        /// <summary>
        /// Funcao para alterar um funcionario
        /// </summary>
        /// <param name="id">variavel para o id do funcionario</param>
        /// <param name="t">variavel array que determina que propriedade do funcionario deve ser alterada</param>
        /// <param name="nome">variavel para o nome do funcionario</param>
        /// <param name="contacto">variavel para o contacto do funcionario</param>
        /// <param name="nif">variavel para o nif do funcionario</param>
        /// <returns>retorna true se for alterado uma propriedade do funcionario e false se nao</returns>
        bool AlterarFuncionario(int id, int[] t, string nome, int contacto, int nif);

        /// <summary>
        /// Funcao para retirar um funcionario
        /// </summary>
        /// <param name="id">variavel para o id do funcionario</param>
        /// <returns>retorna true se removeu o funcionario ou false se nao</returns>
        bool RetirarFuncionario(int id);

        /// <summary>
        /// funcao para buscar o proximo id do funcionario
        /// </summary>
        /// <param name="id">variavel para o id do funcionario</param>
        /// <returns>retorna o id</returns>
        int ID(int id);

        /// <summary>
        /// Funcao para guardar os funcionarios num ficheiro binario
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool GuardarFuncionarioB(string m);

        /// <summary>
        /// Funcao para ler os funcionarios de um ficheiro binario
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool LerFuncionarioB(string m);

        /// <summary>
        /// Funcao para guardar os funcionarios num ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool GuardarFuncionario(string m);

        /// <summary>
        /// Funcao para ler os funcionarios de um ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool LerFuncionario(string m);
    }
}

