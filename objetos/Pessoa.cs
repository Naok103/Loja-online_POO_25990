using Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace objetos
{
    /// <summary>
    /// Purpose: Classe para descrever uma pessoa
    /// Created by: Rafael silva
    /// Created on: 07/12/2023 15:09:07
    /// </summary>
    public class Pessoa
    {
        #region ESTADO 

        private int id;
        private string nome;
        private int nif;

        #endregion

        #region COMPORTAMENTO

        #region CONSTRUTORES
        /// <summary>
        /// Construtor por omissão
        /// </summary>
        public Pessoa()
        {
            id = 0;
            nome = "";
            nif = 0;
        }

        /// <summary>
        /// Construtor por parametros
        /// </summary>
        /// <param name="id">variavel para o id da pessoa</param>
        /// <param name="nome"> variavel para o nome da pessoa</param>
        public Pessoa(int id, string nome, int nif)
        {

            this.id = id;
            this.nome = nome;
            this.nif = nif;
        }

        #endregion

        #region PROPRIEDADES

        /// <summary>
        /// Propriedades da variavel id cliente
        /// </summary>
        public int Id
        {
            get { return id; }
            set
            {
                if (value > 0)
                    id = value;
            }
        }

        /// <summary>
        /// Propriedades da variavel nome
        /// </summary>
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        /// <summary>
        /// Propriedades da variavel nif
        /// </summary>
        public int Nif
        {
            get { return nif; }
            set { nif = value; }
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Funcao para verificar se duas variaveis da classe Pessoa sao iguais
        /// </summary>
        /// <param name="u1">variavel que reprensenta a classe pessoa</param>
        /// <param name="u2">variavel que reprensenta a classe pessoa</param>
        /// <returns>retorna verdaeiro se o conteudo dos clientes comparadas forem iguais e falso se nao forem</returns>
        public static bool operator ==(Pessoa u1, Pessoa u2)
        {
            if ((u1.Nome == u1.Nome) && (u2.Id == u2.Id) && (u1.nif == u2.nif))
                return true;
            return false;
        }

        /// <summary>
        /// Funcao para verificar se duas variaveis da classe Cliente sao diferentes
        /// </summary>
        /// <param name="u1">variavel que reprensenta a classe cliente</param>
        /// <param name="u2">variavel que reprensenta a classe cliente</param>
        /// <returns>retorna falso se o conteudo dos clientes comparadas forem iguais e verdadeiro se nao forem</returns>
        public static bool operator !=(Pessoa u1, Pessoa u2)
        {
            if (u1 == u2)
                return false;
            return true;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Funcao para mostrar na consola o conteudo de um cliente
        /// </summary>
        /// <returns>retorna uma frase com o conteudo de um cliente</returns>
        public override string ToString()
        {
            return String.Format("Nome: {0}, Id: {1}, Nif{2}", nome, id.ToString(), nif.ToString());
        }

        /// <summary>
        /// Funcao para comparar um objeto com o conteudo de um cliente
        /// </summary>
        /// <param name="obj">variavel que representa um objeto</param>
        /// <returns>retorna verdadeiro se o objeto for igual ao conteudo do cliente</returns>
        public override bool Equals(object obj)
        {
            if (obj is Pessoa)
            {
                Pessoa u = (Pessoa)obj;
                if (this == u)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #endregion
    }
}

