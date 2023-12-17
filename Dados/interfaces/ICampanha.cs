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
        bool InseirCampanha(Campanha campanha, Produtos produtos, int id);

        bool AlterarCampanha(int id, string nome);

        bool RetirarCampanha(string nome);

        bool ExisteCampanha(string nome);

        bool GuardarCampanhasB(string m);

        bool LerCampanhasB(string m);

        bool GuardarCampanhas(string m);

        bool LerCampanhas(string m);
    }
}
