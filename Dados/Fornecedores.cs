using objetos;
using Objetos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dados
{
    /// <summary>
    /// Purpose: classe para desenvolver funcoes relacioandas com o fornecedor
    /// Created by: Rafael silva
    /// Created on: 21/12/2023 14:39:30
    /// </summary>

    [Serializable]
    public class Fornecedores: IFornecedor, IEnumerable<Fornecedor>
    {
        #region ESTADO 

        static List<Fornecedor> fornecedores; // lista que contem os fornecedores da loja

        #endregion

        #region COMPORTAMENTO

        #region CONSTRUTORES

        /// <summary>
        /// Construtor por omissão
        /// </summary>
        static Fornecedores()
        {
            fornecedores = new List<Fornecedor>();
        }

        #endregion

        #region PROPRIEDADES

        /// <summary>
        /// Propriedade da lista
        /// </summary>
        public static List<Fornecedor> FORNECEDORES
        {
            get { return fornecedores; }
            set { fornecedores = value; }
        }

        #endregion

        #region OUTROSMETODOS

        /// <summary>
        /// Funcao para adicionar um fornecedor a lista
        /// </summary>
        /// <param name="f">variavel para o fornecedor</param>
        /// <returns>retorna true se for adicionado e false se nao</returns>
        public bool AdicionarFornecedor(Fornecedor f)
        {
            if (ExisteFornecedor(f.Id) == false)
            {
                fornecedores.Add(f);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Funcao para alterar um fornecedor
        /// </summary>
        /// <param name="id">variavel para o id do fornecedor</param>
        /// <param name="d">variavel que determina que propriedade do fornecedor deve ser alterada</param>
        /// <param name="nome">variavel para o nome do fornecedor</param>
        /// <param name="contacto">variavel para o contacto do fornecedor</param>
        /// <param name="nif">variavel para o nif do fornecedor</param>
        /// <param name="morada">variavel para a morada do fornecedor</param>
        /// <param name="email">variavel para o email do fornecedor</param>
        /// <returns>retorna true se for alterado uma propriedade do fornecedor e false se nao</returns>
        public bool AlterarFornecedor(int id, int[] d, string nome, int contacto, int nif, string morada, string email)
        {
            for (int i = 0; i < fornecedores.Count; i++)
            {
                if (fornecedores[i].Id == id)
                {
                    for (int t = 0; t < d.Length; t++)
                    {
                        switch (d[t])
                        {
                            case 1:
                                fornecedores[i].Nome = nome;
                                break;
                            case 2:
                                fornecedores[i].Contacto = contacto;
                                break;
                            case 3:
                                fornecedores[i].Nif = nif;
                                break;
                            case 4:
                                fornecedores[i].Morada = morada;
                                break;
                            case 5:
                                fornecedores[i].Email = email;
                                break;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Funcao para verificar se um fornecedor ja existe
        /// </summary>
        /// <param name="id">variavel para o id do fornecedor</param>
        /// <returns>retorna true se o fornecedor existe e false se nao</returns>
        public bool ExisteFornecedor(int id)
        {

            foreach (Fornecedor fornecedor in fornecedores)
            {
                if (fornecedor.Id == id)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Funcao para retirar um fornecedor
        /// </summary>
        /// <param name="id">variavel para o id do fornecedor</param>
        /// <returns>retorna true se removeu o fornecedor ou false se nao</returns>
        public bool RetirarFornecedor(int id)
        {
            for (int i = 0; i < fornecedores.Count; i++)
            {
                if (fornecedores[i].Id == id)
                {
                    fornecedores.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// funcao para buscar o proximo id do fornecedor
        /// </summary>
        /// <param name="id">variavel para o id do fornecedor</param>
        /// <returns>retorna o id</returns>
        public int ID(int id)
        {
            for (int i = 0; i < fornecedores.Count; i++)
            {
                id = fornecedores[i].Id;
            }
            id++;
            return id;
        }

        /// <summary>
        /// Funcao para guardar os fornecedores num ficheiro binario
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool GravarFornecedorB(string m)
        {
            Stream s = File.Open(m, FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, fornecedores);
            s.Close();
            return true;
        }

        /// <summary>
        /// Funcao para ler os fornecedores de um ficheiro binario
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool LerFornecedorB(string m)
        {
            Stream s = File.Open(m, FileMode.Open);
            BinaryFormatter b = new BinaryFormatter();
            fornecedores = (List<Fornecedor>)b.Deserialize(s);
            s.Close();
            return true;
        }

        /// <summary>
        /// Funcao para guardar os fornecedores num ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool GravarFornecedor(string m)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(m))
                {
                    foreach (var fornecedor in fornecedores)
                    {
                        writer.WriteLine($"{fornecedor.Id}#{fornecedor.Nome}#{fornecedor.Contacto}#{fornecedor.Nif}#{fornecedor.Morada}#{fornecedor.Email}");
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
        /// Funcao para ler os fornecedores de um ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool LerFornecedor(string m)
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
                    string email = sdados[5];


                    Fornecedor fornecedor = new Fornecedor(id, nome, contacto, nif, morada, email);

                    fornecedores.Add(fornecedor);

                    linha = sr.ReadLine();
                }
            }
            return true;
        }

        #endregion

        #region IEnumerable<Fornecedor> Members

        public IEnumerator<Fornecedor> GetEnumerator()
        {
            return fornecedores.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return fornecedores.GetEnumerator();
        }

        #endregion

        #endregion
    }
}

