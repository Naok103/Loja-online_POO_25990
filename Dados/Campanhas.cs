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
    /// Purpose: Classe para guardar os metodos relacionados com Campanha
    /// Created by: Rafael silva
    /// Created on: 21/11/2023 10:54:43
    /// </summary>
    public class Campanhas : ICampanha
    {
        public Campanha AlterarCampanha(Campanha c)
        {
            return c;
        }

        public Campanha RetirarCampanha(Campanha c)
        {
            return c;
        }

        public bool ExisteCampanha(Campanha c)
        {
            return true;
        }
    }
}

