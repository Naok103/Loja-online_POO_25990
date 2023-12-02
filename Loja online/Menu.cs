using System;
using Regras;
using System.Security.Policy;
using Dados;


namespace Loja_online
{
    /// <summary>
    /// Purpose:
    /// Created by: Rafael silva
    /// Created on: 02/12/2023 14:59:10
    /// </summary>
    internal class Menu
    {
        public void MenuPrincipal() 
        {
            int op;
            Console.WriteLine("Escolha uma opcao:");
            Console.WriteLine("0- Sair \n 1- Produto \n 2- Marca \n 3- Cliente \n 4- Venda \n 5- Stock \n 6- Campanha");
            op = int.Parse(Console.ReadLine());
            switch (op)
            {
                case 1:
                    MenuProduto();
                    break;
                case 2:
                    MenuMarca();
                    break;
                case 3:
                    MenuCliente();
                    break;
                case 4:
                    MenuVenda();
                    break;
                case 5:
                    MenuStock();
                    break; 
                case 6:
                    MenuCampanha();
                    break;
                case 0:
                    break;    
            }
        }

        public void MenuMarca()
        {
            IO io = new IO();
            Marcas marcas = new Marcas();
            RegrasNegocio regras = new RegrasNegocio();
            marcas = regras.LerMarcas(marcas, @"dadosmarcas");
            int op;
            int id;
            do
            {
                Console.WriteLine("Escolha uma opcao:");
                Console.WriteLine("0- Menu Principal\n1- Inserir Marca\n2- Alterar Marca\n3- Retirar Marca\n4- Mostrar marcas\n5- Guardar Marcas");
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        regras.InserirMarca();
                        break;
                    case 2:
                        Console.WriteLine("Qual o id da Marca que deseja alterar?");
                        id = int.Parse(Console.ReadLine());
                        regras.AlterarMarca(id);
                        break;
                    case 3:
                        Console.WriteLine("Qual o id da Marca que deseja alterar?");
                        id = int.Parse(Console.ReadLine());
                        regras.RetirarMarca(id);
                        break;
                    case 4:
                        io.MostrarMarcas(marcas);
                        break;
                    case 5:
                        regras.GravarMarcas(marcas, @"dadosmarcas");
                        break;
                }
            } while (op != 0);
            regras.GravarMarcas(marcas, @"dadosmarcas");
            MenuPrincipal();
        }

        public void MenuProduto()
        {

        }

        public void MenuCliente()
        {

        }

        public void MenuVenda() 
        {

        }

        public void MenuStock()
        {

        }

        public void MenuCampanha()
        {

        }
    }
}

