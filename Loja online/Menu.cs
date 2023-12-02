using System;
using System.Security.Policy;


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
                    return;
                case 2:
                    MenuMarca();
                    return;
                case 3:
                    MenuCliente();
                    return;
                case 4:
                    MenuVenda();
                    return;
                case 5:
                    MenuStock();
                    return; 
                case 6:
                    MenuCampanha();
                    return;
                case 0:
                    break;    
            }
        }

        public void MenuMarca()
        {

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

