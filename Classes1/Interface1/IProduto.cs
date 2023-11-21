using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes1
{
    internal interface IProduto
    {
        Produto AlterarProduto(Produto p);
        Produto RetirarProduto(Produto p);
        bool ExisteProduto(Produto p);
    }
}
