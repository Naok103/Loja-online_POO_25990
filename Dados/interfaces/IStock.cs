using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objetos;

namespace Dados
{
    internal interface IStock
    {
        Stock AdicionarStock(Stock s);

        Stock RetirarStock(Stock s);

        bool ExisteStock(Stock s);
        
    }
}
