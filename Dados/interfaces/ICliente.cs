using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objetos;

namespace Dados
{
    /// <summary>
    /// Purpose: classe para enunciar funcoes relacioandas com o cliente
    /// Created by: Rafael silva
    /// Created on: 21/11/2023 11:21:26
    /// </summary>
    public interface ICliente
    {
        
        /// <summary>
        /// Funcao para adicionar um cliente a lista
        /// </summary>
        /// <param name="c">variavel para o cliente</param>
        /// <returns>retorna true se for adicionado e false se nao</returns>
        bool AdicionarCliente(Cliente c);

        /// <summary>
        /// Funcao para alterar um cliente
        /// </summary>
        /// <param name="id">variavel para o id do cliente</param>
        /// <param name="t">variavel array que determina que propriedade do cliente deve ser alterada</param>
        /// <param name="nome">variavel para o nome do cliente</param>
        /// <param name="contacto">variavel para o contacto do cliente</param>
        /// <param name="nif">variavel para o nif do cliente</param>
        /// <param name="morada">variavel para a morada do cliente</param>
        /// <returns>retorna true se for alterado uma propriedade do cliente e false se nao</returns>
        bool AlterarCliente(int id, int[] d, string nome, int contacto, int nif, string morada);

        /// <summary>
        /// Funcao para verificar se um cliente ja existe
        /// </summary>
        /// <param name="id">variavel para o id do cliente</param>
        /// <returns>retorna true se o cliente existe e false se nao</returns>
        bool ExisteCliente(int id);

        /// <summary>
        /// Funcao para retirar um cliente
        /// </summary>
        /// <param name="id">variavel para o id do cliente</param>
        /// <returns>retorna true se removeu o cliente ou false se nao</returns>
        bool RetirarCliente(int id);

        /// <summary>
        /// Funcao para guardar os clientes num ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool GravarClienteB(string m);

        /// <summary>
        /// Funcao para guardar os clientes num ficheiro binario
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool LerClienteB(string m);

        /// <summary>
        /// Funcao para guardar os clientes num ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool GravarCliente(string m);

        /// <summary>
        /// Funcao para ler os clientes de um ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool LerCliente(string m);

    }
}
