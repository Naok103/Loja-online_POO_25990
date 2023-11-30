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

        bool AlterarMarca(Marca m);

         bool RetirarMarca(Marca m);

         bool ExisteMarca(Marca m);

         bool GravarMarcasB(string m);

         bool LerMarcasB(string m);

        bool GravarMarcas(string m);

        bool LerMarcas(string m);





    }
}
