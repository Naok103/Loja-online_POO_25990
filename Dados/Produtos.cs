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
    /// Purpose:
    /// Created by: Rafael silva
    /// Created on: 21/11/2023 11:21:02
    /// </summary>
    public class Produtos : IProduto
    {
        public Produto AlterarProduto(Produto p)
        {
            return p;
        }

        public Produto RetirarProduto(Produto p)
        {
            return p;
        }

        public bool ExisteProduto(Produto p)
        {
            return true;
        }
    }
}

