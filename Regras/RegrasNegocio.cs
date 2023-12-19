using System;
using System.Net.Security;
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

        public bool InserirCliente(Clientes clientes)
        {
            IO io = new IO();
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

        public bool AlterarCliente(int id, Clientes clientes)
        {
            IO io = new IO();
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

        public bool RetirarCliente(int id, Clientes clientes)
        {
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

        public bool InserirProduto(Marcas marcas, Produtos produtos, int idm)
        {
            IO io = new IO();
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

        public bool AlterarProduto(int id, Produtos produtos)
        {
            IO io = new IO();
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

        public bool RetirarProduto(int id, Produtos produtos)
        {

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

        public bool InserirMarca(Marcas marcas)
        {
            IO io = new IO();
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

        public bool AlterarMarca(int id, Marcas marcas)
        {
            IO io = new IO();
            string nome, site;
            int i;
            if(marcas.ExisteMarca(id) == true)
            {
                io.AlterarDadosM(out nome, out site, out i);
                marcas.AlterarMarca(id, i, nome, site);
                return true;
            }
            return false;
        }

        public bool RetirarMarca(int id, Marcas marcas)
        {
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

        /*
        public bool RealizarVenda(Vendas vendas, Produtos produtos, Clientes clientes)
        {
            IO io = new IO();

            int quantidade, idc, idp;
            DateTime hora;

            io.DadosVendas(out quantidade, out idc, out idp);

            if (produtos.ExisteProduto(idp) == true && clientes.ExisteCliente(idp) == true)
            {
                hora = DateTime.Now;
                Venda venda = new Venda(quantidade, idp, idc, hora);
                vendas.AdicionarVenda(venda);
                return true;
            }
            return false;
        }
        */

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

        public bool InserirStock(Stocks stocks, Produtos produtos)
        {
            IO io = new IO();
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

        public bool AdicionarStock(Stocks stocks, Produtos produtos)
        {
            IO io = new IO();
            int id, quantidade;


            io.DadosStock(out id, out quantidade);
            if(produtos.ExisteProduto(id) == true)
            {
                stocks.AdicionarStock(id, quantidade);
                return true;
            }

            return false;
        }

        public bool RetirarStock(Stocks stocks, Produtos produtos)
        {
            IO io = new IO();
            int id, quantidade;


            io.DadosStock(out id, out quantidade);
            if(produtos.ExisteProduto(id) == true)
            {
                stocks.RetirarStock(id, quantidade);
            }
            
            return true;
        }

        public bool AcabarStock(Stocks stocks, int id)
        {
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

        
        public bool InserirCampanha(Campanhas campanhas)
        {
            IO io = new IO();
            string nome;
            int desconto, duracao;

            io.DadosCampanha(out nome, out desconto, out duracao);

            if(campanhas.ExisteCampanha(nome) == false)
            {
                Campanha campanha = new Campanha(nome, duracao, desconto);
                campanhas.InseirCampanha(campanha);
                return true;
            }
            return false;
        }
        

        public bool AdicionarProdutoCampanha(int id, string nome, Produtos produtos, Campanhas campanhas)
        {
            if((campanhas.ExisteCampanha(nome)) == true && (produtos.ExisteProduto(id) == true))
            {
                campanhas.AdicionarProdutoCampanha(nome, id, produtos);
                return true;
            }
            return false;
        }

        public bool RetirarProdutoCampanha(int id, string nome, Produtos produtos, Campanhas campanhas)
        {
            if ((campanhas.ExisteCampanha(nome)) == true && (produtos.ExisteProduto(id) == true))
            {
                if(campanhas.ExisteProdutoCampanha(id,nome) == true)
                {
                    campanhas.RetirarProdutoCampanha(nome, id);
                    return true;
                }
            }
            return false;
        }

        public bool AlterarCampanha(string n, Campanhas campanhas)
        {
            IO io = new IO();
            string nome;
            int desconto, duracao, t;

            if(campanhas.ExisteCampanha(n) == true)
            {
                io.AlterarDadosCA(out t, out nome, out desconto, out duracao);
                campanhas.AlterarCampanha(t, nome, duracao, desconto);
                return true;
            }
            return false;
        }

        public bool RetirarCampanha(string nome, Campanhas campanhas)
        {
            if(campanhas.ExisteCampanha(nome) == true)
            {
                campanhas.RetirarCampanha(nome);
                return true;
            }
            return false;
        }

        public bool GravarCampanha(string m, string t, Campanhas campanhas)
        {
            campanhas.GuardarCampanhas(m);
            campanhas.GuardarProdutoCampanha(t);
            return true;
        }

        public Campanhas LerCampanhas(string m, string t, Campanhas campanhas, Produtos produtos)
        {
            campanhas.LerCampanhas(m);
            campanhas.LerProdutoCampanha(t, produtos);
            return campanhas;
        }

        #endregion

        #region FUNCIONARIO

        public bool InserirFuncionario(Funcionarios funcionarios)
        {
            IO io = new IO();

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

        public bool AlterarFuncionario(Funcionarios funcionarios, int id)
        {
            IO io = new IO();

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

        public bool RetirarFuncionario(Funcionarios funcionarios, int id)
        {
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

        public bool InserirManager(Managers managers)
        {
            IO io = new IO();

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

        public bool AlterarManager(Managers managers, int id)
        {
            IO io = new IO();

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

        public bool RetirarManager(Managers managers, int id)
        {

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

