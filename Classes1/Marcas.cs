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
    /// Created on: 21/11/2023 11:19:58
    /// </summary>
    internal class Marcas : IMarca
    {
        public Marca AlterarMarca(Marca m)
        {
            return m;
        }

        public Marca RetirarMarca(Marca m)
        {
            return m;
        }

        public bool ExisteMarca(Marca m)
        {
            return true;
        }
    }
}

