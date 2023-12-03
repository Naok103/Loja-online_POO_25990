using System;
using Dados;
using Loja_online;
using Objetos;

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

        public bool InserirStock()
        {
            IO io = new IO();
            Stocks stocks = new Stocks();
            int idp, quantidade, id = 0;
            id = stocks.ID(id);

            io.DadosStock(out idp, out quantidade);
            // if(produto.ExisteProduto(idp) == true)
            Stock stock = new Stock(quantidade,idp,id);
            stocks.InserirStock(stock);

            return true;
        }

        public bool AdicionarStock()
        {
            IO io = new IO();
            Stocks stocks = new Stocks();
            int idp, quantidade;


            io.DadosStock(out idp, out quantidade);
            // if(produto.ExisteProduto(idp) == true);
            stocks.AdicionarStock(idp,quantidade);

            return true;
        }

        public bool RetirarStock()
        {
            IO io = new IO();
            Stocks stocks = new Stocks();
            int idp, quantidade;


            io.DadosStock(out idp, out quantidade);
            // if(produto.ExisteProduto(idp) == true);
            stocks.RetirarStock(idp, quantidade);

            return true;
        }

        public bool AcabarStock(int id)
        {
            Stocks stocks = new Stocks();
            if (stocks.ExisteStock(id) == true)
            {
                stocks.AcabarStock(id);
                return true;
            }
            return false;
        }

        public bool GravarStocks(Stocks stocks, string m)
        {
            stocks.GravarStock(m);
            return true;
        }

        public Stocks LerStocks(Stocks stocks, string m)
        {
            stocks.LerStock(m);
            return stocks;
        }

        #endregion

        #region CAMPANHA



        #endregion

    }
}

