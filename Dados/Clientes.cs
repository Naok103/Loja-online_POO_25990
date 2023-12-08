using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Objetos;


namespace Dados
{
    /// <summary>
    /// Purpose:
    /// Created by: Rafael silva
    /// Created on: 21/11/2023 11:20:36
    /// </summary>
    public class Clientes : ICliente, IEnumerable<Cliente>
    {

        #region ESTADO 

        static List<Cliente> clientes;

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

        public static List<Cliente> CLIENTES
        {
            get { return clientes; }
            set { clientes = value; }
        }

        #endregion

        #region OUTROSMETODOS

        public bool AdicionarCliente(Cliente c)
        {
            if(ExisteCliente(c.Id) == false)
            {
                clientes.Add(c);
                return true;
            }
            return false;
        }

        public bool AlterarCliente(int id,int d, string nome, int contacto, int nif, string morada)
        {
            for(int i = 0; i< clientes.Count;i++)
            {
                if (clientes[i].Id == id)
                {
                    switch (d)
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
            return false;
        }

        public bool ExisteCliente(int id)
        {

            foreach(Cliente cliente in clientes)
            {
                if (cliente.Id == id)
                return true;
            }
            return false;
        }

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

        public bool GravarClienteB(string m)
        {
            Stream s = File.Open(m, FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, clientes);
            s.Close();
            return true;
            
        }

        public bool LerClienteB(string m)
        {
            Stream s = File.Open(m, FileMode.Open);
            BinaryFormatter b = new BinaryFormatter();
            clientes = (List<Cliente>)b.Deserialize(s);
            s.Close();
            return true;
        }

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

