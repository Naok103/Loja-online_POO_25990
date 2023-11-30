
 
using System;


namespace Objetos
{
    /// <summary>
    /// Purpose: Classe para definir uma campanha
    /// Created by: Rafael Silva
    /// Created on: 08/11/2023 14:30:21
    /// </summary>
    public class Stock
    {
        #region ESTADO 

        private int quantidade;
        private int idP;

        #endregion

        #region COMPORTAMENTO

        #region CONSTRUTORES

        /// <summary>
        /// Construtor por omissão
        /// </summary>
        public Stock()
        {
            quantidade = 0;
            idP = 0;
        }

        /// <summary>
        /// Construtor passado por parametros
        /// </summary>
        /// <param name="quantidade">variavel para a quantidade do produto em stock</param>
        /// <param name="idP">variavel do id do produto em stock</param>
        public Stock(int quantidade, int idP)
        {
            this.quantidade = quantidade;
            this.idP = idP;
        }

        #endregion

        #region PROPRIEDADES

        /// <summary>
        /// Propriedades da variavel quantidade
        /// </summary>
        public int Quantidade
        {
            get { return quantidade; }
            set
            {
                if (value > 0)
                    quantidade = value;
            }
        }

        /// <summary>
        /// Propriedades da variavel idP
        /// </summary>
        public int IDP
        {
            get { return idP; }
            set
            {
                if (value > 0)
                    idP = value;
            }
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Funcao para verificar se duas variaveis da classe Stock sao iguais
        /// </summary>
        /// <param name="s1">variavel que reprensenta a classe stock</param>
        /// <param name="s2">variavel que reprensenta a classe stock</param>
        /// <returns>retorna verdaeiro se o conteudo dos stocks comparados forem iguais e falso se nao forem</returns>
        public static bool operator ==(Stock s1, Stock s2)
        {
            if ((s1.Quantidade == s2.Quantidade) && (s1.idP == s2.idP))
                return true;
            return false;
        }

        /// <summary>
        /// Funcao para verificar se duas variaveis da classe Stock sao diferentes
        /// </summary>
        /// <param name="s1">variavel que reprensenta a classe stock</param>
        /// <param name="s2">variavel que reprensenta a classe stock</param>
        /// <returns>retorna falso se o conteudo dos stocks comparados forem iguais e verdadeiro se nao forem</returns>
        public static bool operator !=(Stock s1, Stock s2)
        {
            if (s1 == s2)
                return false;
            return true;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Funcao para mostrar na consola o conteudo de um stock
        /// </summary>
        /// <returns>retorna uma frase com o conteudo de um stock</returns>
        public override string ToString()
        {
            return String.Format("Nome: {0}, Id Produto: {1}", quantidade.ToString(), idP.ToString());
        }

        /// <summary>
        /// Funcao para comparar um objeto com o conteudo de um stock
        /// </summary>
        /// <param name="obj">variavel que representa um objeto</param>
        /// <returns>retorna verdadeiro se o objeto for igual ao conteudo do stock</returns>
        public override bool Equals(object obj)
        {
            if (obj is Stock)
            {
                Stock s = (Stock)obj;
                if (this == s)
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

