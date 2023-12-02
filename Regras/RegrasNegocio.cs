using System;
using static System.Exception;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dados;
using Loja_online;
using Objetos;
using System.Security.Policy;


namespace Regras
{
    /// <summary>
    /// Purpose:
    /// Created by: Rafael silva
    /// Created on: 01/12/2023 11:16:31
    /// </summary>
    public class RegrasNegocio
    {
        #region CLIENTES



        #endregion

        #region PRODUTO



        #endregion

        #region MARCA

        public bool InserirMarca()
        {
            IO io = new IO();
            Marcas marcas = new Marcas();
            string nome, site;

            int id = 0;
            id = marcas.ID(id);

            if (marcas.ExisteMarca(id) == false)
            {
                io.DadosMarca(out nome, out site);
                Marca marca = new Marca(id, nome, site);
                marcas.InserirMarca(marca);
                return true;
            }
            return false;
            /*
            try
            {
                marcas.InserirMarca(marca);
                return true;
            }
            catch (Exception e) { }
            {
                throw new Exception(e.Message +  " - Falha de Regras de Negocio");
            }
            */
        }

        public bool AlterarMarca(int id)
        {
            IO io = new IO();
            Marcas marca = new Marcas();
            string nome, site;
            int i;
            if(marca.ExisteMarca(id) == true)
            {
                io.AlterarDadosM(out nome, out site, out i);
                marca.AlterarMarca(id, i, nome, site);
                return true;
            }
            return false;
        }

        public bool RetirarMarca(int id)
        {
            Marcas marcas = new Marcas();
            if (marcas.ExisteMarca(id) == true)
            {
                marcas.RetirarMarca(id);
                return true;
            }
            return false;
        }

        public bool GravarMarcas(Marcas marcas, string m)
        {

            marcas.GravarMarcas(m);
            return true;
        }

        public Marcas LerMarcas(Marcas marcas, string m)
        {
            marcas.LerMarcas(m);
            return marcas;
        }

        #endregion

        #region VENDA



        #endregion

        #region STOCK



        #endregion

        #region CAMPANHA



        #endregion

    }
}

