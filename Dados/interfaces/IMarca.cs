using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objetos;

namespace Dados
{
    internal interface IMarca
    {
        bool InserirMarca(Marca m);

        bool AlterarMarca(int id, int i, string nome, string site);

        bool RetirarMarca(int id);

        bool ExisteMarca(int id);
        int ID(int id);

        bool GravarMarcasB(string m);

        bool LerMarcasB(string m);

        bool GravarMarcas(string m);

        bool LerMarcas(string m);

    }
}
