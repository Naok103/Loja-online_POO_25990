using System;

using objetos;
using Objetos;
using Dados;

namespace Loja_online
{
    /// <summary>
    /// Purpose: classe com funcoes que interagem com a consola
    /// Created by: Rafael silva
    /// Created on: 14/11/2023 21:57:46
    /// </summary>
    public class IO
    {
        #region CLIENTE

        /// <summary>
        /// Funcao para mostrar os clientes na consola
        /// </summary>
        /// <param name="clientes">variavel para a lista de clientes</param>
        public void MostrarClientes(Clientes clientes) 
        {
            foreach (Cliente cliente in clientes)
            {
                Console.WriteLine("Nome: {0}, Id: {1}, Contacto: {2}, Nif: {3}, Morada: {4}", cliente.Nome, cliente.Id, cliente.Contacto, cliente.Nif, cliente.Morada);
            }
        }

        /// <summary>
        /// Funcao para mostrar um cliente especifico na consola
        /// </summary>
        /// <param name="clientes">variavel para a lista de clientes</param>
        /// <param name="id">variavel para o id do cliente</param>
        public void MostrarCliente(Clientes clientes, int id)
        {
            foreach (Cliente cliente in clientes)
            {
                if(cliente.Id == id)
                {
                    Console.WriteLine("Nome: {0}, Id: {1}, Contacto: {2}, Nif: {3}, Morada: {4}", cliente.Nome, cliente.Id, cliente.Contacto, cliente.Nif, cliente.Morada);
                }
            }
        }

        /// <summary>
        /// Funcao para pedir ao utilizador as variaveis de um cliente
        /// </summary>
        /// <param name="nome">variavel para o nome do cliente</param>
        /// <param name="contacto">variavel para o contacto do cliente</param>
        /// <param name="nif">variavel para o nif do cliente</param>
        /// <param name="morada">variavel para a morada do cliente</param>
        public void DadosClientes(out string nome, out int contacto, out int nif, out string morada)
        {
            Console.WriteLine("Qual o nome do cliente?");
            nome = Console.ReadLine();
            Console.WriteLine("Qual o contacto do cliente?");
            contacto = int.Parse(Console.ReadLine());
            Console.WriteLine("Qual o nif do cliente?");
            nif = int.Parse(Console.ReadLine());
            Console.WriteLine("Qual a morada do cliente?");
            morada = Console.ReadLine();
        }


        /// /// <summary>
        /// Funcao para pedir ao utilizador quais as variaveis que quer alterar de um cliente
        /// </summary>
        /// <param name="array">variavel array que determina que propriedade do cliente deve ser alterada</param>
        /// <param name="nome">variavel para o nome do cliente</param>
        /// <param name="contacto">variavel para o contacto do cliente</param>
        /// <param name="nif">variavel para o nif do cliente</param>
        /// <param name="morada">variavel para a morada do cliente</param>
        public void AlterarDadosC(out int[] array, out string nome, out int contacto, out int nif, out string morada)
        {
            nome = "";
            nif = 0;
            contacto = 0;
            morada = "";
            array = new int[4];
            int a, d = 0;
            do
            {
                Console.WriteLine("Que dados deseja alterar (0 - sair, 1 - nome, 2 - contacto, 3 - nif, 4 - morada)?");
                a = int.Parse(Console.ReadLine());
                for (d = d; d < array.Length; d++)
                {
                    if (a == 1)
                    {
                        Console.WriteLine("Qual o novo nome do cliente?");
                        nome = Console.ReadLine();
                        array[d] = a;
                        d++;
                        break;
                    }
                    else if (a == 2)
                    {
                        Console.WriteLine("Qual o novo contacto do cliente?");
                        contacto = int.Parse(Console.ReadLine());
                        array[d] = a;
                        d++;
                        break;
                    }
                    else if (a == 3)
                    {
                        Console.WriteLine("Qual o novo nif do cliente?");
                        nif = int.Parse(Console.ReadLine());
                        array[d] = a;
                        d++;
                        break;
                    }
                    else if (a == 4)
                    {
                        Console.WriteLine("Qual a nova morada do cliente?");
                        morada = Console.ReadLine();
                        array[d] = a;
                        d++;
                        break;
                    }
                    else if (a != 0)
                    {
                        Console.WriteLine("Escolha um numero correto");
                        break;
                    }
                }
            } while (a != 0);
        }

        #endregion

        #region PRODUTO

        /// <summary>
        /// Funcao para mostrar os produtos na consola
        /// </summary>
        /// <param name="p">variavel para a lista de produtos</param>
        public void MostrarProdutos(Produtos p)
        {
            p.Ordenar();
            foreach(Produto produto in p)
            {
                Console.WriteLine("Id Produto: {0}, Nome: {1}, Categoria: {2}, Preco: {3}, Garantia: {4}, Id Marca: {5}", produto.Id, produto.Nome, produto.Categoria, produto.Preco, produto.Garantia, produto.IdM);
            }
        }

        /// <summary>
        /// Funcao para mostrar os produtos de uma marca especifica na consola
        /// </summary>
        /// <param name="p">variavel para a lista de produtos</param>
        /// <param name="id">variavel para o id da marca</param>
        public void MostrarProdutosMarca(Produtos p, int id)
        {
            p.Ordenar();
            foreach (Produto produto in p)
            {
                if(produto.IdM == id)
                {
                    Console.WriteLine("Id Produto: {0}, Nome: {1}, Categoria: {2}, Preco: {3}, Garantia: {4}, Id Marca: {5}", produto.Id, produto.Nome, produto.Categoria, produto.Preco, produto.Garantia, produto.IdM);
                }
            }
        }

        /// <summary>
        /// Funcao para pedir ao utilizador as variaveis de um produto
        /// </summary>
        /// <param name="nome">variavel para o nome do produto</param>
        /// <param name="categoria">variavel para a categoria do produto</param>
        /// <param name="preco">variavel para o preco do produto</param>
        /// <param name="garantia">variavel para a garantia do produto</param>
        public void DadosProdutos(out string nome, out string categoria, out double preco, out int garantia)
        {
            Console.WriteLine("Qual o nome do produto?");
            nome = Console.ReadLine();
            Console.WriteLine("Qual a categoria a qual o produto pertence?");
            categoria = Console.ReadLine();
            Console.WriteLine("Qual o preco do produto?");
            preco = double.Parse(Console.ReadLine());
            Console.WriteLine("Qual a garantia do produto em semanas?");
            garantia = int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Funcao para pedir ao utilizador as variaveis de uma troca
        /// </summary>
        /// <param name="id">variavel para o id do novo produto</param>
        /// <param name="idp">variavel para o id do produto a ser trocado</param>
        /// <param name="idv">variavel para o id da venda</param>
        /// <param name="quantidade">variavel para a quantidade do novo produto</param>
        public void Troca(out int id,out int idv, out int idp, out int quantidade)
        {
            Console.WriteLine("Qual o id do produto que deseja trocar?");
            idp = int.Parse(Console.ReadLine());
            Console.WriteLine("Qual o id do produto novo?");
            id = int.Parse(Console.ReadLine());
            Console.WriteLine("Qual o id da venda?");
            idv = int.Parse(Console.ReadLine());
            Console.WriteLine("Qual a quantidade do novo produto?");
            quantidade = int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Funcao para pedir ao utilizador quias as variaveis que quer alterar de um produto
        /// </summary>
        /// <param name="nome">variavel para o nome do produto</param>
        /// <param name="categoria">variavel para a categoria do produto</param>
        /// <param name="preco">variavel para o preco do produto</param>
        /// <param name="garantia">variavel para a garantia do produto</param>
        /// <param name="array">variavel array que determina que propriedade do produto deve ser alterada</param>
        public void AlterarDadosP(out string nome, out string categoria, out double preco, out int garantia, out int[] array)
        {
            categoria = "";
            nome = "";
            preco = 0.00;
            garantia= 0;
            array = new int[4];
            int a, i = 0;
            do
            {
                Console.WriteLine("Que dados deseja alterar (0 - sair, 1 - nome, 2 - categoria, 3 - preco, 4 - garantia)?");
                a = int.Parse(Console.ReadLine());
                for (i = i; i < array.Length; i++)
                {
                    if (a == 1)
                    {
                        Console.WriteLine("Qual o novo nome do produto?");
                        nome = Console.ReadLine();
                        array[i] = a;
                        i++;
                        break;
                    }
                    else if (a == 2)
                    {
                        Console.WriteLine("Qual a nova categoria do produto?");
                        categoria = Console.ReadLine();
                        array[i] = a;
                        i++;
                        break;
                    }
                    else if (a == 3)
                    {
                        Console.WriteLine("Qual o novo preco do produto?");
                        preco = double.Parse(Console.ReadLine());
                        array[i] = a;
                        i++;
                        break;
                    }
                    else if (a == 4)
                    {
                        Console.WriteLine("Qual a nova garantia do produto?");
                        garantia = int.Parse(Console.ReadLine());
                        array[i] = a;
                        i++;
                        break;
                    }
                    else if (a != 0)
                    {
                        Console.WriteLine("Escolha um numero correto");
                        break;
                    }
                } 
            } while (a != 0);
        }


        #endregion

        #region MARCA

        /// <summary>
        /// Funcao para mostrar as marcas na consola
        /// </summary>
        /// <param name="m">variavel para lista das marcas</param>
        public void MostrarMarcas(Marcas m)
        {
            foreach (Marca marca in m)
            {
                Console.WriteLine("Id: {0}, Nome: {1}, Site: {2}", marca.Id, marca.Nome, marca.Site);
            }
        }

        /// <summary>
        /// Funcao para pedir ao utilizador as variaveis de uma marca
        /// </summary>
        /// <param name="nome">variavel para o nome da marca</param>
        /// <param name="site">variavel para o site da marca</param>
        public void DadosMarca(out string nome, out string site)
        {
            Console.WriteLine("Qual o nome da marca?");
            nome = Console.ReadLine();
            Console.WriteLine("Qual o site da marca?");
            site = Console.ReadLine();
        }

        /// <summary>
        /// Funcao para pedir ao utilizador quias as variaveis que quer alterar de uma marca
        /// </summary>
        /// <param name="nome">variavel para o nome da marca</param>
        /// <param name="site">variavel para o site da marca</param>
        /// <param name="array">variavel array que determina que propriedade da marca deve ser alterada</param>
        public void AlterarDadosM(out string nome, out string site, out int[] array)
        {
            site = "";
            nome = "";
            array = new int[2];
            int a, i = 0;
            do
            {
                Console.WriteLine("Que dados deseja alterar (0 - sair, 1 - nome, 2 - site )?");
                a = int.Parse(Console.ReadLine());
                for (i = i; i < array.Length; i++)
                {
                    if (a == 1)
                    {
                        Console.WriteLine("Qual o novo nome da marca?");
                        nome = Console.ReadLine();
                        i = a;
                        i++;
                        break;
                    }
                    else if (a == 2)
                    {
                        Console.WriteLine("Qual o novo site da marca?");
                        site = Console.ReadLine();
                        i = a;
                        i++;
                        break;
                    }
                    else if (a != 0)
                    {
                        Console.WriteLine("Escolha um numero correto");
                    }
                }
                
            } while (a != 0); 
        }

        #endregion

        #region VENDA

        /// <summary>
        /// Funcao para mostrar as vendas na consola
        /// </summary>
        /// <param name="v">variavel para a lista das vendas</param>
        public void MostrarVendas(Vendas v)
        {
            foreach(Venda venda in v)
            {
                foreach(var p in venda.Produtos)
                {
                    Console.WriteLine("Id Venda: {0}, Quantidade: {1}, Id Cliente: {2}, Id Produto: {3}, Hora: {4}, Preco: {5}", venda.ID, p.Value, venda.IDC, p.Key, venda.Hora, venda.Preco);
                }
            }
        }

        /// <summary>
        /// Funcao para mostrar as vendas de um cliente especifico na consola
        /// </summary>
        /// <param name="v">variavel para a lista das vendas</param>
        /// <param name="id">variavel para o id do cliente</param>
        public void MostrarVendasCliente(Vendas v, int id) 
        {
            foreach (Venda venda in v)
            {
                if(venda.IDC == id)
                {
                    foreach(var p in venda.Produtos)
                    {
                        Console.WriteLine("Id Venda: {0}, Quantidade: {1}, Id Cliente: {2}, Id Produto: {3}, Hora: {4}, Preco: {5}", venda.ID, p.Value, venda.IDC, p.Key, venda.Hora, venda.Preco);
                    } 
                }
            }
        }

        /// <summary>
        /// Funcao para pedir ao utilizador as variaveis de uma venda
        /// </summary>
        /// <param name="q"> variavel array para a quantidade vendida de cada produto</param>
        /// <param name="id">variavel array para os ids dos produtos vendidos</param>
        /// <param name="idc">variavel para o id do cliente que comprou o produto</param>
        public void DadosVendas(out int[] q, out int[] id, out int idc)
        {
            int y;

            Console.WriteLine("Qual o id do cliente?");
            idc = int.Parse(Console.ReadLine());
            Console.WriteLine("Quantos produtos vao ser vendidos?");
            y = int.Parse(Console.ReadLine());

            q = new int[y ];
            id = new int[y ];

            for (int i = 0;i < y ; i++)
            {
                Console.WriteLine("Qual o id do produto?");
                id[i] = int.Parse(Console.ReadLine());
                Console.WriteLine("Qual a quantidade?");
                q[i] = int.Parse(Console.ReadLine());  
            } 
        }

        #endregion

        #region STOCK

        /// <summary>
        /// Funcao para mostrar o stock na consola
        /// </summary>
        /// <param name="s">variavel para lista do stock</param>
        public void MostrarStock(Stocks s)
        {
            foreach (Stock stock in s)
            {
                Console.WriteLine("Id stock: {0}, Quantidade: {1}, Id Produto: {2}", stock.ID, stock.Quantidade, stock.IDP);
            }
        }

        /// <summary>
        /// Funcao para mostrar o stock de um produto especifico na consola
        /// </summary>
        /// <param name="s">variavel para lista do stock</param>
        /// <param name="id">variavel para o id do produto</param>
        public void MostrarStockProduto(Stocks s, int id) 
        {
            foreach (Stock stock in s)
            {
                if(stock.IDP == id)
                {
                    Console.WriteLine("Id stock: {0}, Quantidade: {1}, Id Produto: {2}", stock.ID, stock.Quantidade, stock.IDP);
                }
            }
        }

        /// <summary>
        /// Funcao para pedir ao utilizador as variaveis de um stock
        /// </summary>
        /// <param name="idP">variavel para o id do produto</param>
        /// <param name="quantidade">variavel para a quantidade do produto</param>
        public void DadosStock(out int idP, out int quantidade)
        {
            Console.WriteLine("Qual o id do Produto?");
            idP = int.Parse(Console.ReadLine());
            Console.WriteLine("Qual a quantidade do Produto?");
            quantidade = int.Parse(Console.ReadLine());
        }

        #endregion

        #region CAMPANHA

        /// <summary>
        /// Funcao para mostrar as campanhas na consola
        /// </summary>
        /// <param name="campanhas">variavel para a lista de campanhas</param>
        public void MostrarCampanha(Campanhas campanhas) 
        {
            foreach(Campanha campanha in campanhas)
            {
                Console.WriteLine("Campanha: {0}, Duracao: {1}, Desconto: {2}", campanha.Nome, campanha.Duracao, campanha.Desconto);
            }
        }

        /// <summary>
        /// Funcao para mostrar os produtos de um campanha especifica na consola
        /// </summary>
        /// <param name="nome">variavel para o nome da campanha</param>
        /// <param name="campanhas">variavel para a lista de campanhas</param>
        public void MostrarProdutoCampanha(string nome, Campanhas campanhas)
        {
            foreach (Campanha campanha in campanhas)
            {
                if(campanha.Nome == nome)
                {
                    foreach (Produto produto in campanha.IDP)
                    {
                        Console.WriteLine("Campanha: {0}, ID do Produto: {1} ", campanha.Nome, produto.Id);
                    }
                }
            }
        }

        /// <summary>
        /// Funcao para pedir ao utilizador as variaveis de uma campanha
        /// </summary>
        /// <param name="nome">variavel para o nome da campanha</param>
        /// <param name="duracao">variavel para a duracao da campanha</param>
        /// <param name="desconto">variavel para o desconto no produto durante a campanha</param>
        public void DadosCampanha(out string nome, out int desconto, out int duracao)
        {
            Console.WriteLine("Qual o nome da campanha?");
            nome = Console.ReadLine();
            Console.WriteLine("Qual o desconto praticado na campanha?");
            desconto = int.Parse(Console.ReadLine());
            Console.WriteLine("Qual a duracao da campanha em semanas?");
            duracao = int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Funcao para pedir ao utilizador quais as variaveis que quer alterar numa campanha
        /// </summary>
        /// <param name="array">variavel que determina que propriedade da campanha deve ser alterada</param>
        /// <param name="nome">variavel para o nome da campanha</param>
        /// <param name="duracao">variavel para a duracao da campanha</param>
        /// <param name="desconto">variavel para o desconto no produto durante a campanha</param>
        public void AlterarDadosCA(out int[] array, out string nome, out int desconto, out int duracao)
        {
            nome = "";
            desconto = 0;
            duracao = 0;
            array = new int[3];
            int b, t = 0;

            do
            {
                Console.WriteLine("Que dados deseja alterar (0 - sair, 1 - nome, 2 - duracao, 3 -desconto )?");
                b = int.Parse(Console.ReadLine());

                for (t = t; t < array.Length; t++)
                {
                    if (b == 1)
                    {
                        Console.WriteLine("Qual o novo nome da marca?");
                        nome = Console.ReadLine();
                        t = b;
                        t++;
                        break;
                    }
                    else if (b == 2)
                    {
                        Console.WriteLine("Qual a nova duracao da Campanha?");
                        duracao = int.Parse(Console.ReadLine());
                        t = b;
                        t++;
                        break;
                    }
                    else if (b == 3)
                    {
                        Console.WriteLine("Qual o novo desconto da Campanha?");
                        desconto = int.Parse(Console.ReadLine());
                        t = b;
                        t++;
                        break;
                    }
                    else if (b != 0)
                    {
                        Console.WriteLine("Escolha um numero correto");
                    }
                }
            } while (b != 0);
            
        }

        #endregion

        #region FUNCIONARIO

        /// <summary>
        /// funcao para mostar na consola todos os funcionarios
        /// </summary>
        /// <param name="funcionarios">variavel para a lista de funcionarios</param>
        public void MostrarFuncionarios(Funcionarios funcionarios)
        {
            foreach(Funcionario funcionario in funcionarios)
            {
                Console.WriteLine("Nome: {0}, Id: {1}, Contacto: {2}, Nif: {3}", funcionario.Nome, funcionario.Id, funcionario.Contacto, funcionario.Nif);
            }
        }

        /// <summary>
        /// Funcao para pedir ao utilizador as variaveis de um funcionario
        /// </summary>
        /// <param name="nome">variavel para o nome do funcionario</param>
        /// <param name="nif">variavel para o nif do funcionario</param>
        /// <param name="contacto">variavel para o contacto do funcionario</param>
        public void DadosFuncionario(out string nome, out int nif, out int contacto)
        {
            Console.WriteLine("Qual o nome do funcionario?");
            nome = Console.ReadLine();
            Console.WriteLine("Qual o nif do funcionario?");
            nif = int.Parse(Console.ReadLine());
            Console.WriteLine("Qual o contacto do funcionario?");
            contacto = int.Parse(Console.ReadLine());
        }

        /// <summary>
        ///  Funcao para pedir ao utilizador quais as variaveis que quer alterar num funcionario
        /// </summary>
        /// <param name="array">variavel array que determina que propriedade do funcionario deve ser alterada</param>
        /// <param name="nome">variavel para o nome do funcionario</param>
        /// <param name="contacto">variavel para o contacto do funcionario</param>
        /// <param name="nif">variavel para o nif do funcionario</param>
        public void AlterarDadosF(out int[] array, out string nome, out int contacto, out int nif)
        {
            nome = "";
            nif = 0;
            contacto = 0;
            array = new int[3];
            int a, d = 0;
            do
            {
                Console.WriteLine("Que dados deseja alterar (0 - sair, 1 - nome, 2 - contacto, 3 - nif)?");
                a = int.Parse(Console.ReadLine());
                for (d = d; d < array.Length; d++)
                {
                    if (a == 1)
                    {
                        Console.WriteLine("Qual o novo nome do funcionario?");
                        nome = Console.ReadLine();
                        d = a;
                        d++;
                        break;
                    }
                    else if (a == 2)
                    {
                        Console.WriteLine("Qual o novo contacto do funcionario?");
                        contacto = int.Parse(Console.ReadLine());
                        d = a;
                        d++;
                        break;
                    }
                    else if (a == 3)
                    {
                        Console.WriteLine("Qual o novo nif do funcionario?");
                        nif = int.Parse(Console.ReadLine());
                        d = a;
                        d++;
                        break;
                    }
                    else if (a != 0)
                    {
                        Console.WriteLine("Escolha um numero correto");
                    }
                }

            } while (a != 0);
        }

        #endregion

        #region MANAGER

        /// <summary>
        /// funcao para mostrar os managers na consola
        /// </summary>
        /// <param name="managers">variavel para a lista de managers</param>
        public void MostrarManagers(Managers managers)
        {
            foreach (Manager manager in managers)
            {
                Console.WriteLine("Nome: {0}, Id: {1}, Contacto: {2}, Nif: {3}", manager.Nome, manager.Id, manager.Contacto, manager.Nif);
            }
        }

        /// <summary>
        /// Funcao para pedir ao utilizador as variaveis de um manager
        /// </summary>
        /// <param name="nome">variavel para o nome do manager</param>
        /// <param name="nif">variavel para o nif do manager</param>
        /// <param name="contacto">variavel para o contacto do manager</param>
        /// <param name="pass">variavel para a pass do manager</param>
        public void DadosManager(out string nome, out int nif, out int contacto, out string pass)
        {
            Console.WriteLine("Qual o nome do manager?");
            nome = Console.ReadLine();
            Console.WriteLine("Qual o nif do manager?");
            nif = int.Parse(Console.ReadLine());
            Console.WriteLine("Qual o contacto do manager?");
            contacto = int.Parse(Console.ReadLine());
            Console.WriteLine("Qual a pass do manager?");
            pass = Console.ReadLine();
        }

        /// <summary>
        /// Funcao para pedir ao utilizador quais as variaveis que quer alterar num manager
        /// </summary>
        /// <param name="array">variavel array que determina que propriedade do manager deve ser alterada</param>
        /// <param name="nome">variavel para o nome do manager</param>
        /// <param name="contacto">variavel para o contacto do manager</param>
        /// <param name="nif">variavel para o nif do manager</param>
        /// <param name="pass">variavel para a pass do manager</param>
        public void AlterarDadosM(out int[] array, out string nome, out int contacto, out int nif, out string pass)
        {
            nome = "";
            nif = 0;
            contacto = 0;
            pass = "";
            array = new int[4];
            int a, d = 0;
            do
            {
                Console.WriteLine("Que dados deseja alterar (0 - sair, 1 - nome, 2 - contacto, 3 - nif, 4 - pass)?");
                a = int.Parse(Console.ReadLine());
                for(d=d;d< array.Length; d++)
                {
                    if (a == 1)
                    {
                        Console.WriteLine("Qual o novo nome do Manager?");
                        nome = Console.ReadLine();
                        d = a;
                        d++;
                        break;
                    }
                    else if (a == 2)
                    {
                        Console.WriteLine("Qual o novo contacto do Manager?");
                        contacto = int.Parse(Console.ReadLine());
                        d = a;
                        d++;
                        break;
                    }
                    else if (a == 3)
                    {
                        Console.WriteLine("Qual o novo nif do Manager?");
                        nif = int.Parse(Console.ReadLine());
                        d = a;
                        d++;
                        break;
                    }
                    else if (a == 4)
                    {
                        Console.WriteLine("Qual a nova pass do Manager?");
                        pass = Console.ReadLine();
                        d = a;
                        d++;
                        break;
                    }
                    else if (a != 0)
                    {
                        Console.WriteLine("Escolha um numero correto");
                    }
                }
                
            } while (a != 0);
        }

        #endregion

        #region FORNECEDOR

        /// <summary>
        /// Funcao para mostrar os fornecedor na consola
        /// </summary>
        /// <param name="fornecedores">variavel para a lista de fornecedores</param>
        public void MostrarFornecedores(Fornecedores fornecedores)
        {
            foreach (Fornecedor fornecedor in fornecedores)
            {
                Console.WriteLine("Nome: {0}, Id: {1}, Contacto: {2}, Nif: {3}, Morada: {4}, Email: {5}", fornecedor.Nome, fornecedor.Id, fornecedor.Contacto, fornecedor.Nif, fornecedor.Morada, fornecedor.Email);
            }
        }

        /// <summary>
        /// Funcao para mostrar um fornecedor especifico na consola
        /// </summary>
        /// <param name="fornecedores">variavel para a lista de fornecedores</param>
        /// <param name="id">variavel para o id do fornecedor</param>
        public void MostrarFornecedor(Fornecedores fornecedores, int id)
        {
            foreach (Fornecedor fornecedor in fornecedores)
            {
                if (fornecedor.Id == id)
                {
                    Console.WriteLine("Nome: {0}, Id: {1}, Contacto: {2}, Nif: {3}, Morada: {4}, Email: {5}", fornecedor.Nome, fornecedor.Id, fornecedor.Contacto, fornecedor.Nif, fornecedor.Morada, fornecedor.Email);
                }
            }
        }

        /// <summary>
        /// Funcao para pedir ao utilizador as variaveis de um fornecedor
        /// </summary>
        /// <param name="nome">variavel para o nome do fornecedor</param>
        /// <param name="contacto">variavel para o contacto do fornecedor</param>
        /// <param name="nif">variavel para o nif do fornecedor</param>
        /// <param name="morada">variavel para a morada do fornecedor</param>
        public void DadosFornecedores(out string nome, out int contacto, out int nif, out string morada, out string email)
        {
            Console.WriteLine("Qual o nome do fornecedor?");
            nome = Console.ReadLine();
            Console.WriteLine("Qual o contacto do fornecedor?");
            contacto = int.Parse(Console.ReadLine());
            Console.WriteLine("Qual o nif do fornecedor?");
            nif = int.Parse(Console.ReadLine());
            Console.WriteLine("Qual a morada do fornecedor?");
            morada = Console.ReadLine();
            Console.WriteLine("Qual o email do fornecedor?");
            email = Console.ReadLine();
        }


        /// /// <summary>
        /// Funcao para pedir ao utilizador quais as variaveis que quer alterar de um fornecedor
        /// </summary>
        /// <param name="array">variavel array que determina que propriedade do fornecedor deve ser alterada</param>
        /// <param name="nome">variavel para o nome do fornecedor</param>
        /// <param name="contacto">variavel para o contacto do fornecedor</param>
        /// <param name="nif">variavel para o nif do fornecedor</param>
        /// <param name="morada">variavel para a morada do fornecedor</param>
        public void AlterarDadosFO(out int[] array, out string nome, out int contacto, out int nif, out string morada, out string email)
        {
            nome = "";
            nif = 0;
            contacto = 0;
            morada = "";
            email = "";
            array = new int[4];
            int a, d = 0;
            do
            {
                Console.WriteLine("Que dados deseja alterar (0 - sair, 1 - nome, 2 - contacto, 3 - nif, 4 - morada, 5 - email)?");
                a = int.Parse(Console.ReadLine());
                for (d = d; d < array.Length; d++)
                {
                    if (a == 1)
                    {
                        Console.WriteLine("Qual o novo nome do fornecedor?");
                        nome = Console.ReadLine();
                        array[d] = a;
                        d++;
                        break;
                    }
                    else if (a == 2)
                    {
                        Console.WriteLine("Qual o novo contacto do fornecedor?");
                        contacto = int.Parse(Console.ReadLine());
                        array[d] = a;
                        d++;
                        break;
                    }
                    else if (a == 3)
                    {
                        Console.WriteLine("Qual o novo nif do fornecedor?");
                        nif = int.Parse(Console.ReadLine());
                        array[d] = a;
                        d++;
                        break;
                    }
                    else if (a == 4)
                    {
                        Console.WriteLine("Qual a nova morada do fornecedor?");
                        morada = Console.ReadLine();
                        array[d] = a;
                        d++;
                        break;
                    }
                    else if (a == 5)
                    {
                        Console.WriteLine("Qual o novo email do fornecedor?");
                        email = Console.ReadLine();
                        array[d] = a;
                        d++;
                        break;
                    }
                    else if (a != 0)
                    {
                        Console.WriteLine("Escolha um numero correto");
                        break;
                    }
                }
            } while (a != 0);
        }

        #endregion
    }
}

