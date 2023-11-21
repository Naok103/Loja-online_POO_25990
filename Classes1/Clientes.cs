using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Classes1
{
    /// <summary>
    /// Purpose:
    /// Created by: Rafael silva
    /// Created on: 21/11/2023 11:20:36
    /// </summary>
    internal class Clientes : ICliente
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

