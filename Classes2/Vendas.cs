using System;
using Classes1;


namespace Classes2
{
    /// <summary>
    /// Purpose: Classe para definir uma campanha
    /// Created by: Rafael Silva
    /// Created on: 08/11/2023 14:27:30
    /// </summary>
    public class Vendas
    {
        #region ESTADO 

        private int quantidade;
        private int idP;
        private int idC;

        #endregion

        #region COMPORTAMENTO

        #region CONSTRUTORES

        /// <summary>
        /// Construtor por omissão
        /// </summary>
        public Vendas()
        {
            quantidade = 0;
            idP = 0;
            idC = 0;
        }

        /// <summary>
        /// Construtor por parametros
        /// </summary>
        /// <param name="quantidade"> variavel para a quantidade vendida</param>
        /// <param name="idP">variavel para o id do produto vendido</param>
        /// <param name="idC">variavel para o id do cliente que comprou o produto</param>
        public Vendas(int quantidade, int idP, int idC)
        {
            this.quantidade = quantidade;
            this.idP = idP;
            this.idC = idC;
        }

        #endregion

        #region PROPRIEDADES

        /// <summary>
        /// propriedades da variavel quantidade
        /// </summary>
        public int Quantidades
        {
            set
            {
                if (value > 0)
                    quantidade = value;
            }
            get { return quantidade; }
        }

        /// <summary>
        /// Propriedades da variavel Id Produto
        /// </summary>
        public int IDP
        {
            set
            {
                if (value > 0)
                    idP = value;
            }
            get { return idP; }
        }

        /// <summary>
        /// Propriedades da variavel Id Cliente
        /// </summary>
        public int IDC
        {
            set
            {
                if (value > 0)
                    idC = value;
            }
            get { return idC; }
        }
        #endregion

        #region Operadores

        /// <summary>
        /// Funcao para verificar se duas variaveis da classe Venda sao iguais
        /// </summary>
        /// <param name="v1">variavel que reprensenta a classe venda</param>
        /// <param name="v2">variavel que reprensenta a classe venda</param>
        /// <returns>retorna verdaeiro se o conteudo das Vendas comparadas forem iguais e falso se nao forem</returns>
        public static bool operator ==(Vendas v1, Vendas v2)
        {
            if ((v1.quantidade == v2.quantidade) && (v1.idP == v2.idP) && (v1.idC == v2.idC))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Funcao para verificar se duas variaveis da classe Venda sao diferentes
        /// </summary>
        /// <param name="v1">variavel que reprensenta a classe venda</param>
        /// <param name="v2">variavel que reprensenta a classe venda</param>
        /// <returns>retorna falso se o conteudo das vendas comparadas forem iguais e verdadeiro se nao forem</returns>
        public static bool operator !=(Vendas v1, Vendas v2)
        {
            if ((v1 == v2))
            {
                return false;
            }
            return true;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Funcao para mostrar na consola o conteudo de uma venda
        /// </summary>
        /// <returns>retorna uma frase com o conteudo de uma venda</returns>
        public override string ToString()
        {
            return string.Format("Quantidade: {0}, Id Cliente: {1}, Id Produto: {2}", quantidade.ToString(), idC.ToString(), idP.ToString());
        }

        /// <summary>
        /// Funcao para comparar um objeto com o conteudo de uma venda
        /// </summary>
        /// <param name="obj">variavel que representa um objeto</param>
        /// <returns>retorna verdadeiro se o objeto for igual ao conteudo da venda</returns>
        public override bool Equals(object obj)
        {
            if (obj is Vendas)
            {
                Vendas v = (Vendas)obj;
                if (this == v)
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

