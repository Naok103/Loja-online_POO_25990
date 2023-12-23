using System;
using System.Collections.Generic;



namespace Objetos
{
    /// <summary>
    /// Purpose: Classe para definir uma venda
    /// Created by: Rafael Silva
    /// Created on: 08/11/2023 14:27:30
    /// </summary>
    [Serializable]
    public class Venda
    {
        #region ESTADO 

        private int id; // variavel para o id da venda
        private Dictionary<int, int> produtos; // dicionario para os produtos vendidos e as suas quantidades
        private int idC; //variavel para o id do cliente que comprou o produto
        private DateTime hora; //variavel para a hora em que a venda foi realizada

        #endregion

        #region COMPORTAMENTO

        #region CONSTRUTORES

        /// <summary>
        /// Construtor por omissão
        /// </summary>
        public Venda()
        {
            id = 0;
            produtos = new Dictionary<int, int>();
            idC = 0;
            hora = new DateTime(0,0,0);
        }

        /// <summary>
        /// Construtor por parametros
        /// </summary>
        /// <param name="idC">variavel para o id do cliente que comprou o produto</param>
        /// <param name="hora">variavel para a hora em que a venda foi realizada</param>
        /// <param name="id">variavel para o id da venda</param>
        public Venda(int idC, DateTime hora, int id)
        {
            produtos = new Dictionary<int, int>();
            this.idC = idC;
            this.hora = hora;
            this.id = id;
        }

        #endregion

        #region PROPRIEDADES

        /// <summary>
        /// Propriedades do dicionario
        /// </summary>
        public Dictionary<int, int> Produtos
        {
            get { return produtos; }
            set { produtos = value; }
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

        /// <summary>
        /// Propriedades da variavel hora
        /// </summary>
        public DateTime Hora
        {
            get { return hora; }
            set { hora = value; }
        }

        /// <summary>
        /// Propriedades da variavel Id
        /// </summary>
        public int ID
        {
            set
            {
                if (value > 0)
                    id = value;
            }
            get { return id; }
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Funcao para verificar se duas variaveis da classe Venda sao iguais
        /// </summary>
        /// <param name="v1">variavel que reprensenta a classe venda</param>
        /// <param name="v2">variavel que reprensenta a classe venda</param>
        /// <returns>retorna verdaeiro se o conteudo das Vendas comparadas forem iguais e falso se nao forem</returns>
        public static bool operator ==(Venda v1, Venda v2)
        {
            if ((v1.produtos == v2.produtos) && (v1.idC == v2.idC) && (v1.hora == v2.hora) && (v1.id == v2.id))
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
        public static bool operator !=(Venda v1, Venda v2)
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
            return string.Format("Quantidade: {0}, Id Cliente: {1}, Id Produto: {2}, Hora: {3}", produtos.ToString(), idC.ToString(), hora.ToString(), id.ToString());
        }

        /// <summary>
        /// Funcao para comparar um objeto com o conteudo de uma venda
        /// </summary>
        /// <param name="obj">variavel que representa um objeto</param>
        /// <returns>retorna verdadeiro se o objeto for igual ao conteudo da venda</returns>
        public override bool Equals(object obj)
        {
            if (obj is Venda)
            {
                Venda v = (Venda)obj;
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

