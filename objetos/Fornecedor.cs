using Objetos;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace objetos
{
    /// <summary>
    /// Purpose: classe para descrever um fornecedor
    /// Created by: Rafael silva
    /// Created on: 21/12/2023 14:30:31
    /// </summary>
    public class Fornecedor : Pessoa
    {
        #region ESTADO 

        private int id; //variavel para o id do fornecedor
        private string morada; //variavel para a morada do fornecedor
        private string email; //variavel para o email do fornecedor

        #endregion

        #region COMPORTAMENTO

        #region CONSTRUTORES
        /// <summary>
        /// Construtor por omissão
        /// </summary>
        public Fornecedor()
        {
            id = 0;
            Nome = "";
            Contacto = 0;
            Nif = 0;
            morada = "";
            email = "";
        }

        /// <summary>
        /// Construtor por parametros
        /// </summary>
        /// <param name="id">variavel para o id do fornecedor</param>
        /// <param name="nome"> variavel para o nome do fornecedor</param>
        /// <param name="contacto">variavel para o contacto do fornecedor</param>
        /// <param name="nif">variavel para o nif do fornecedor</param>
        /// <param name="morada">variavel para a morada do fornecedor</param>
        /// <param name="email">variavel para o email do fornecedor</param>
        public Fornecedor(int id, string nome, int contacto, int nif, string morada, string email)
        {
            this.id = id;
            Nome = nome;
            Contacto = contacto;
            Nif = nif;
            this.morada = morada;
            this.email = email;
        }

        #endregion

        #region PROPRIEDADES

        /// <summary>
        /// Propriedades da variavel contacto
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
        /// Propriedades da variavel morada
        /// </summary>
        public string Morada
        {
            get { return morada; }
            set { morada = value; }

        }

        /// <summary>
        /// Propriedades da variavel morada
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }

        }

        #endregion

        #region Operadores

        /// <summary>
        /// Funcao para verificar se duas variaveis da classe fornecedor sao iguais
        /// </summary>
        /// <param name="u1">variavel que reprensenta a classe fornecedor</param>
        /// <param name="u2">variavel que reprensenta a classe fornecedor</param>
        /// <returns>retorna verdaeiro se o conteudo dos fornecedores comparadas forem iguais e falso se nao forem</returns>
        public static bool operator ==(Fornecedor u1, Fornecedor u2)
        {
            if ((u1.Nome == u1.Nome) && (u2.Id == u2.Id) && (u1.Contacto == u2.Contacto) && (u1.Nif == u2.Nif) && (u1.morada == u2.morada) && (u1.email == u2.email))
                return true;
            return false;
        }

        /// <summary>
        /// Funcao para verificar se duas variaveis da classe fornecedor sao diferentes
        /// </summary>
        /// <param name="u1">variavel que reprensenta a classe fornecedor</param>
        /// <param name="u2">variavel que reprensenta a classe fornecedor</param>
        /// <returns>retorna falso se o conteudo dos fornecedores comparadas forem iguais e verdadeiro se nao forem</returns>
        public static bool operator !=(Fornecedor u1, Fornecedor u2)
        {
            if (u1 == u2)
                return false;
            return true;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Funcao para mostrar na consola o conteudo de um fornecedor
        /// </summary>
        /// <returns>retorna uma frase com o conteudo de um fornecedor</returns>
        public override string ToString()
        {
            return String.Format("Nome: {0}, Id: {1}, Contacto: {2}, Nif: {3}, Morada: {4}", Nome, id.ToString(), Contacto.ToString(), Nif.ToString(), morada, email);
        }

        /// <summary>
        /// Funcao para comparar um objeto com o conteudo de um fornecedor
        /// </summary>
        /// <param name="obj">variavel que representa um objeto</param>
        /// <returns>retorna verdadeiro se o objeto for igual ao conteudo do fornecedor </returns>
        public override bool Equals(object obj)
        {
            if (obj is Fornecedor)
            {
                Fornecedor u = (Fornecedor)obj;
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

