﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Classes2
{
    /// <summary>
    /// Purpose: Classe para guardar os metodos relacionados com Vendas
    /// Created by: Rafael silva
    /// Created on: 21/11/2023 10:55:28
    /// </summary>
    internal class Vendas : IVenda
    {
        public Venda AlterarVenda(Venda v)
        {
            return v;
        }

        public Venda RetirarVenda(Venda v)
        {
            return v;
        }

        public bool ExisteVendas(Venda v)
        {
            return true;
        }
    }
}

