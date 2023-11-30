using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objetos;

namespace Dados
{
    internal interface ICliente
    {
        Cliente RetirarCliente(Cliente c);
        Cliente AlterarCliente(Cliente c);
        bool ExisteCliente(Cliente c);
    }
}
