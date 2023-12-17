using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        public bool InseirCampanha(Campanha campanha, Produtos produtos, int id)
        {
            return false;
        }

        public bool AlterarCampanha(int id, string nome)
        {
            return false;
        }

        public bool RetirarCampanha(string nome)
        {
            return false;
        }

        public bool ExisteCampanha(string nome)
        {
            return false;
        }

        public bool GuardarCampanhasB(string m)
        {
            return false;
        }

        public bool LerCampanhasB(string m)
        {
            return false;
        }

        public bool GuardarCampanhas(string m)
        {
            return false;
        }

        public bool LerCampanhas(string m)
        {
            return false;
        }
    }
}

