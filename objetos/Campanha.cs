using System;
using System.Collections.Generic;

namespace Objetos
{
    /// <summary>
    /// Purpose: Classe para definir uma campanha
    /// Created by: Rafael Silva
    /// Created on: 08/11/2023 14:25:48
    /// </summary>
    [Serializable]
    public class Campanha : IComparable<Campanha>
    {
        #region ESTADO 

        private int id; //variavel para o id da campanha
        private string nome; //variavel para o nome da campanha
        private int duracao; //variavel para a duracao da campanha
        private double desconto; //variavel para o desconto no produto durante a campanha
        private List<Produto> idP; //lista com os produtos sobre efeito da campanha

        #endregion

        #region COMPORTAMENTO

        #region CONSTRUTORES

        /// <summary>
        /// Construtor por omissão
        /// </summary>
        public Campanha()
        {
            nome = "";
            duracao = 0;
            desconto = 0;
            idP = new List<Produto>();
            id = 0;
            
        }

        /// <summary>
        /// Construtor por parametros
        /// </summary>
        /// <param name="id">variavel para o id da campanha</param>
        /// <param name="nome">variavel para o nome da campanha</param>
        /// <param name="duracao">variavel para a duracao da campanha</param>
        /// <param name="desconto">variavel para o desconto no produto durante a campanha</param>
        public Campanha(int id, string nome, int duracao, double desconto)
        {
            this.id = id;
            this.nome = nome;
            this.duracao = duracao;
            this.desconto = desconto;
            idP = new List<Produto>();

        }

        #endregion

        #region PROPRIEDADES

        /// <summary>
        /// Propriedade da variavel id
        /// </summary>
        public int Id
        {
            set { id = value; }
            get { return id; }
        }

        /// <summary>
        /// Propriedade da variavel nome
        /// </summary>
        public string Nome
        {
            set { nome = value; }
            get { return nome; }
        }

        /// <summary>
        /// Propriedade da variavel duracao
        /// </summary>
        public int Duracao
        {
            set { duracao = value; }
            get { return duracao; }
        }

        /// <summary>
        /// Propriedades da variavel desconto
        /// </summary>
        public double Desconto
        {
            set
            {
                if (value < 0)
                    desconto = value;
            }
            get { return desconto; }
        }

        /// <summary>
        /// Propriedades da variavel idP
        /// </summary>
        public List<Produto> IDP
        {
            set { idP = value; }
            get { return idP; }
        }

        

        #endregion

        #region Operadores

        /// <summary>
        /// Funcao para verificar se duas variaveis da classe Campanha sao iguais
        /// </summary>
        /// <param name="c1">variavel que reprensenta a classe campanha</param>
        /// <param name="c2">variavel que reprensenta a classe campanha</param>
        /// <returns>retorna verdadeiro se o conteudo das campanhas comparadas for iguais e falso se nao forem</returns>
        public static bool operator ==(Campanha c1, Campanha c2)
        {

            if ((c1.id == c2.id) && (c1.nome == c2.nome) && (c1.desconto == c2.desconto) && (c1.duracao == c2.duracao))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Funcao para verificar se duas variaveis da classe Campanha sao diferentes
        /// </summary>
        /// <param name="c1">variavel que reprensenta a classe campanha</param>
        /// <param name="c2">variavel que reprensenta a classe campanha</param>
        /// <returns>retorna falso se o conteudo das campanhas comparadas forem iguais e verdadeiro se nao forem</returns>
        public static bool operator !=(Campanha c1, Campanha c2)
        {
            if (c1 == c2)
                return false;
            return true;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Funcao para mostrar na consola o conteudo de uma campanha 
        /// </summary>
        /// <returns>retorna uma frase com o conteudo de uma campanha</returns>
        public override string ToString()
        {
            return string.Format("Nome: {0}, Duracao: {1}, Desconto: {2}, Id Produto: {3}",nome, duracao.ToString(), desconto.ToString(), idP.ToString());
        }

        /// <summary>
        /// Funcao para comparar um objeto com o conteudo de uma campanha
        /// </summary>
        /// <param name="obj">variavel que representa um objeto</param>
        /// <returns>retorna verdadeiro se o objeto for igual ao conteudo da campanha</returns>
        public override bool Equals(object obj)
        {
            if (obj is Campanha)
            {
                Campanha c = (Campanha)obj;
                if (this == c)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region OUTROSMETODOS

        public int CompareTo(Campanha c)
        {
            return desconto.CompareTo(c.desconto);
        }

        #endregion

        #endregion
    }
}

