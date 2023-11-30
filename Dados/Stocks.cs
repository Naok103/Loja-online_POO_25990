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
        public Stock AdicionarStock(Stock s)
        {
            return s;
        }

        public Stock RetirarStock(Stock s)
        {
            return s;
        }

        public bool ExisteStock(Stock s) 
        {
            return true;
        }
    }
}

