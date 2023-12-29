using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;
using Objetos;
using Excecoes;

namespace Dados
{
    /// <summary>
    /// Purpose: Classe para guardar os metodos relacionados com Stock
    /// Created by: Rafael silva
    /// Created on: 21/11/2023 10:56:04
    /// </summary>
    [Serializable]
    public class Stocks : IStock, IEnumerable<Stock>
    {
        
        #region ESTADO 

       static List<Stock> stocks; // listas que contem o stock da loja

        #endregion

        #region COMPORTAMENTO

        #region CONSTRUTORES

        /// <summary>
        /// Construtor por omissão
        /// </summary>
        static Stocks()
        {
            stocks = new List<Stock>();
        }

        #endregion

        #region PROPRIEDADES

        /// <summary>
        /// propriedades da lista stocks
        /// </summary>
        public static List<Stock> STOCKS
        {
            get { return stocks; }
            set { stocks = value; }
        }

        #endregion

        #region OUTROSMETODOS

        /// <summary>
        /// Funcao para adicionar um stock a lista
        /// </summary>
        /// <param name="s">variavel para um stock</param>
        /// <returns>retorna true se o stock foi adicionado ou false se nao</returns>
        public bool InserirStock(Stock s)
        {
            if (ExisteStock(s.IDP) == true)
            {
                throw new StockE();
            }

            stocks.Add(s);
            return true;
        }

        /// <summary>
        /// Funcao para retirar um stock da lista
        /// </summary>
        /// <param name="id">variavel para o id do stock</param>
        /// <returns>retorna true se o stock foi retirado ou false se nao</returns>
        public bool AcabarStock(int id)
        {
            for (int i = 0; i < stocks.Count; i++)
            {
                if (stocks[i].IDP == id)
                {
                    stocks.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Funcao para verificar se um stock ja existe
        /// </summary>
        /// <param name="id">variavel para o id do stock</param>
        /// <returns>retorna true se o stock existe ou false se nao</returns>
        public bool ExisteStock(int id)
        {
            foreach (Stock stock in stocks)
            {
                if (stock.IDP == id)          
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Funcao para adicionar produtos a um stock ja existente
        /// </summary>
        /// <param name="id">variavel para o id do produto</param>
        /// <param name="quantidade">variavel para a quantidade do produto a ser adicioanda ao stock</param>
        /// <returns>retorna true se os produto/s foi/foram adicionado/s ou false se nao</returns>
        public bool AdicionarStock(int id, int quantidade)
        {
            if (ExisteStock(id) == true)
            {
                throw new StockE();
            }

            for (int i = 0; i < stocks.Count; i++)
            {
                if (stocks[i].IDP == id)
                {
                    stocks[i].Quantidade += quantidade; 
                }
            }
            return true;
        }

        /// <summary>
        /// Funcao para retirar produtos de um stock ja exixtente
        /// </summary>
        /// <param name="id">variavel para o id do produto</param>
        /// <param name="quantidade">variavel para a quantidade do produto a ser retirada do stock</param>
        /// <returns>retorna true se os produto/s foi/foram retirado/s ou false se nao</returns>
        public bool RetirarStock(int id, int quantidade)
        {
            for (int i = 0; i < stocks.Count; i++)
            {
                if (stocks[i].IDP == id)
                {
                    stocks[i].Quantidade -= quantidade;
                    return true;
                }
            }

            return false;
        }

        public bool VerificarQuantidade(int id, int quantidade)
        {
            for (int i = 0; i < stocks.Count; i++)
            {
                if (stocks[i].IDP == id)
                {
                    if(quantidade < stocks[i].Quantidade)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// funcao para buscar o proximo id do stock
        /// </summary>
        /// <param name="id">variavel para o id do stock</param>
        /// <returns>retorna o id</returns>
        public int ID(int id)
        {
            for (int i = 0; i < stocks.Count; i++)
            {
                id = stocks[i].ID;
            }
            id++;
            return id;
        }

        /// <summary>
        /// Funcao para guardar o stock num ficheiro binario
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool GravarStockB(string m)
        {
            Stream s = File.Open(m, FileMode.Create);
            //testar se ficheiro...
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, stocks);
            s.Close();
            return true;
        }

        /// <summary>
        /// Funcao para ler o stock de um ficheiro binario
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool LerStockB(string m)
        {
            Stream s = File.Open(m, FileMode.Open);
            //testar se ficheiro...
            BinaryFormatter b = new BinaryFormatter();
            stocks = (List<Stock>)b.Deserialize(s);
            s.Close();
            return true;

        }

        /// <summary>
        /// Funcao para guardar o stock num ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool GravarStock(string m)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(m))
                {
                    foreach (var stock in stocks)
                    {
                        writer.WriteLine($"{stock.ID}#{stock.Quantidade}#{stock.IDP}");
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
        /// Funcao para ler o stock de um ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool LerStock(string m)
        {
            using (StreamReader sr = File.OpenText(m))
            {
                string linha = sr.ReadLine();
                while (linha != null)
                {
                    string[] sdados = linha.Split('#');
                    int id = int.Parse(sdados[0]);
                    int quantidade = int.Parse(sdados[1]);
                    int idP = int.Parse(sdados[2]);

                    Stock stock = new Stock(quantidade, idP, id);

                    stocks.Add(stock);

                    linha = sr.ReadLine();
                }
            }
            return true;
        }

        #endregion

        #region IEnumerable<Stock> Members

        public IEnumerator<Stock> GetEnumerator()
        {
            return stocks.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return stocks.GetEnumerator();
        }

        public void Ordenar()
        {
            stocks.Sort();
        }

        #endregion

        #endregion
    }
}

