using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objetos;

namespace Dados
{
    internal interface IProduto
    {
        Produto AlterarProduto(Produto p);

        Produto RetirarProduto(Produto p);

        bool ExisteProduto(Produto p);
    }
}
