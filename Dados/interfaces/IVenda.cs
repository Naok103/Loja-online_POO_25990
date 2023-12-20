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
