/*
 * Classe para descrever uma marca
 * Rafael maia da silva
 * rafamsiva853@ipca.pt
 * 29-10-2023
 * **/


using System;
using Classes2;

namespace Classes1
{
    
    public class Marca
    {
        #region ESTADO 

        private int id;
        private string nome;
        private string site;

        #endregion

        #region COMPORTAMENTO

        #region CONSTRUTORES

        /// <summary>
        /// Construtor por omissão
        /// </summary>
        public Marca()
        {
            id = 0;
            nome = "";
            site = "";
        }

        /// <summary>
        /// Construtor por parametros
        /// </summary>
        /// <param name="id">variavel id marca</param>
        /// <param name="nome">variavel nome</param>
        /// <param name="site">variavel site</param>
        public Marca(int id, string nome, string site)
        {
            this.id = id;
            this.nome = nome;
            this.site = site;
        }

        #endregion

        #region PROPRIEDADES

        /// <summary>
        /// Propriedades da variavel id marca
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
        /// Propriedades da variavel site
        /// </summary>
        public string Site
        {
            get { return site; }
            set { site = value; }
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Funcao para verificar se duas variaveis da classe Marca sao iguais
        /// </summary>
        /// <param name="u1">variavel marca</param>
        /// <param name="u2">variavel marca</param>
        /// <returns>retorna verdaeiro se o conteudo das marcas comparadas forem iguais e falso se nao forem</returns>
        public static bool operator ==(Marca u1, Marca u2)
        {
            if ((u1.Nome == u1.Nome) && (u2.Id == u2.Id) && (u1.Site == u2.Site))
                return true;
            return false;
        }

        /// <summary>
        /// Funcao para verificar se duas variaveis da classe Marca sao diferentes
        /// </summary>
        /// <param name="u1">variavel marca</param>
        /// <param name="u2">variavel marca</param>
        /// <returns>retorna falso se o conteudo das marcas comparadas forem iguais e verdadeiro se nao forem</returns>
        public static bool operator !=(Marca u1, Marca u2)
        {
            if (u1 == u2)
                return false;
            return true;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Funcao para mostrar na consola o conteudo de uma marca
        /// </summary>
        /// <returns>retorna uma frase com o conteudo de uma marca</returns>
        public override string ToString()
        {

            return String.Format("Nome: {0}, Idade: {1}, Preco{2}, Categoria{3}, Garantia{4} ", nome, id.ToString(), site.ToString());
        }

        /// <summary>
        /// Funcao para comparar um objeto com o conteudo de uma marca
        /// </summary>
        /// <param name="obj">variavel objeto</param>
        /// <returns>retorna verdadeiro se o objeto for igual ao conteudo da marca</returns>
        public override bool Equals(object obj)
        {
            if (obj is Marca)
            {
                Marca m = (Marca)obj;
                if (this == m)
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

