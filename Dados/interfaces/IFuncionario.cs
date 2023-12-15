using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using objetos;


namespace Dados
{
    /// <summary>
    /// Purpose:
    /// Created by: Rafael silva
    /// Created on: 14/12/2023 16:37:20
    /// </summary>
    internal interface IFuncionario
    {
        bool InserirFuncionario(Funcionario funcionario);

        bool ExisteFuncionario(int id);

        bool AlterarFuncionario(int id, int t, string nome, int contacto, int nif);

        bool RetirarFuncionario(int id);

        bool GuardarFuncionarioB(string m);

        bool LerFuncionarioB(string m);

        bool GuardarFuncionario(string m);

        bool LerFuncionario(string m);
    }
}

