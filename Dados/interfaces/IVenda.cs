using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objetos;

namespace Dados
{
    internal interface IVenda
    {
        bool AdicionarVenda(Venda v);

        bool GuardarVendaB(string m);

        bool LerVendaB(string m);

        bool GuardarVenda(string m);

        bool LerVenda(string m);

    }
}
