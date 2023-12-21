using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Objetos;


namespace Dados
{
    /// <summary>
    /// Purpose: classe para desenvolver funcoes relacioandas com o cliente
    /// Created by: Rafael silva
    /// Created on: 21/11/2023 11:20:36
    /// </summary>
    [Serializable]
    public class Clientes : ICliente, IEnumerable<Cliente>
    {

        #region ESTADO 

        static List<Cliente> clientes; // lista que contem os clientes da loja

        #endregion

        #region COMPORTAMENTO

        #region CONSTRUTORES

        /// <summary>
        /// Construtor por omissão
        /// </summary>
        static Clientes()
        {
            clientes = new List<Cliente>();
        }

        #endregion

        #region PROPRIEDADES

        /// <summary>
        /// Propriedade da lista
        /// </summary>
        public static List<Cliente> CLIENTES
        {
            get { return clientes; }
            set { clientes = value; }
        }

        #endregion

        #region OUTROSMETODOS

        /// <summary>
        /// Funcao para adicionar um cliente a lista
        /// </summary>
        /// <param name="c">variavel para o cliente</param>
        /// <returns>retorna true se for adicionado e false se nao</returns>
        public bool AdicionarCliente(Cliente c)
        {
            if(ExisteCliente(c.Id) == false)
            {
                clientes.Add(c);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Funcao para alterar um cliente
        /// </summary>
        /// <param name="id">variavel para o id do cliente</param>
        /// <param name="t">variavel que determina que propriedade do cliente deve ser alterada</param>
        /// <param name="nome">variavel para o nome do cliente</param>
        /// <param name="contacto">variavel para o contacto do cliente</param>
        /// <param name="nif">variavel para o nif do cliente</param>
        /// <param name="morada">variavel para a morada do cliente</param>
        /// <returns>retorna true se for alterado uma propriedade do cliente e false se nao</returns>
        public bool AlterarCliente(int id,int[] d, string nome, int contacto, int nif, string morada)
        {
            for(int i = 0; i< clientes.Count;i++)
            {
                if (clientes[i].Id == id)
                {
                    for (int t = 0; t < d.Length; t++)
                    {
                        switch (d[t])
                        {
                            case 1:
                                clientes[i].Nome = nome;
                                break;
                            case 2:
                                clientes[i].Contacto = contacto;
                                break;
                            case 3:
                                clientes[i].Nif = nif;
                                break;
                            case 4:
                                clientes[i].Morada = morada;
                                break;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Funcao para verificar se um cliente ja existe
        /// </summary>
        /// <param name="id">variavel para o id do cliente</param>
        /// <returns>retorna true se o cliente existe e false se nao</returns>
        public bool ExisteCliente(int id)
        {

            foreach(Cliente cliente in clientes)
            {
                if (cliente.Id == id)
                return true;
            }
            return false;
        }

        /// <summary>
        /// Funcao para retirar um cliente
        /// </summary>
        /// <param name="id">variavel para o id do cliente</param>
        /// <returns>retorna true se removeu o cliente ou false se nao</returns>
        public bool RetirarCliente(int id)
        {
            for (int i = 0; i < clientes.Count; i++)
            {
                if (clientes[i].Id == id)
                {
                    clientes.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// funcao para buscar o proximo id do cliente
        /// </summary>
        /// <param name="id">variavel para o id do cliente</param>
        /// <returns>retorna o id</returns>
        public int ID(int id)
        {
            for (int i = 0; i < clientes.Count; i++)
            {
                id = clientes[i].Id;
            }
            id++;
            return id;
        }

        /// <summary>
        /// Funcao para guardar os clientes num ficheiro binario
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool GravarClienteB(string m)
        {
            Stream s = File.Open(m, FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, clientes);
            s.Close();
            return true;
        }

        /// <summary>
        /// Funcao para ler os clientes de um ficheiro binario
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool LerClienteB(string m)
        {
            Stream s = File.Open(m, FileMode.Open);
            BinaryFormatter b = new BinaryFormatter();
            clientes = (List<Cliente>)b.Deserialize(s);
            s.Close();
            return true;
        }

        /// <summary>
        /// Funcao para guardar os clientes num ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool GravarCliente(string m)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(m))
                {
                    foreach (var cliente in clientes)
                    {
                        writer.WriteLine($"{cliente.Id}#{cliente.Nome}#{cliente.Contacto}#{cliente.Nif}#{cliente.Morada}");
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
        /// Funcao para ler os clientes de um ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool LerCliente(string m)
        {
            using (StreamReader sr = File.OpenText(m))
            {
                string linha = sr.ReadLine();
                while (linha != null)
                {
                    string[] sdados = linha.Split('#');
                    int id = int.Parse(sdados[0]);
                    string nome = sdados[1];
                    int contacto = int.Parse(sdados[2]);
                    int nif = int.Parse(sdados[3]);
                    string morada = sdados[4];

                    Cliente cliente = new Cliente(id, nome, contacto, nif, morada);

                    clientes.Add(cliente);

                    linha = sr.ReadLine();
                }
            }
            return true;
        }

        #endregion

        #region IEnumerable<Cliente> Members

        public IEnumerator<Cliente> GetEnumerator()
        {
            return clientes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return clientes.GetEnumerator();
        }

        #endregion

        #endregion
        
    }
}

