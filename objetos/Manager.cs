using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace objetos
{
    /// <summary>
    /// Purpose: Classe para descrever uma manager
    /// Created by: Rafael silva
    /// Created on: 07/12/2023 23:07:24
    /// </summary>
    [Serializable]
    public class Manager : Funcionario
    {
        #region ESTADO 

        private string pass;

        #endregion

        #region COMPORTAMENTO

        #region CONSTRUTORES
        /// <summary>
        /// Construtor por omissão
        /// </summary>
        public Manager()
        {
            Id = 0;
            Nome = "";
            Contacto = 0;
            Nif = 0;
            pass = "";
        }

        /// <summary>
        /// Construtor por parametros
        /// </summary>
        /// <param name="id">variavel para o id do Manager</param>
        /// <param name="nome"> variavel para o nome do Manager</param>
        /// <param name="contacto">variavel para o contacto do Manager</param>
        /// <param name="nif">variavel para o nif do Manager</param>
        /// <param name="pass">variavel para a pass do Manager</param>
        /// 
        public Manager(int id, string nome, int contacto, int nif, string pass)
        {
            this.Id = id;
            this.Nome = nome;
            this.Contacto = contacto;
            this.Nif = nif;
            this.pass = pass;
        }

        #endregion

        #region PROPRIEDADES

        /// <summary>
        /// Propriedades da variavel pass
        /// </summary>
        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Funcao para verificar se duas variaveis da classe Manager sao iguais
        /// </summary>
        /// <param name="u1">variavel que reprensenta a classe manager</param>
        /// <param name="u2">variavel que reprensenta a classe manager</param>
        /// <returns>retorna verdaeiro se o conteudo dos Managers comparadas forem iguais e falso se nao forem</returns>
        public static bool operator ==(Manager u1, Manager u2)
        {
            if ((u1.Nome == u1.Nome) && (u2.Id == u2.Id) && (u1.Contacto == u2.Contacto) && (u1.Nif == u2.Nif) && (u1.pass == u2.pass))
                return true;
            return false;
        }

        /// <summary>
        /// Funcao para verificar se duas variaveis da classe Manager sao diferentes
        /// </summary>
        /// <param name="u1">variavel que reprensenta a classe Manager</param>
        /// <param name="u2">variavel que reprensenta a classe Manager</param>
        /// <returns>retorna falso se o conteudo dos Managers comparadas forem iguais e verdadeiro se nao forem</returns>
        public static bool operator !=(Manager u1, Manager u2)
        {
            if (u1 == u2)
                return false;
            return true;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Funcao para mostrar na consola o conteudo de um Manager
        /// </summary>
        /// <returns>retorna uma frase com o conteudo de um Manager</returns>
        public override string ToString()
        {
            return String.Format("Nome: {0}, Id: {1}, Contacto: {2}, Nif: {3}", Nome, Id.ToString(), Contacto.ToString(), Nif.ToString(), pass);
        }

        /// <summary>
        /// Funcao para comparar um objeto com o conteudo de um Manager
        /// </summary>
        /// <param name="obj">variavel que representa um objeto</param>
        /// <returns>retorna verdadeiro se o objeto for igual ao conteudo do Manager</returns>
        public override bool Equals(object obj)
        {
            if (obj is Manager)
            {
                Manager u = (Manager)obj;
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

