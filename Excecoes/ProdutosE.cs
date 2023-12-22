using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Excecoes
{
    /// <summary>
    /// Purpose:
    /// Created by: Rafael silva
    /// Created on: 22/12/2023 16:44:08
    /// </summary>
    public class ProdutosE : Exception
    {
        public ProdutosE() : base("Erro em produtos")
        {

        }

        public ProdutosE(string s) : base(s) { }


        public ProdutosE(string s, Exception e)
        {
            throw new ProdutosE(s + "-" + e.Message);
        }
    }
}

