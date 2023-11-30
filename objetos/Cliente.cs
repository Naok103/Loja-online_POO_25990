/*
 * Classe para descrever um Cliente
 * Rafael maia da silva
 * rafamsiva853@ipca.pt
 * 27-10-2023
 * **/

using System;



namespace Objetos
{

    public class Cliente
    {
        #region ESTADO 

        private int id;
        private string nome;
        private string pass;
        private int contacto;
        private int nif;
        #endregion

        #region COMPORTAMENTO

        #region CONSTRUTORES
        /// <summary>
        /// Construtor por omissão
        /// </summary>
        public Cliente()
        {
            id = 0;
            nome = "";
            pass = "";
            contacto = 0;
            nif = 0;
        }

        /// <summary>
        /// Construtor por parametros
        /// </summary>
        /// <param name="id">variavel para o id do cliente</param>
        /// <param name="nome"> variavel para o nome do cliente</param>
        /// <param name="pass">variavel para a password do cliente</param>
        /// <param name="contacto">variavel para o contacto do cliente</param>
        /// <param name="nif">variavel para o nif do cliente</param>
        public Cliente(int id, string nome, string pass, int contacto, int nif)
        {

            this.id = id;
            this.nome = nome;
            this.pass = pass;
            this.contacto = contacto;
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
        /// Propriedades da variavel pass
        /// </summary>
        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }

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
        /// Propriedades da variavel nif
        /// </summary>
        public int Nif
        {
            get { return nif; }
            set
            {
                if (value > 0)
                    nif = value;
            }
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
            if ((u1.Nome == u1.Nome) && (u2.Id == u2.Id) && (u1.Contacto == u2.Contacto) && (u1.Pass == u2.Pass) && (u1.Nif == u2.Nif))
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
            return String.Format("Nome: {0}, Id: {1}, Pass: {2}, Contacto: {3}, Nif: {4}", nome, id.ToString(), pass, contacto.ToString(), nif.ToString());
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

