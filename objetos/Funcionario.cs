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
    /// Purpose: Classe para descrever um funcionario
    /// Created by: Rafael silva
    /// Created on: 07/12/2023 17:11:43
    /// </summary>
    public class Funcionario : Pessoa
    {
        #region ESTADO 

        private int id;

        #endregion

        #region COMPORTAMENTO

        #region CONSTRUTORES

        /// <summary>
        /// Construtor por omissão
        /// </summary>
        public Funcionario()
        {
            id = 0;
            Nome = "";
            Contacto = 0;
            Nif = 0;
        }

        /// <summary>
        /// Construtor por parametros
        /// </summary>
        /// <param name="id">variavel para o id do Funcionario</param>
        /// <param name="nome"> variavel para o nome do Funcionario</param>
        /// <param name="contacto">variavel para o contacto do Funcionario</param>
        /// <param name="nif">variavel para o nif do Funcionario</param>
        public Funcionario(int id, string nome, int contacto, int nif)
        {
            this.id = id;
            this.Nome = nome;
            this.Contacto = contacto;
            this.Nif = nif;
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

        #endregion

        #region Operadores

        /// <summary>
        /// Funcao para verificar se duas variaveis da classe Funcionario sao iguais
        /// </summary>
        /// <param name="u1">variavel que reprensenta a classe Funcionario</param>
        /// <param name="u2">variavel que reprensenta a classe Funcionario</param>
        /// <returns>retorna verdaeiro se o conteudo dos Funcionarios comparadas forem iguais e falso se nao forem</returns>
        public static bool operator ==(Funcionario u1, Funcionario u2)
        {
            if ((u1.Nome == u1.Nome) && (u2.Id == u2.Id) && (u1.Contacto == u2.Contacto) && (u1.Nif == u2.Nif))
                return true;
            return false;
        }

        /// <summary>
        /// Funcao para verificar se duas variaveis da classe Funcionario sao diferentes
        /// </summary>
        /// <param name="u1">variavel que reprensenta a classe Funcionario</param>
        /// <param name="u2">variavel que reprensenta a classe Funcionario</param>
        /// <returns>retorna falso se o conteudo dos Funcionarios comparadas forem iguais e verdadeiro se nao forem</returns>
        public static bool operator !=(Funcionario u1, Funcionario u2)
        {
            if (u1 == u2)
                return false;
            return true;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Funcao para mostrar na consola o conteudo de um Funcionario
        /// </summary>
        /// <returns>retorna uma frase com o conteudo de um Funcionario</returns>
        public override string ToString()
        {
            return String.Format("Nome: {0}, Id: {1}, Contacto: {2}, Nif: {3}", Nome, id.ToString(), Contacto.ToString(), Nif.ToString());
        }

        /// <summary>
        /// Funcao para comparar um objeto com o conteudo de um Funcionario
        /// </summary>
        /// <param name="obj">variavel que representa um objeto</param>
        /// <returns>retorna verdadeiro se o objeto for igual ao conteudo do Funcionario</returns>
        public override bool Equals(object obj)
        {
            if (obj is Funcionario)
            {
                Funcionario u = (Funcionario)obj;
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

