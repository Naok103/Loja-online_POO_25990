/*
 * Classe para descrever um Produto
 * Rafael maia da silva
 * rafamsiva853@ipca.pt
 * 28-10-2023
 * **/

using System;


namespace Objetos
{
    public class Produto
    {
        #region ESTADO 

        private int id;
        private string nome;
        private string categoria;
        private int preco;
        private int garantia;
        private int idM;

        #endregion

        #region COMPORTAMENTO

        #region CONSTRUTORES

        /// <summary>
        /// Construtor por omissão
        /// </summary>
        public Produto()
        {
            id = 0;
            nome = "";
            categoria = "";
            preco = 0;
            garantia = 0;
            idM = 0;
        }

        /// <summary>
        /// Construtor por parametros
        /// </summary>
        /// <param name="id">variavel para o id produto</param>
        /// <param name="nome">variavel para o nome do produto</param>
        /// <param name="categoria">variavel para a categoria do produto</param>
        /// <param name="preco">variavel para o preco do produto</param>
        /// <param name="garantia">variavel para a garantia do produto</param>
        /// <param name="idM">variavel para o id da marca do produto</param>
        public Produto(int id, string nome, string categoria, int preco, int garantia, int idM)
        {
            this.id = id;
            this.nome = nome;
            this.categoria = categoria;
            this.preco = preco;
            this.garantia = garantia;
            this.idM = idM;
        }

        #endregion

        #region PROPRIEDADES

        /// <summary>
        /// Propriedades da variavel id produto
        /// </summary>
        public int Id
        {
            set
            {
                if (value > 0)
                    id = value;
            }
            get { return id; }
        }

        /// <summary>
        /// Propriedades da variavel nome
        /// </summary>
        public string Nome
        {
            set { nome = value; }
            get { return nome; }
        }

        /// <summary>
        /// Propriedades da variavel categoria
        /// </summary>
        public string Categoria
        {
            set { categoria = value; }
            get { return categoria; }
        }

        /// <summary>
        /// Propriedades da variavel preco
        /// </summary>
        public int Preco
        {
            set
            {
                if (value > 0)
                    id = value;
            }
            get { return preco; }
        }

        /// <summary>
        /// Propriedades da variavel garantia
        /// </summary>
        public int Garantia
        {
            set
            {
                if (value > 0)
                    id = value;
            }
            get { return garantia; }
        }

        /// <summary>
        /// Propriedades da variavel id marca
        /// </summary>
        public int IdM
        {
            set
            {
                if (value > 0)
                    idM = value;
            }
            get { return idM; }
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Funcao para verificar se duas variaveis da classe Produto sao iguais
        /// </summary>
        /// <param name="u1">variavel que reprensenta a classe produto</param>
        /// <param name="u2">variavel que reprensenta a classe produto</param>
        /// <returns>retorna verdaeiro se o conteudo dos produtos comparados forem iguais e falso se nao forem</returns>
        public static bool operator ==(Produto u1, Produto u2)
        {
            if ((u1.Nome == u1.Nome) && (u2.Id == u2.Id) && (u1.Preco == u2.Preco) && (u1.Categoria == u2.Categoria) && (u1.Garantia == u2.Garantia))
                return true;
            return false;
        }

        /// <summary>
        /// Funcao para verificar se duas variaveis da classe Produto sao diferentes
        /// </summary>
        /// <param name="u1">variavel que reprensenta a classe produto</param>
        /// <param name="u2">variavel que reprensenta a classe produto</param>
        /// <returns>retorna falso se o conteudo dos produtos comparados forem iguais e verdadeiro se nao forem</returns>
        public static bool operator !=(Produto u1, Produto u2)
        {
            if (u1 == u2)
                return false;
            return true;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Funcao para mostrar na consola o conteudo de um produto
        /// </summary>
        /// <returns>retorna uma frase com o conteudo de um produto</returns>
        public override string ToString()
        {
            return string.Format("Id Produto: {1}, Nome: {2}, Categoria: {3}, Preco: {4}, Garantia: {5}, Id Marca: {6}", id.ToString(), nome, categoria, preco.ToString(), garantia.ToString(), idM.ToString());
        }

        /// <summary>
        /// Funcao para comparar um objeto com o conteudo de um produto
        /// </summary>
        /// <param name="obj">variavel que reprensenta um objeto</param>
        /// <returns>retorna verdadeiro se o objeto for igual ao conteudo do produto</returns>
        public override bool Equals(object obj)
        {
            if (obj is Produto)
            {
                Produto p = (Produto)obj;
                if (this == p)
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

