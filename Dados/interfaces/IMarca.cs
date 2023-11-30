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
        Marca AlterarMarca(Marca m);

        Marca RetirarMarca(Marca m);

        bool ExisteMarca(Marca m);

    }
}
