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
        bool InserirProduto(Produto p);

        bool AlterarProduto(int id, int t, string nome, string categoria, int preco, int garantia);

        bool RetirarProduto(int id);

        bool ExisteProduto(int id);

        bool GuardarProdutoB(string d);

        bool LerProdutoB(string d);

        bool GuardarProduto(string d);

        bool LerProduto(string d);

        bool DevolverProduto(int id);// desenvolver

        bool TrocarProduto(int id);// desenvolver

        int ID(int id);

    }
}
