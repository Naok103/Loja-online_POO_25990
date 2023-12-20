using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Objetos;

namespace Dados
{
    /// <summary>
    /// Purpose: Classe para guardar os metodos relacionados com Vendas
    /// Created by: Rafael silva
    /// Created on: 21/11/2023 10:55:28
    /// </summary>
    [Serializable]
    public class Vendas : IVenda, IEnumerable<Venda>
    {
        #region ESTADO 

        static List<Venda> vendas; //lista com o conjunto de vendas realizadas

        #endregion

        #region COMPORTAMENTO

        #region CONSTRUTORES

        /// <summary>
        /// Construtor por omissão
        /// </summary>
        static Vendas()
        {
            vendas = new List<Venda>();
        }

        #endregion

        #region PROPRIEDADES

        /// <summary>
        /// Propriedade da lista vendas
        /// </summary>
        public static List<Venda> VENDAS
        {
            get { return vendas; }
            set { vendas = value; }
        }

        #endregion

        #region OUTROSMETODOS

        /// <summary>
        /// Funcao para adicionar uma venda a lista de vendas
        /// </summary>
        /// <param name="v">variavel para uma venda</param>
        /// <returns></returns>
        public bool AdicionarVenda(Venda v)
        {
            vendas.Add(v);
            return true;
        }

        /// <summary>
        /// Funcao para guardar as vendas num ficheiro binario
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool GuardarVendaB(string m)
        {
            Stream s = File.Open(m, FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, vendas);
            s.Close();
            return true;
        }

        /// <summary>
        /// Funcao para ler as vendas de um ficheiro binario
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool LerVendaB(string m)
        {
            Stream s = File.Open(m, FileMode.Open);
            BinaryFormatter b = new BinaryFormatter();
            vendas = (List<Venda>)b.Deserialize(s);
            s.Close();
            return true;
        }

        /// <summary>
        /// Funcao para guardar as vendas num ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool GuardarVenda(string m)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(m))
                {
                    foreach (var venda in vendas)
                    {
                        writer.WriteLine($"{venda.Quantidades}#{venda.IDP}#{venda.IDC}#{venda.Hora}");
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gravar produtos: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Funcao para ler as vendas de um ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool LerVenda(string m)
        {
            using (StreamReader sr = File.OpenText(m))
            {
                string linha = sr.ReadLine();
                while (linha != null)
                {
                    string[] sdados = linha.Split('#');
                    int quantidade = int.Parse(sdados[0]);
                    int Idp = int.Parse(sdados[1]);
                    int Idc = int.Parse(sdados[2]);
                    DateTime hora = DateTime.Parse(sdados[3]);

                    Venda venda = new Venda(quantidade, Idp, Idc, hora);

                    vendas.Add(venda);

                    linha = sr.ReadLine();
                }
            }
            return true;
        }

        #endregion

        #region IEnumerable<Venda> Members

        public IEnumerator<Venda> GetEnumerator()
        {
            return vendas.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return vendas.GetEnumerator();
        }

        #endregion

        #endregion
        


    }
}

