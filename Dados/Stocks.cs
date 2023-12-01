using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Objetos;

namespace Dados
{
    /// <summary>
    /// Purpose: Classe para guardar os metodos relacionados com Stock
    /// Created by: Rafael silva
    /// Created on: 21/11/2023 10:56:04
    /// </summary>
    public class Stocks : IStock
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

        public bool AdicionarStock(Stock s)
        {
            if (ExisteStock(s) == false)
            {
                stocks.Add(s);
                Console.WriteLine("exito!");
                return true;

            }

            return false;
            
        }

        public bool RetirarStock(Stock s)
        {
            if (ExisteStock(s) == true)
            {
                for (int i = 0; i < stocks.Count; i++)
                {
                    if (stocks[i] == s)
                    {
                        stocks.RemoveAt(i);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool ExisteStock(Stock s)
        {
            foreach (Stock stock in stocks)
            {
                if (stock == s)          
                {
                    return true;
                }
            }
            return false;
        }

        public bool AlterarStock(Stock s)
        {
            return true;
        }

        public bool GravarStockB(Stock s)
        {
            return true;

        }

        public bool LerStockB(Stock s)
        {
            return true;

        }

        public bool GravarStock(Stock s)
        {
            return true;

        }

        public bool LerStock(Stock s)
        {
            return true;

        }

        #endregion

        #endregion
    }
}

