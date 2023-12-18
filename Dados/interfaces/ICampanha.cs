using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objetos;

namespace Dados
{
    internal interface ICampanha
    {
        bool InseirCampanha(Campanha campanha);

        bool AdicionarProdutoCampanha(string nome, Produto p);

        bool RetirarProdutoCampanha(string nome, int id);

        bool AlterarCampanha(int t, string nome, int duracao, int desconto);

        bool RetirarCampanha(string nome);

        bool ExisteCampanha(string nome);

        bool GuardarCampanhasB(string m);

        bool LerCampanhasB(string m);

        bool GuardarCampanhas(string m);

        bool LerCampanhas(string m);

        bool GuardarProdutoCampanha(string m);

        bool LerProdutoCampanha(string m);
    }
}
