using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Objetos;


namespace Dados
{
    /// <summary>
    /// Purpose:
    /// Created by: Rafael silva
    /// Created on: 21/11/2023 11:20:36
    /// </summary>
    public class Clientes : ICliente
    {
        public Cliente AlterarCliente(Cliente c)
        {
            return c;
        }

        public Cliente RetirarCliente(Cliente c)
        {
            return c;
        }

        public bool ExisteCliente(Cliente c)
        {
            return true;
        }
    }
}

