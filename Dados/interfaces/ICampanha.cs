using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objetos;

namespace Dados
{
    /// <summary>
    /// Purpose: Classe para guardar os metodos relacionados com Campanha
    /// Created by: Rafael silva
    /// Created on: 21/11/2023 10:55:33
    /// </summary>
    public interface ICampanha
    {
        /// <summary>
        /// Funcao para adicionar uma campanha a lista
        /// </summary>
        /// <param name="campanha">variavel para a campanha</param>
        /// <returns>retorna true se for adicionado e false se nao</returns>
        bool InserirCampanha(Campanha campanha);

        /// <summary>
        /// Funcao para adicionar um produto a uma campanha
        /// </summary>
        /// <param name="id">variavel para o id da campanha</param>
        /// <param name="idp">variavel para o id do produtos</param>
        /// <param name="produtos">variavel para a lista de produtos</param>
        /// <returns>retorna true se for adicionado e false se nao</returns>
        bool AdicionarProdutoCampanha(int id, int idp, Produtos produtos);

        /// <summary>
        /// Funcao para retirar um produto de uma campanha
        /// </summary>
        /// <param name="id">variavel para o id da campanha</param>
        /// <param name="idp">variavel para o id do produto</param>
        /// <returns>retorna true se removeu o produto da campanha ou false se nao</returns>
        bool RetirarProdutoCampanha(int id, int idp);

        /// <summary>
        /// Funcao para alterar uma campanha
        /// </summary>
        /// <param name="id">variavel para o id da campanha</param>
        /// <param name="t">variavel que determina que propriedade da campanha deve ser alterada</param>
        /// <param name="nome">variavel para o nome da campanha</param>
        /// <param name="duracao">variavel para a duracao da campanha</param>
        /// <param name="desconto">variavel para o desconto no produto durante a campanha</param>
        /// <returns>retorna true se for alterado uma propriedade da campanha e false se nao</returns>
        bool AlterarCampanha(int id, int[] t, string nome, int duracao, double desconto);

        /// <summary>
        /// Funcao para retirar uma campanha
        /// </summary>
        /// <param name="id">variavel para o id da campanha</param>
        /// <returns>retorna true se removeu a campanha ou false se nao</returns>
        bool RetirarCampanha(int id);

        /// <summary>
        /// Funcao para verificar se uma campanha ja existe
        /// </summary>
        /// <param name="id">variavel para o id da campanha</param>
        /// <returns>retorna true se a  campanha existe e false se nao</returns>
        bool ExisteCampanha(int id);

        /// <summary>
        /// Funcao para verificar se um produto existe numa campanha
        /// </summary>
        /// <param name="id">variavel para o id da campanha</param>
        /// <param name="idp">variavel para o id do produto</param>
        /// <returns>retorna true se o produto existe e false se nao</returns>
        bool ExisteProdutoCampanha(int idp, int id);

        /// <summary>
        /// funcao para buscar o proximo id da campanha
        /// </summary>
        /// <param name="id">variavel para o id da campanha</param>
        /// <returns>retorna o id</returns>
        int ID(int id);

        /// <summary>
        /// Funcao para guardar as campanhas num ficheiro binario
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool GuardarCampanhasB(string m);

        /// <summary>
        /// Funcao para ler as campanhas de um ficheiro binario
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool LerCampanhasB(string m);

        /// <summary>
        /// Funcao para guardar as campanhas num ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool GuardarCampanhas(string m);

        /// <summary>
        /// Funcao para ler as campanhas de um ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool LerCampanhas(string m);

        /// <summary>
        /// Funcao para guardar os produtos de uma campanha num ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        bool GuardarProdutoCampanha(string m);

        /// <summary>
        /// Funcao para ler os produtos de uma campanha de um ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <param name="produtos">variavel para a lista de produtos</param>
        /// <returns></returns>
        bool LerProdutoCampanha(string m, Produtos produtos);
    }
}
