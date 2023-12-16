using objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dados
{
    /// <summary>
    /// Purpose:
    /// Created by: Rafael silva
    /// Created on: 16/12/2023 15:22:24
    /// </summary>
    internal interface IManager
    {
        bool InserirManager(Manager maanager);

        bool ExisteManager(int id);

        bool AlterarManager(int id, int t, string nome, int contacto, int nif, string pass);

        bool RetirarManager(int id);

        int ID(int id);

        bool GuardarManagerB(string m);

        bool LerManagerB(string m);

        bool GuardarManager(string m);

        bool LerManager(string m);
    }
}

