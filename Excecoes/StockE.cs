using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Excecoes
{
    /// <summary>
    /// Purpose: Classe para as excexoes relacionadas com stocks
    /// Created by: Rafael silva
    /// Created on: 22/12/2023 19:28:09
    /// </summary>
    public class StockE : Exception
    {
        public StockE() : base("Erro em produtos")
        {

        }

        public StockE(string s) : base(s) { }


        public StockE(string s, Exception e)
        {
            throw new StockE(s + "-" + e.Message);
        }
    }
}

