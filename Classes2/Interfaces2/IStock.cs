﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes2
{
    internal interface IStock
    {
        Stock AdicionarStock(Stock s);


        Stock RetirarStock(Stock s);


        bool ExisteStock(Stock s);
        
    }
}
