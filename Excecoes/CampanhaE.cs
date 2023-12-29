using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Excecoes
{
    /// <summary>
    /// Purpose: Classe para as excexoes relacionadas com campanhas
    /// Created by: Rafael silva
    /// Created on: 22/12/2023 17:28:30
    /// </summary>
    public class CampanhaE : Exception
    {
        public CampanhaE() : base("Erro em campanha")
        {

        }

        public CampanhaE(string s) : base(s) { }


        public CampanhaE(string s, Exception e)
        {
            throw new CampanhaE(s + "-" + e.Message);
        }
    }
}

