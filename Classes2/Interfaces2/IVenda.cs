using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes2
{
    internal interface IVenda
    {
        Venda AlterarVenda(Venda v);

        Venda RetirarVenda(Venda v);

        bool ExisteVendas(Venda v);
    }
}
