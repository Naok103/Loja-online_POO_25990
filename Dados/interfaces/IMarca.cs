using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objetos;

namespace Dados
{
    /// <summary>
    /// Purpose: classe para enunciar as funcoes relacionadas com as marcas
    /// Created by: Rafael silva
    /// Created on: 21/11/2023 11:20:28
    /// </summary>
    internal interface IMarca
    {
        /// <summary>
        /// Funcao para adicionar uma marca a lista
        /// </summary>
        /// <param name="m">variavel para a marca</param>
        /// <returns>retorna true se for adicionado e false se nao</returns>
        bool InserirMarca(Marca m);

        /// <summary>
        /// Funcao para alterar uma marca
        /// </summary>
        /// <param name="id">variavel para o id da marca</param>
        /// <param name="i">variavel array que determina que propriedade da marca deve ser alterada</param>
        /// <param name="nome">variavel para o nome da marca</param>
        /// <param name="site">variavel para o site da marca</param>
        /// <returns>retorna true se for alterado uma propriedade da marca e false se nao</returns>
        bool AlterarMarca(int id, int[] i, string nome, string site);

        /// <summary>
        /// Funcao para retirar uma marca
        /// </summary>
        /// <param name="id">variavel para o id da marca</param>
        /// <returns>retorna true se removeu a marca ou false se nao</returns>
        bool RetirarMarca(int id);

        /// <summary>
        /// Funcao para verificar se uma marca ja existe
        /// </summary>
        /// <param name="id">variavel para o id da marca</param>
        /// <returns>retorna true se a marca existe e false se nao</returns>
        bool ExisteMarca(int id);

        /// <summary>
        /// funcao para buscar o proximo id da marca
        /// </summary>
        /// <param name="id">variavel para o id da marca</param>
        /// <returns>retorna o id</returns>
        int ID(int id);

        /// <summary>
        /// Funcao para guardar as marcas num ficheiro binario
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool GravarMarcasB(string m);

        /// <summary>
        /// Funcao para ler as marcas de um ficheiro bianrio
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool LerMarcasB(string m);

        /// <summary>
        /// Funcao para guardar as marcas num ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool GravarMarcas(string m);

        /// <summary>
        /// Funcao para ler as marcas de um ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool LerMarcas(string m);

    }
}
