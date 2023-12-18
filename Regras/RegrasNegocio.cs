using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Dados;
using Loja_online;
using objetos;
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
        #region CLIENTE

        public bool InserirCliente()
        {
            IO io = new IO();
            Clientes clientes = new Clientes();
            int id = 0, nif, contacto;
            string nome, morada, aux1, aux2;
            id = clientes.ID(id);
            io.DadosClientes(out nome, out contacto, out nif, out morada);
            aux1 = contacto.ToString();
            aux2 = nif.ToString();
            if ((aux1.Length == 9) && (aux2.Length == 9) )
            {
                Cliente cliente = new Cliente(id, nome, contacto, nif, morada);
                clientes.AdicionarCliente(cliente);
                return true;
            }
            return false;
        }

        public bool AlterarCliente(int id)
        {
            IO io = new IO();
            Clientes clientes = new Clientes();
            int nif, contacto, i;
            string nome, morada;
            if (clientes.ExisteCliente(id) == true)
            {
                io.AlterarDadosC(out i, out nome, out contacto, out nif, out morada);
                clientes.AlterarCliente(id, i, nome, contacto, nif, morada);
                return true;
            }
            return false;
        }

        public bool RetirarCliente(int id)
        {
            Clientes clientes = new Clientes();
            if(clientes.ExisteCliente(id) == true)
            {
                clientes.RetirarCliente(id); 
                return true;
            }
            return false;
        }

        public bool GuardarClientes(Clientes clientes, string m)
        {
            clientes.GravarCliente(m);
            return true;
        }

        public Clientes LerClientes(Clientes clientes, string m)
        {
            clientes.LerCliente(m);
            return clientes;
        }

        #endregion

        #region PRODUTO

        public bool InserirProduto(Marcas marcas, int idm)
        {
            IO io = new IO();
            Produtos produtos = new Produtos();
            string nome, categoria;
            int preco, id = 0, garantia;
            
            if (marcas.ExisteMarca(idm) == true)
            {
                io.DadosProdutos(out nome, out categoria, out preco, out garantia);
                id = produtos.ID(id);
                Produto produto = new Produto(id,nome,categoria,preco,garantia,idm);
                produtos.InserirProduto(produto);
                return true;
            }
            return false;
        }

        public bool AlterarProduto(int id)
        {
            IO io = new IO();
            Produtos produtos = new Produtos();
            string nome, categoria;
            int i, preco,garantia;

            if (produtos.ExisteProduto(id) == false)
            {
                io.AlterarDadosP(out nome, out categoria, out preco, out garantia, out i);
                produtos.AlterarProduto(id,i,nome,categoria,preco,garantia);
                return true;
            }
            return false;
        }

        public bool RetirarProduto(int id)
        {

            Produtos produtos = new Produtos();
            if (produtos.ExisteProduto(id) == true)
            {
                produtos.RetirarProduto(id);
                return true;
            }
            return false;
        }

        public bool GravarProduto(Produtos produtos, string m)
        {
            produtos.GuardarProduto(m);
            return true;
        }

        public Produtos LerProduto(Produtos produtos, string m)
        {
            produtos.LerProduto(m);
            return produtos;
        }

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

        public bool RealizarVenda(Vendas vendas, Produtos produtos, Clientes clientes)
        {
            IO io = new IO();

            int quantidade, idc, idp;
            DateTime hora;

            io.DadosVenda(out quantidade, out idc, out idp);

            if(produtos.ExisteProduto(idp) == true && clientes.ExisteCliente(idp) == true)
            {
                hora = DateTime.Now;
                Venda venda = new Venda(quantidade, idp, idc, hora);
                vendas.AdicionarVenda(venda);
                return true;
            }
            return false;
        }

        public bool GuardarVendas(Vendas vendas, string m)
        {
            vendas.GuardarVenda(m);
            return true;
        }

        public Vendas LerVendas(Vendas vendas, string m)
        {
            vendas.LerVenda(m);
            return vendas;
        }

        #endregion

        #region STOCK

        public bool InserirStock(Produtos produtos)
        {
            IO io = new IO();
            Stocks stocks = new Stocks();
            int idp, quantidade, id = 0;
            id = stocks.ID(id);

            io.DadosStock(out idp, out quantidade);
            if(produtos.ExisteProduto(idp) == true)
            {
                Stock stock = new Stock(quantidade, idp, id);
                stocks.InserirStock(stock);
                return true;
            }
            return false;
        }

        public bool AdicionarStock(Produtos produtos)
        {
            IO io = new IO();
            Stocks stocks = new Stocks();
            int id, quantidade;


            io.DadosStock(out id, out quantidade);
            if(produtos.ExisteProduto(id) == true)
            {
                stocks.AdicionarStock(id, quantidade);
                return true;
            }

            return false;
        }

        public bool RetirarStock(Produtos produtos)
        {
            IO io = new IO();
            Stocks stocks = new Stocks();
            int id, quantidade;


            io.DadosStock(out id, out quantidade);
            if(produtos.ExisteProduto(id) == true)
            {
                stocks.RetirarStock(id, quantidade);
            }
            
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

        #region FUNCIONARIO

        public bool InserirFuncionario()
        {
            IO io = new IO();
            Funcionarios funcionarios = new Funcionarios();

            int id = 0 , nif, contacto;
            string nome, aux1, aux2;

            id = funcionarios.ID(id);

            io.DadosFuncionario(out nome, out nif, out contacto);
            aux1 = contacto.ToString();
            aux2 = nif.ToString();
            
            if ((aux1.Length == 9) && (aux2.Length == 9))
            {
                Funcionario funcionario = new Funcionario(id, nome, contacto, nif);
                funcionarios.InserirFuncionario(funcionario);
                return true;
            }
            return false;
        }

        public bool AlterarFuncionario(int id)
        {
            IO io = new IO();
            Funcionarios funcionarios = new Funcionarios();

            int nif, contacto, i;
            string nome;

            if (funcionarios.ExisteFuncionario(id) == true)
            {
                io.AlterarDadosF(out i, out nome, out contacto, out nif);
                funcionarios.AlterarFuncionario(id, i, nome, contacto, nif);
                return true;
            }
            return false;
        }

        public bool RetirarFuncionario(int id)
        {
            Funcionarios funcionarios = new Funcionarios();

            if(funcionarios.ExisteFuncionario(id) == true)
            {
                funcionarios.RetirarFuncionario(id);
                return true;
            }
            return false;
        }

        public bool GuardarFuncionario(Funcionarios funcionarios, string m)
        {
            funcionarios.GuardarFuncionario(m);
            return true;
        }

        public Funcionarios LerFuncionario(Funcionarios funcionarios, string m)
        {
            funcionarios.LerFuncionario(m);
            return funcionarios;
        }

        #endregion

        #region MANAGER

        public bool InserirManager()
        {
            IO io = new IO();
            Managers managers = new Managers();

            int id = 0, nif, contacto;
            string nome, aux1, aux2, pass;

            id = managers.ID(id);

            io.DadosManager(out nome, out nif, out contacto, out pass);
            aux1 = contacto.ToString();
            aux2 = nif.ToString();

            if ((aux1.Length == 9) && (aux2.Length == 9))
            {
                Manager manager = new Manager(id, nome, contacto, nif, pass);
                managers.InserirManager(manager);
                return true;
            }
            return false;
        }

        public bool AlterarManager(int id)
        {
            IO io = new IO();
            Managers managers = new Managers();

            int nif, contacto, i;
            string nome, pass;

            if (managers.ExisteManager(id) == true)
            {
                io.AlterarDadosM(out i, out nome, out contacto, out nif, out pass);
                managers.AlterarManager(id, i, nome, contacto, nif, pass);
                return true;
            }
            return false;
        }

        public bool RetirarManager(int id)
        {
            Managers managers = new Managers();

            if (managers.ExisteManager(id) == true)
            {
                managers.RetirarManager(id);
                return true;
            }
            return false;
        }

        public bool GuardarManager(Managers managers, string m)
        {
            managers.GuardarManager(m);
            return true;
        }

        public Managers LerManager(Managers managers, string m)
        {
            managers.LerManager(m);
            return managers;
        }

        #endregion

    }
}

