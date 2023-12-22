using System;
using System.Net.Security;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Dados;
using Excecoes;
using Loja_online;
using objetos;
using Objetos;

namespace Regras
{
    /// <summary>
    /// Purpose: classe para deselvolver as funcoes relacionadas com as regras
    /// Created by: Rafael silva
    /// Created on: 01/12/2023 11:16:31
    /// </summary>
    public class RegrasNegocio
    {
        #region CLIENTE

        /// <summary>
        /// funcao com a regra de negocio para adicionar um cliente
        /// </summary>
        /// <param name="clientes">variavel para a lista dos clientes</param>
        /// <returns></returns>
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

        /// <summary>
        /// funcao com a regra de negocio para alterar um cliente
        /// </summary>
        /// <param name="id">variavel para o id do cliente</param>
        /// <param name="clientes">variavel para a lista dos clientes</param>
        /// <returns></returns>
        public bool AlterarCliente(int id, Clientes clientes)
        {
            IO io = new IO();
            int nif, contacto;
            int[] array;
            string nome, morada;
            if (clientes.ExisteCliente(id) == true)
            {
                io.AlterarDadosC(out array, out nome, out contacto, out nif, out morada);
                clientes.AlterarCliente(id, array, nome, contacto, nif, morada);
                return true;
            }
            return false;
        }

        /// <summary>
        /// funcao com a regra de negocio para retirar um cliente
        /// </summary>
        /// <param name="id">variavel para o id do cliente</param>
        /// <param name="clientes">variavel para a lista dos clientes</param>
        /// <returns></returns>
        public bool RetirarCliente(int id, Clientes clientes)
        {
            if(clientes.ExisteCliente(id) == true)
            {
                clientes.RetirarCliente(id); 
                return true;
            }
            return false;
        }

        /// <summary>
        /// funcao com a regra de negocio para guardar os clientes
        /// </summary>
        /// <param name="clientes">variavel para a lista dos clientes</param>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool GuardarClientes(Clientes clientes, string m)
        {
            clientes.GravarCliente(m);
            return true;
        }

        /// <summary>
        /// funcao com a regra de negocio para ler os clientes
        /// </summary>
        /// <param name="clientes">variavel para a lista dos clientes</param>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public Clientes LerClientes(Clientes clientes, string m)
        {
            clientes.LerCliente(m);
            return clientes;
        }

        #endregion

        #region PRODUTO

        /// <summary>
        /// funcao com a regra de negocio para adicionar um produto
        /// </summary>
        /// <param name="marcas">variavel para a lista das marcas</param>
        /// <param name="produtos">variavel para a lista dos produtos</param>
        /// <param name="idm">variavel para o id da marca</param>
        /// <returns></returns>
        public bool InserirProduto(Marcas marcas, Produtos produtos, int idm)
        {
            IO io = new IO();
            string nome, categoria;
            int preco, id = 0, garantia;

            io.DadosProdutos(out nome, out categoria, out preco, out garantia);
            id = produtos.ID(id);

            if (marcas.ExisteMarca(idm) == true || preco > 850 || garantia < 8)
                return false;
            try
            {
                Produto produto = new Produto(id, nome, categoria, preco, garantia, idm);
                produtos.InserirProduto(produto);
                return true;
            }
            catch(ProdutosE e)
            {
                throw new ProdutosE("Falha nas regras" + "-" + e.Message);
            }
                
            
            
        }

        /// <summary>
        /// funcao com a regra de negocio para alterar um produto
        /// </summary>
        /// <param name="id">variavel para o id do produto</param>
        /// <param name="produtos">variavel para a lista dos produtos</param>
        /// <returns></returns>
        public bool AlterarProduto(int id, Produtos produtos)
        {
            IO io = new IO();
            string nome, categoria;
            int preco,garantia;
            int[] array;

            io.AlterarDadosP(out nome, out categoria, out preco, out garantia, out array);

            if (preco > 850 || garantia < 8)
            {
                return false;
            }
            try
            {
                produtos.AlterarProduto(id, array, nome, categoria, preco, garantia);
                return true;
            }
            catch (ProdutosE e)
            {
                throw new ProdutosE("Falha nas regras" + "-" + e.Message);
            }
        }

        /// <summary>
        /// funcao com a regra de negocio para retirar um produto
        /// </summary>
        /// <param name="id">variavel para o id do produto</param>
        /// <param name="produtos">variavel para a lista dos produtos</param>
        /// <returns></returns>
        public bool RetirarProduto(int id, Produtos produtos)
        {

            if (produtos.ExisteProduto(id) == true)
            {
                produtos.RetirarProduto(id);
                return true;
            }
            return false;
        }

        /// <summary>
        /// funcao com a regra de negocio para gravar os produtos
        /// </summary>
        /// <param name="produtos">variavel para a lista dos produtos</param>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool GravarProduto(Produtos produtos, string m)
        {
            produtos.GuardarProduto(m);
            return true;
        }

        /// <summary>
        /// funcao com a regra de negocio para ler os produtos
        /// </summary>
        /// <param name="produtos">variavel para a lista dos produtos</param>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public Produtos LerProduto(Produtos produtos, string m)
        {
            produtos.LerProduto(m);
            return produtos;
        }

        #endregion

        #region MARCA

        /// <summary>
        /// funcao com a regra de negocio para adicionar uma marca
        /// </summary>
        /// <param name="marcas">variavel para a lista das marcas</param>
        /// <returns></returns>
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

        /// <summary>
        /// funcao com a regra de negocio para alterar uma marca
        /// </summary>
        /// <param name="id">variavel para o id da marca</param>
        /// <param name="marcas">variavel para a lista das marcas</param>
        /// <returns></returns>
        public bool AlterarMarca(int id, Marcas marcas)
        {
            IO io = new IO();
            string nome, site;
            int[] array;
            
            if(marcas.ExisteMarca(id) == true)
            {
                io.AlterarDadosM(out nome, out site, out array);
                marcas.AlterarMarca(id, array, nome, site);
                return true;
            }
            return false;
        }

        /// <summary>
        /// funcao com a regra de negocio para retirar uma marca
        /// </summary>
        /// <param name="id">variavel para o id da marca</param>
        /// <param name="marcas">variavel para a lista das marcas</param>
        /// <returns></returns>
        public bool RetirarMarca(int id, Marcas marcas)
        {
            if (marcas.ExisteMarca(id) == true)
            {
                marcas.RetirarMarca(id);
                return true;
            }
            return false;
        }

        /// <summary>
        /// funcao com a regra de negocio para gravar as marcas
        /// </summary>
        /// <param name="marcas">variavel para a lista das marcas</param>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool GravarMarcas(Marcas marcas, string m)
        {
            marcas.GravarMarcas(m);
            return true;
        }

        /// <summary>
        /// funcao com a regra de negocio para ler as marcas
        /// </summary>
        /// <param name="marcas">variavel para a lista das marcas</param>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public Marcas LerMarcas(Marcas marcas, string m)
        {
            marcas.LerMarcas(m);
            return marcas;
        }

        #endregion

        #region VENDA

        /*
        /// <summary>
        /// funcao com a regra de negocio para adicionar uma venda
        /// </summary>
        /// <param name="vendas">variavel para a lista de vendas</param>
        /// <param name="produtos">variavel para a lista de produtos</param>
        /// <param name="clientes">variavel para a lista de clientes</param>
        /// <returns></returns>
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

        /// <summary>
        /// funcao com a regra de negocio para gravar as vendas
        /// </summary>
        /// <param name="vendas">variavel para a lista de vendas</param>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool GuardarVendas(Vendas vendas, string m)
        {
            vendas.GuardarVenda(m);
            return true;
        }

        /// <summary>
        /// funcao com a regra de negocio para ler as vendas
        /// </summary>
        /// <param name="vendas">variavel para a lista de vendas</param>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public Vendas LerVendas(Vendas vendas, string m)
        {
            vendas.LerVenda(m);
            return vendas;
        }

        #endregion

        #region STOCK

        /// <summary>
        /// funcao com a regra de negocio para adicionar um stock
        /// </summary>
        /// <param name="stocks">variavel para a lista de stock</param>
        /// <param name="produtos">variavel para a lista de produtos</param>
        /// <returns></returns>
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

        /// <summary>
        /// funcao com a regra de negocio para adicionar um produto a um stock
        /// </summary>
        /// <param name="stocks">variavel para a lista de stock</param>
        /// <param name="produtos">variavel para a lista de produtos</param>
        /// <returns></returns>
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

        /// <summary>
        /// funcao com a regra de negocio para retirar um produto a um stock
        /// </summary>
        /// <param name="stocks">variavel para a lista de stock</param>
        /// <param name="produtos">variavel para a lista de produtos</param>
        /// <returns></returns>
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

        /// <summary>
        /// funcao com a regra de negocio para retirar um stock
        /// </summary>
        /// <param name="stocks">variavel para a lista de stock</param>
        /// <param name="id">variavel para o id do stock</param>
        /// <returns></returns>
        public bool AcabarStock(Stocks stocks, int id)
        {
            if (stocks.ExisteStock(id) == true)
            {
                stocks.AcabarStock(id);
                return true;
            }
            return false;
        }

        /// <summary>
        /// funcao com a regra de negocio para gravar o stock
        /// </summary>
        /// <param name="stocks">variavel para a lista de stock</param>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool GravarStocks(Stocks stocks, string m)
        {
            stocks.GravarStock(m);
            return true;
        }

        /// <summary>
        /// funcao com a regra de negocio para ler o stock
        /// </summary>
        /// <param name="stocks">variavel para a lista de stock</param>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public Stocks LerStocks(Stocks stocks, string m)
        {
            stocks.LerStock(m);
            return stocks;
        }

        #endregion

        #region CAMPANHA

        /// <summary>
        /// funcao com a regra de negocio para adicionar uma campanha
        /// </summary>
        /// <param name="campanhas">variavel para a lista de campanhas</param>
        /// <returns></returns>
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

        /// <summary>
        /// funcao com a regra de negocio para adicionar um produto a uma campanha
        /// </summary>
        /// <param name="id">variavel para o id do produto</param>
        /// <param name="nome">variavel para o nome da campanha</param>
        /// <param name="produtos">variavel para a lista de produtos</param>
        /// <param name="campanhas">variavel para a lista de campanhas</param>
        /// <returns></returns>
        public bool AdicionarProdutoCampanha(int id, string nome, Produtos produtos, Campanhas campanhas)
        {
            if((campanhas.ExisteCampanha(nome)) == true && (produtos.ExisteProduto(id) == true))
            {
                campanhas.AdicionarProdutoCampanha(nome, id, produtos);
                return true;
            }
            return false;
        }

        /// <summary>
        /// funcao com a regra de negocio para retirar um produto de uma campanha
        /// </summary>
        /// <param name="id">variavel para o id do produto</param>
        /// <param name="nome">variavel para o nome da campanha</param>
        /// <param name="produtos">variavel para a lista de produtos</param>
        /// <param name="campanhas">variavel para a lista de campanhas</param>
        /// <returns></returns>
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

        /// <summary>
        /// funcao com a regra de negocio para alterar uma campanha
        /// </summary>
        /// <param name="n">variavel para o nome da campanha</param>
        /// <param name="campanhas">variavel para a lista de campanhas</param>
        /// <returns></returns>
        public bool AlterarCampanha(string n, Campanhas campanhas)
        {
            IO io = new IO();
            string nome;
            int desconto, duracao;
            int[] array;

            if(campanhas.ExisteCampanha(n) == true)
            {
                io.AlterarDadosCA(out array, out nome, out desconto, out duracao);
                campanhas.AlterarCampanha(array, nome, duracao, desconto);
                return true;
            }
            return false;
        }

        /// <summary>
        /// funcao com a regra de negocio para retirar uma campanha
        /// </summary>
        /// <param name="nome">variavel para o nome da campanha</param>
        /// <param name="campanhas">variavel para a lista de campanhas</param>
        /// <returns></returns>
        public bool RetirarCampanha(string nome, Campanhas campanhas)
        {
            if(campanhas.ExisteCampanha(nome) == true)
            {
                campanhas.RetirarCampanha(nome);
                return true;
            }
            return false;
        }

        /// <summary>
        /// funcao com a regra de negocio para gravar as campanhas
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <param name="t">variavel para o nome do ficheiro</param>
        /// <param name="campanhas">variavel para a lista de campanhas</param>
        /// <returns></returns>
        public bool GravarCampanha(string m, string t, Campanhas campanhas)
        {
            campanhas.GuardarCampanhas(m);
            campanhas.GuardarProdutoCampanha(t);
            return true;
        }

        /// <summary>
        /// funcao com a regra de negocio para ler as campanhas
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <param name="t">variavel para o nome do ficheiro</param>
        /// <param name="campanhas">variavel para a lista de campanhas</param>
        /// <param name="produtos">variavel para a lista de produtos</param>
        /// <returns></returns>
        public Campanhas LerCampanhas(string m, string t, Campanhas campanhas, Produtos produtos)
        {
            campanhas.LerCampanhas(m);
            campanhas.LerProdutoCampanha(t, produtos);
            return campanhas;
        }

        #endregion

        #region FUNCIONARIO

        /// <summary>
        /// funcao com a regra de negocio para  adicionar um funcionario
        /// </summary>
        /// <param name="funcionarios">variavel para a lista de funcionarios</param>
        /// <returns></returns>
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

        /// <summary>
        /// funcao com a regra de negocio para  alterar um funcionario
        /// </summary>
        /// <param name="funcionarios">variavel para a lista de funcionarios</param>
        /// <param name="id">variavel para o id do funcionario</param>
        /// <returns></returns>
        public bool AlterarFuncionario(Funcionarios funcionarios, int id)
        {
            IO io = new IO();

            int nif, contacto;
            int[] array;
            string nome;

            if (funcionarios.ExisteFuncionario(id) == true)
            {
                io.AlterarDadosF(out array, out nome, out contacto, out nif);
                funcionarios.AlterarFuncionario(id, array, nome, contacto, nif);
                return true;
            }
            return false;
        }

        /// <summary>
        /// funcao com a regra de negocio para  retirar um funcionario
        /// </summary>
        /// <param name="funcionarios">variavel para a lista de funcionarios</param>
        /// <param name="id">variavel para o id do funcionario</param>
        /// <returns></returns>
        public bool RetirarFuncionario(Funcionarios funcionarios, int id)
        {
            if(funcionarios.ExisteFuncionario(id) == true)
            {
                funcionarios.RetirarFuncionario(id);
                return true;
            }
            return false;
        }

        /// <summary>
        /// funcao com a regra de negocio para  gravar funcionarios
        /// </summary>
        /// <param name="funcionarios">variavel para a lista de funcionarios</param>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool GuardarFuncionario(Funcionarios funcionarios, string m)
        {
            funcionarios.GuardarFuncionario(m);
            return true;
        }

        /// <summary>
        /// funcao com a regra de negocio para  ler funcionarios
        /// </summary>
        /// <param name="funcionarios">variavel para a lista de funcionarios</param>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public Funcionarios LerFuncionario(Funcionarios funcionarios, string m)
        {
            funcionarios.LerFuncionario(m);
            return funcionarios;
        }

        #endregion

        #region MANAGER

        /// <summary>
        /// funcao com a regra de negocio para adicionar um manager
        /// </summary>
        /// <param name="managers">variavel para a lista de managers</param>
        /// <returns></returns>
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

        /// <summary>
        /// funcao com a regra de negocio para alterar um manager
        /// </summary>
        /// <param name="managers">variavel para a lista de managers</param>
        /// <param name="id">variavel para o id do manager</param>
        /// <returns></returns>
        public bool AlterarManager(Managers managers, int id)
        {
            IO io = new IO();

            int nif, contacto;
            int[] array;
            string nome, pass;

            if (managers.ExisteManager(id) == true)
            {
                io.AlterarDadosM(out array, out nome, out contacto, out nif, out pass);
                managers.AlterarManager(id, array, nome, contacto, nif, pass);
                return true;
            }
            return false;
        }

        /// <summary>
        /// funcao com a regra de negocio para retirar um manager
        /// </summary>
        /// <param name="managers">variavel para a lista de managers</param>
        /// <param name="id">variavel para o id do manager</param>
        /// <returns></returns>
        public bool RetirarManager(Managers managers, int id)
        {

            if (managers.ExisteManager(id) == true)
            {
                managers.RetirarManager(id);
                return true;
            }
            return false;
        }

        /// <summary>
        /// funcao com a regra de negocio para gravar os managers
        /// </summary>
        /// <param name="managers">variavel para a lista de managers</param>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool GuardarManager(Managers managers, string m)
        {
            managers.GuardarManager(m);
            return true;
        }

        /// <summary>
        /// funcao com a regra de negocio para ler os managers
        /// </summary>
        /// <param name="managers">variavel para a lista de managers</param>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public Managers LerManager(Managers managers, string m)
        {
            managers.LerManager(m);
            return managers;
        }

        #endregion

        #region FORNECEDOR

        /// <summary>
        /// funcao com a regra de negocio para adicionar um fornecedor
        /// </summary>
        /// <param name="fornecedores">variavel para a lista dos fornecedores</param>
        /// <returns></returns>
        public bool InserirFornecedor(Fornecedores fornecedores)
        {
            IO io = new IO();
            int id = 0, nif, contacto;
            string nome, morada, aux1, aux2, email;
            id = fornecedores.ID(id);
            io.DadosFornecedores(out nome, out contacto, out nif, out morada ,out email);
            aux1 = contacto.ToString();
            aux2 = nif.ToString();
            if ((aux1.Length == 9) && (aux2.Length == 9))
            {
                Fornecedor fornecedor = new Fornecedor(id, nome, contacto, nif, morada, email);
                fornecedores.AdicionarFornecedor(fornecedor);
                return true;
            }
            return false;
        }

        /// <summary>
        /// funcao com a regra de negocio para alterar um fornecedor
        /// </summary>
        /// <param name="id">variavel para o id do fornecedor</param>
        /// <param name="fornecedores">variavel para a lista dos fornecedores</param>
        /// <returns></returns>
        public bool AlterarFornecedor(int id, Fornecedores fornecedores)
        {
            IO io = new IO();
            int nif, contacto;
            int[] array;
            string nome, morada, email;
            if (fornecedores.ExisteFornecedor(id) == true)
            {
                io.AlterarDadosFO(out array, out nome, out contacto, out nif, out morada, out email);
                fornecedores.AlterarFornecedor(id, array, nome, contacto, nif, morada, email);
                return true;
            }
            return false;
        }

        /// <summary>
        /// funcao com a regra de negocio para retirar um fornecedor
        /// </summary>
        /// <param name="id">variavel para o id do fornecedor</param>
        /// <param name="fornecedores">variavel para a lista dos fornecedores</param>
        /// <returns></returns>
        public bool RetirarFornecedor(int id, Fornecedores fornecedores)
        {
            if (fornecedores.ExisteFornecedor(id) == true)
            {
                fornecedores.RetirarFornecedor(id);
                return true;
            }
            return false;
        }

        /// <summary>
        /// funcao com a regra de negocio para guardar os fornecedores
        /// </summary>
        /// <param name="fornecedores">variavel para a lista dos fornecedores</param>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool GuardarFornecedores(Fornecedores fornecedores, string m)
        {
            fornecedores.GravarFornecedor(m);
            return true;
        }

        /// <summary>
        /// funcao com a regra de negocio para ler os fornecedores
        /// </summary>
        /// <param name="fornecedores">variavel para a lista dos fornecedores</param>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public Fornecedores LerFornecedores(Fornecedores fornecedores, string m)
        {
            fornecedores.LerFornecedor(m);
            return fornecedores;
        }

        #endregion

    }
}

