using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Objetos;


namespace Dados
{
    /// <summary>
    /// Purpose: classe para desenvolver as funcoes relacionadas com produto
    /// Created by: Rafael silva
    /// Created on: 21/11/2023 11:21:02
    /// </summary>
    [Serializable]
    public class Produtos : IProduto, IEnumerable<Produto>
    {
        #region ESTADOS

        static List<Produto> produtos; //lista que contem todos os produtos da loja

        #endregion

        #region COMPORTAMENTO

        #region Construtor

        static Produtos()
        {
           produtos = new List<Produto>();
        }

        #endregion

        #region PROPRIEDADES

        /// <summary>
        /// Propriedades da lista produtos
        /// </summary>
        public static List<Produto> PRODUTOS
        {
            set { produtos = value; }
            get { return produtos; }
        }

        #endregion

        #region OUTROSMETODOS

        /// <summary>
        /// Funcao para adicionar um produto a lista
        /// </summary>
        /// <param name="p">variavael para um produto</param>
        /// <returns>retorna true se o produto for adicionado ou false se nao</returns>
        public bool InserirProduto(Produto p)
        {
            if(ExisteProduto(p.Id) == false)
            {
                produtos.Add(p);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Funcao para alterar um produto
        /// </summary>
        /// <param name="id">variavel para o id do produto</param>
        /// <param name="t">variavel que determina que propriedade do produto deve ser alterada</param>
        /// <param name="nome">variavel para o nome do produto</param>
        /// <param name="categoria">variavel para a categoria do produto</param>
        /// <param name="preco">variavel para o preco do produto</param>
        /// <param name="garantia">variavel para a garantia do produto</param>
        /// <returns>retorna true se for alterado uma propriedade do produto e false se nao</returns>
        public bool AlterarProduto(int id, int[] t, string nome, string categoria, int preco, int garantia)
        {
            for(int o = 0;o< produtos.Count; o++)
            {
                if (produtos[o].Id == id)
                {
                    for(int i = 0;i < t.Length; i++)
                    {
                        switch (t[i])
                        {
                            case 1:
                                produtos[o].Nome = nome;
                                break;
                            case 2:
                                produtos[o].Categoria = categoria;
                                break;
                            case 3:
                                produtos[o].Preco = preco;
                                break;
                            case 4:
                                produtos[o].Garantia = garantia;
                                break;
                        }
                    } 
                }
            }
            return false;
        }
       
        /// <summary>
        /// Funcao para retirar um produto da loja 
        /// </summary>
        /// <param name="id">variavel para o id do produto</param>
        /// <returns>retorna true se o produto foi retirado ou false se nao</returns>
        public bool RetirarProduto(int id)
        {
            for (int i = 0; i < produtos.Count; i++)
            {
                if (produtos[i].Id == id)
                {
                    produtos.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Funcao para verificar se um produto ja existe
        /// </summary>
        /// <param name="id">variavel para o id do produto</param>
        /// <returns>retorna true se o produto existe e false se nao</returns>
        public bool ExisteProduto(int id)
        {
            foreach(Produto produto in produtos)
            {
                if(produto.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Funcao para guardar os produtos num ficheiro binario
        /// </summary>
        /// <param name="d">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool GuardarProdutoB(string d)
        {
            Stream s = File.Open(d, FileMode.Create);
            //testar se ficheiro...
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, produtos);
            s.Close();
            return true;
            
        }

        /// <summary>
        /// Funcao para ler os produtos de um ficheiro binario
        /// </summary>
        /// <param name="d">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool LerProdutoB(string d)
        {
            Stream s = File.Open(d, FileMode.Open);
            //testar se ficheiro...
            BinaryFormatter b = new BinaryFormatter();
            produtos = (List<Produto>)b.Deserialize(s);
            s.Close();
            return true;
        }

        /// <summary>
        /// Funcao para guardar os produtos num ficheiro de texto
        /// </summary>
        /// <param name="d">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool GuardarProduto(string d)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(d))
                {
                    foreach (var produto in produtos)
                    {
                        writer.WriteLine($"{produto.Id}#{produto.Nome}#{produto.Categoria}#{produto.Garantia}#{produto.Preco}#{produto.IdM}");
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gravar produtos: {ex.Message}");
                return false;
            };
        }

        /// <summary>
        /// Funcao para ler os produtos de um ficheiro de texto
        /// </summary>
        /// <param name="d">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool LerProduto(string d)
        {
            using (StreamReader sr = File.OpenText(d))
            {
                string linha = sr.ReadLine();
                while (linha != null)
                {
                    string[] sdados = linha.Split('#');
                    int id = int.Parse(sdados[0]);
                    string nome = sdados[1];
                    string categoria = sdados[2];
                    int garantia = int.Parse(sdados[3]);
                    int preco = int.Parse(sdados[4]);
                    int idm = int.Parse(sdados[5]);


                    Produto produto = new Produto(id,nome,categoria,preco,garantia,idm);

                    produtos.Add(produto);

                    linha = sr.ReadLine();
                }
            }
            return true;
        }

        /// <summary>
        /// Funcao para devolver um produto
        /// </summary>
        /// <param name="id">variavel para o id do produto</param>
        /// <returns></returns>
        public bool DevolverProduto(int id)// desenvolver
        {
            return true;
        }

        /// <summary>
        /// Funcao para trocar um produto
        /// </summary>
        /// <param name="id">variavel para o id do produto</param>
        /// <returns></returns>
        public bool TrocarProduto(int id)// desenvolver
        {
            return false;
        }

        /// <summary>
        /// funcao para buscar o proximo id do produto
        /// </summary>
        /// <param name="id">variavel para o id do produto</param>
        /// <returns>retorna o id</returns>
        public int ID(int id)
        {
            for (int i = 0; i < produtos.Count; i++)
            {
                id = produtos[i].Id;
            }
            id++;
            return id;
        }

        public void Ordenar()
        {
            produtos.Sort();
        }

        #endregion

        #region IEnumerable<Produto> Members

        public IEnumerator<Produto> GetEnumerator()
        {
            return produtos.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return produtos.GetEnumerator();
        }

        #endregion

        #endregion
    }
}

