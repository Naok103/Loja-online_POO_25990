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
        bool AdicionarCliente(Cliente c);

        bool AlterarCliente(int id, int d, string nome, int contacto, int nif, string morada);

        bool ExisteCliente(int id);

        bool RetirarCliente(int id);

        bool GravarClienteB(string m);

        bool LerClienteB(string m);

        bool GravarCliente(string m);

        bool LerCliente(string m);

    }
}
