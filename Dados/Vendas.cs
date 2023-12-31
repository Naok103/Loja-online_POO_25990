using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using Excecoes;
using Objetos;

namespace Dados
{
    /// <summary>
    /// Purpose: Classe para guardar os metodos relacionados com Vendas
    /// Created by: Rafael silva
    /// Created on: 21/11/2023 10:55:28
    /// </summary>
    [Serializable]
    public class Vendas : IVenda, IEnumerable<Venda>
    {
        #region ESTADO 

        static List<Venda> vendas; //lista com o conjunto de vendas realizadas

        #endregion

        #region COMPORTAMENTO

        #region CONSTRUTORES

        /// <summary>
        /// Construtor por omissão
        /// </summary>
        static Vendas()
        {
            vendas = new List<Venda>();
        }

        #endregion

        #region PROPRIEDADES

        /// <summary>
        /// Propriedade da lista vendas
        /// </summary>
        public static List<Venda> VENDAS
        {
            get { return vendas; }
            set { vendas = value; }
        }

        #endregion

        #region OUTROSMETODOS

        /// <summary>
        /// Funcao para adicionar uma venda a lista de vendas
        /// </summary>
        /// <param name="v">variavel para uma venda</param>
        /// <returns></returns>
        public bool AdicionarVenda(Venda v)
        {
            vendas.Add(v);
            return true;
        }

        /// <summary>
        /// Funcao para adicionar produtos e as suas quantidades vendidas a um dicionario de uma venda
        /// </summary>
        /// <param name="q"> variavel array para a quantidade vendida de cada produto</param>
        /// <param name="id">variavel array para os ids dos produtos vendidos</param>
        /// <param name="id">variavel para o id da venda</param>
        /// <returns></returns>
        public bool AdicionarProdutos(int[] p, int[] q, int id)
        {
            foreach(Venda venda in vendas)
            {
                if(venda.ID == id)
                {
                    for (int i = 0; i < p.Length; i++)
                    {
                        venda.Produtos.Add(p[i], q[i]);
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Funcao para verificar se uma venda ja existe
        /// </summary>
        /// <param name="id">variavel para o id da venda</param>
        /// <returns>retorna true se a venda existe e false se nao</returns>
        public bool ExisteVenda(int id)
        {
            foreach (Venda venda in vendas)
            {
                if (venda.ID == id)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Funcao para calcular o preco de uma venda
        /// </summary>
        /// <param name="q"> variavel array para a quantidade vendida de cada produto</param>
        /// <param name="p">variavel array para os ids dos produtos vendidos</param>
        /// <param name="id">variavel para o id da venda</param>
        /// <param name="preco">variavel para o preco da venda</param>
        /// <param name="produtos">variavel para a lista de produtos</param>
        /// <param name="campanhas">variavel para a lista de campanhas</param>
        /// <returns></returns>
        public double CalculaPreco(int[] p, int[] q, int id, double preco, Produtos produtos, Campanhas campanhas)
        {
            double aux;
            double desconto;
            for (int i = 0; i < p.Length; i++)
            {
                foreach (Produto produto in produtos)
                {
                    if (produto.Id == p[i])
                    {
                        aux = produto.Preco * q[i];
                        preco += aux;
                    }
                }
                foreach (Campanha campanha in campanhas)
                {
                    foreach (Produto produto in campanha.IDP)
                    {
                        if (produto.Id == p[i])
                        {
                            desconto = campanha.Desconto;
                            desconto *= produto.Preco;
                            desconto *= q[i];
                            preco -= desconto;
                        }
                    }
                }
            }

            return preco;
        }

        /// <summary>
        /// funcao para buscar o proximo id da venda
        /// </summary>
        /// <param name="id">variavel para o id da venda</param>
        /// <returns>retorna o id</returns>
        public int ID(int id)
        {
            for (int i = 0; i < vendas.Count; i++)
            {
                id = vendas[i].ID;
            }
            id++;
            return id;
        }

        /// <summary>
        /// Funcao para guardar as vendas num ficheiro binario
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool GuardarVendaB(string m)
        {
            Stream s = File.Open(m, FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, vendas);
            s.Close();
            return true;
        }

        /// <summary>
        /// Funcao para ler as vendas de um ficheiro binario
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool LerVendaB(string m)
        {
            Stream s = File.Open(m, FileMode.Open);
            BinaryFormatter b = new BinaryFormatter();
            vendas = (List<Venda>)b.Deserialize(s);
            s.Close();
            return true;
        }

        /// <summary>
        /// Funcao para guardar as vendas num ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool GuardarVenda(string m)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(m))
                {
                    foreach (var venda in vendas)
                    {
                        writer.WriteLine($"{venda.ID}#{venda.IDC}#{venda.Hora}#{venda.Preco}");
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gravar produtos: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Funcao para ler as vendas de um ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool LerVenda(string m)
        {
            using (StreamReader sr = File.OpenText(m))
            {
                string linha = sr.ReadLine();
                while (linha != null)
                {
                    string[] sdados = linha.Split('#');
                    int Id = int.Parse(sdados[0]);
                    int Idc = int.Parse(sdados[1]);
                    DateTime hora = DateTime.Parse(sdados[2]);
                    double Preco = double.Parse(sdados[3]);

                    Venda venda = new Venda(Idc, hora, Id, Preco);
                    vendas.Add(venda); 

                    linha = sr.ReadLine();
                }
            }
            return true;
        }

        /// <summary>
        /// Funcao para guardar as quantidades e produtos de uma venda num ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool GuardarVendaProduto(string m)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(m))
                {
                    foreach (var venda in vendas)
                    {
                        foreach(var p in venda.Produtos)
                        {
                            writer.WriteLine($"{venda.ID}#{p.Key}#{p.Value}");
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gravar produtos: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Funcao para ler as quantidades e produtos de uma venda num ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool LerVendaProduto(string m)
        {
            using (StreamReader sr = File.OpenText(m))
            {
                string linha = sr.ReadLine();
                while (linha != null)
                {
                    string[] sdados = linha.Split('#');
                    int Id = int.Parse(sdados[0]);
                    int IdP = int.Parse(sdados[1]);
                    int Quantidade = int.Parse(sdados[2]);

                    int[] q = new int[1];
                    int[] p = new int[1];
                    q[0] = Quantidade;
                    p[0] = IdP;

                    AdicionarProdutos(p, q, Id);

                    linha = sr.ReadLine();
                }
            }
            return true;
        }

        public void Ordenar()
        {
            vendas.Sort();
        }

        #endregion

        #region IEnumerable<Venda> Members

        public IEnumerator<Venda> GetEnumerator()
        {
            return vendas.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return vendas.GetEnumerator();
        }

        #endregion

        #endregion

    }
}

