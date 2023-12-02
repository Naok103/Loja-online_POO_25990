using Dados;
using Objetos;
using Regras;
using System;


namespace Loja_online
{
     class Program
    {
        static void Main(string[] args)
        {
            IO iO = new IO();
            RegrasNegocio regras = new RegrasNegocio();
            Marcas marcas = new Marcas();

            regras.InserirMarca();
            iO.MostrarMarcas(marcas);
            regras.AlterarMarca(1);
            iO.MostrarMarcas(marcas);

            
            marcas.GravarMarcas(@"dadosmarcas.txt");
            marcas.LerMarcas(@"dadosmarcas.txt");
            
            
        }
    }
}
