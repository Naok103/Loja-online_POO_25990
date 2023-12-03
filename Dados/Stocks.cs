using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;
using Objetos;

namespace Dados
{
    /// <summary>
    /// Purpose: Classe para guardar os metodos relacionados com Stock
    /// Created by: Rafael silva
    /// Created on: 21/11/2023 10:56:04
    /// </summary>
    public class Stocks : IStock, IEnumerable<Stock>
    {
        
        #region ESTADO 

       static List<Stock> stocks;

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

        public static List<Stock> STOCKS
        {
            get { return stocks; }
            set { stocks = value; }
        }

        #endregion

        #region OUTROSMETODOS

        public bool InserirStock(Stock s)
        {
            if (ExisteStock(s.IDP) == false)
            {
                stocks.Add(s);
                Console.WriteLine("exito!");
                return true;
            }
            return false;    
        }

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

        public bool AdicionarStock(int id, int quantidade)
        {
            for (int i = 0; i < stocks.Count; i++)
            {
                if (stocks[i].IDP == id)
                {
                    stocks[i].Quantidade += quantidade;
                }
            }
            return true;
        }

        public bool RetirarStock(int id, int quantidade)
        {
            for(int i = 0; i < stocks.Count; i++)
            {
                if (stocks[i].IDP == id)
                {
                    stocks[i].Quantidade -= quantidade;
                }
            }
            return true;
        }

        public int ID(int id)
        {
            for (int i = 0; i < stocks.Count; i++)
            {
                id = stocks[i].ID;
            }
            id++;
            return id;
        }

        public bool GravarStockB(string m)
        {
            Stream s = File.Open(m, FileMode.Create);
            //testar se ficheiro...
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, stocks);
            s.Close();
            return true;
        }

        public bool LerStockB(string m)
        {
            Stream s = File.Open(m, FileMode.Open);
            //testar se ficheiro...
            BinaryFormatter b = new BinaryFormatter();
            stocks = (List<Stock>)b.Deserialize(s);
            s.Close();
            return true;

        }

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

        #endregion

        #endregion
    }
}

