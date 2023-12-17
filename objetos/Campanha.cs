using System;

namespace Objetos
{
    /// <summary>
    /// Purpose: Classe para definir uma campanha
    /// Created by: Rafael Silva
    /// Created on: 08/11/2023 14:25:48
    /// </summary>
    public class Campanha
    {
        #region ESTADO 

        const int MAXPRODUTOS = 35;
        private string nome;
        private string duracao;
        private int desconto;
        private int[] idP;
        private int numeroP;

        #endregion

        #region COMPORTAMENTO

        #region CONSTRUTORES

        /// <summary>
        /// Construtor por omissão
        /// </summary>
        public Campanha()
        {
            nome = "";
            duracao = "";
            desconto = 0;
            idP = new int[MAXPRODUTOS];
            numeroP = 0;
        }

        /// <summary>
        /// Construtor por parametros
        /// </summary>
        /// /// <param name="nome">variavel para o nome da campanha</param>
        /// <param name="duracao">variavel para a duracao da campanha</param>
        /// <param name="desconto">variavel para o desconto no produto durante a campanha</param>
        /// <param name="idP">variavel para o id do produto em campanha</param>
        public Campanha(string nome, string duracao, int desconto, int idP)
        {
            this.nome = nome;
            this.duracao = duracao;
            this.desconto = desconto;
            this.idP[numeroP] = idP;
            numeroP++;
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
        public int[] IDP
        {
            set { }
            get { return (int[])idP.Clone(); }
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
            for(int i = 0;  i < c1.IDP.Length;i++)
            {
                for (int j = 0; j < c2.IDP.Length; j++)
                {
                    if ((c1.nome == c2.nome) && (c1.desconto == c2.desconto) && (c1.duracao == c2.duracao) && (c1.idP[i] == c2.idP[j]))
                    {
                        return true;
                    }
                }
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
            return string.Format("Nome: {0}, Duracao: {1}, Desconto: {2}, Id Produto: {3}",nome, duracao, desconto.ToString(), idP.ToString());
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

