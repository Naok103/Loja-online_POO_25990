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
    [Serializable]
    public class Pessoa
    {
        #region ESTADO 

        private int contacto; //variavel para o contacto da pessoa
        private string nome; //variavel para o nome da pessoa
        private int nif; //variavel para o nif da pessoa

        #endregion

        #region COMPORTAMENTO

        #region CONSTRUTORES

        /// <summary>
        /// Construtor por omissão
        /// </summary>
        public Pessoa()
        {
            contacto = 0;
            nome = "";
            nif = 0;
        }

        /// <summary>
        /// Construtor por parametros
        /// </summary>
        /// <param name="contacto">variavel para o contacto da pessoa</param>
        /// <param name="nome"> variavel para o nome da pessoa</param>
        /// /// <param name="nif"> variavel para o nif da pessoa</param>
        public Pessoa(int contacto, string nome, int nif)
        {

            this.contacto = contacto;
            this.nome = nome;
            this.nif = nif;
        }

        #endregion

        #region PROPRIEDADES

        /// <summary>
        /// Propriedades da variavel contacto
        /// </summary>
        public int Contacto
        {
            get { return contacto; }
            set
            {
                if (value > 0)
                    contacto = value;
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
            if ((u1.Nome == u1.Nome) && (u2.Contacto == u2.Contacto) && (u1.nif == u2.nif))
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

        #endregion
    }
}

