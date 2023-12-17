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
    /// Purpose:
    /// Created by: Rafael silva
    /// Created on: 21/11/2023 11:21:02
    /// </summary>
    [Serializable]
    public class Produtos : IProduto, IEnumerable<Produto>
    {
        #region ESTADOS

        static List<Produto> produtos;

        #endregion

        #region COMPORTAMENTO

        #region Construtor

        static Produtos()
        {
           produtos = new List<Produto>();
        }

        #endregion

        #region PROPRIEDADES

        public static List<Produto> PRODUTOS
        {
            set { produtos = value; }
            get { return produtos; }
        }

        #endregion

        #region OUTROSMETODOS


        public bool InserirProduto(Produto p)
        {
            if(ExisteProduto(p.Id) == false)
            {
                produtos.Add(p);
                return true;
            }
            return false;
        }

        public bool AlterarProduto(int id, int t, string nome, string categoria, int preco, int garantia)
        {
            for(int o = 0;o< produtos.Count; o++)
            {
                if (produtos[o].Id == id)
                {
                    switch(t)
                    {
                        case 1:
                            produtos[o].Nome = nome;
                            return true;
                        case 2:
                            produtos[o].Categoria = categoria;
                            return true;
                        case 3:
                            produtos[o].Preco = preco;
                            return true;
                        case 4:
                            produtos[o].Garantia = garantia;
                            return true;
                    }
                }
            }
            return false;
        }
       

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

        public bool GuardarProdutoB(string d)
        {
            Stream s = File.Open(d, FileMode.Create);
            //testar se ficheiro...
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, produtos);
            s.Close();
            return true;
            
        }

        public bool LerProdutoB(string d)
        {
            Stream s = File.Open(d, FileMode.Open);
            //testar se ficheiro...
            BinaryFormatter b = new BinaryFormatter();
            produtos = (List<Produto>)b.Deserialize(s);
            s.Close();
            return true;
        }


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

        public bool DevolverProduto(int id)// desenvolver
        {
            return true;
        }

        public bool TrocarProduto(int id)// desenvolver
        {
            return false;
        }

        public int ID(int id)
        {
            for (int i = 0; i < produtos.Count; i++)
            {
                id = produtos[i].Id;
            }
            id++;
            return id;
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

