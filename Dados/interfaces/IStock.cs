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
        bool InserirStock(Stock s);

        bool AcabarStock(int id);

        bool ExisteStock(int id);

        bool AdicionarStock(int id, int quantidade);

        bool RetirarStock(int id, int quantidade);

        int ID(int id);

        bool GravarStockB(string m);

        bool LerStockB(string m);

        bool GravarStock(string m);

        bool LerStock(string m);


    }
}
