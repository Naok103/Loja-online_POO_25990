/*
 * Classe para descrever um Cliente
 * Rafael maia da silva
 * rafamsiva853@ipca.pt
 * 27-10-2023
 * **/

using objetos;
using System;



namespace Objetos
{
    [Serializable]
    public class Cliente : Pessoa
    {
        #region ESTADO 

        private int id; //variavel para o id do cliente
        private string morada; //variavel para a morada do cliente

        #endregion

        #region COMPORTAMENTO

        #region CONSTRUTORES
        /// <summary>
        /// Construtor por omissão
        /// </summary>
        public Cliente()
        {
            id = 0;
            Nome = "";
            Contacto = 0;
            Nif = 0;
            morada = "";
        }

        /// <summary>
        /// Construtor por parametros
        /// </summary>
        /// <param name="id">variavel para o id do cliente</param>
        /// <param name="nome"> variavel para o nome do cliente</param>
        /// <param name="contacto">variavel para o contacto do cliente</param>
        /// <param name="nif">variavel para o nif do cliente</param>
        /// <param name="morada">variavel para a morada do cliente</param>
        public Cliente(int id, string nome, int contacto, int nif, string morada)
        {
            this.id = id;
            this.Nome = nome;
            this.Contacto = contacto;
            this.Nif = nif;
            this.morada = morada;
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
        #endregion

        #region Operadores

        /// <summary>
        /// Funcao para verificar se duas variaveis da classe Cliente sao iguais
        /// </summary>
        /// <param name="u1">variavel que reprensenta a classe cliente</param>
        /// <param name="u2">variavel que reprensenta a classe cliente</param>
        /// <returns>retorna verdaeiro se o conteudo dos clientes comparadas forem iguais e falso se nao forem</returns>
        public static bool operator ==(Cliente u1, Cliente u2)
        {
            if ((u1.Nome == u1.Nome) && (u2.Id == u2.Id) && (u1.Contacto == u2.Contacto) && (u1.Nif == u2.Nif) && (u1.morada == u2.morada))
                return true;
            return false;
        }

        /// <summary>
        /// Funcao para verificar se duas variaveis da classe Cliente sao diferentes
        /// </summary>
        /// <param name="u1">variavel que reprensenta a classe cliente</param>
        /// <param name="u2">variavel que reprensenta a classe cliente</param>
        /// <returns>retorna falso se o conteudo dos clientes comparadas forem iguais e verdadeiro se nao forem</returns>
        public static bool operator !=(Cliente u1, Cliente u2)
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
            return String.Format("Nome: {0}, Id: {1}, Contacto: {2}, Nif: {3}, Morada: {4}", Nome, id.ToString(), Contacto.ToString(), Nif.ToString(), morada);
        }
            
        /// <summary>
        /// Funcao para comparar um objeto com o conteudo de um cliente
        /// </summary>
        /// <param name="obj">variavel que representa um objeto</param>
        /// <returns>retorna verdadeiro se o objeto for igual ao conteudo do cliente</returns>
        public override bool Equals(object obj)
        {
            if (obj is Cliente)
            {
                Cliente u = (Cliente)obj;
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

