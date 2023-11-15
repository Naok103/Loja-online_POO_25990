using Classes1;
using System;

namespace Classes2
{
    /// <summary>
    /// Purpose: Classe para definir uma campanha
    /// Created by: Rafael Silva
    /// Created on: 08/11/2023 14:25:48
    /// </summary>
    public class Campanha
    {
        #region ESTADO 

        private string duracao;
        private int desconto;
        private int idP;

        #endregion

        #region COMPORTAMENTO

        #region CONSTRUTORES

        /// <summary>
        /// Construtor por omissão
        /// </summary>
        public Campanha()
        {
            duracao = "";
            desconto = 0;
            idP = 0;
        }

        /// <summary>
        /// Construtor 
        /// </summary>
        /// <param name="duracao">variavel para a duracao da campanha</param>
        /// <param name="desconto">variavel para o desconto no produto durante a campanha</param>
        /// <param name="idP">variavel para o id do produto em campanha</param>
        public Campanha(string duracao, int desconto, int idP)
        {
            this.duracao = duracao;
            this.desconto = desconto;
            this.idP = idP;
        }

        #endregion

        #region PROPRIEDADES

        /// <summary>
        /// Propriedade da variaavel duracao
        /// </summary>
        public string Duracao
        {
            set { duracao = value; }
            get { return duracao; }
        }

        /// <summary>
        /// Propriedades da variavel desconto
        /// </summary>
        public int Desconto
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
        public int IDP
        {
            set
            {
                if (value < 0)
                    idP = value;
            }
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
            if ((c1.desconto == c2.desconto) && (c1.duracao == c2.duracao) && (c1.idP == c2.idP))
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
            return string.Format("Duracao: {0}, Desconto: {1}, Id Produto: {2}", duracao, desconto.ToString(), idP.ToString());
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

        #endregion
    }
}

