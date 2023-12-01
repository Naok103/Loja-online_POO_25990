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
        bool AdicionarStock(Stock s);

        bool RetirarStock(Stock s);

        bool ExisteStock(Stock s);

        bool AlterarStock(Stock s);

        bool GravarStockB(Stock s);

        bool LerStockB(Stock s);

        bool GravarStock(Stock s);

        bool LerStock(Stock s);


    }
}
