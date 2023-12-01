using Dados;
using Objetos;
using System;

namespace Loja_online
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IO iO = new IO();
            Marca nike = new Marca(1, "nike", "nike.com");
            Marca adidas = new Marca(2  , "adidas", "adidas.com");
            Marcas marcas = new Marcas();

            marcas.InserirMarca(nike);
            marcas.InserirMarca(adidas);
            iO.MostrarMarcas(marcas);



            marcas.RetirarMarca(1);
            iO.MostrarMarcas(marcas);


            
            marcas.GravarMarcas(@"dadosmarcas.txt");
            marcas.LerMarcas(@"dadosmarcas.txt");
            
            
        }
    }
}
