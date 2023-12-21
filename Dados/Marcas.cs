using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;
using Objetos;


namespace Dados
{
    /// <summary>
    /// Purpose: classe para desenvolver as funcoes relacionadas com as marcas
    /// Created by: Rafael silva
    /// Created on: 21/11/2023 11:19:58
    /// </summary>
    [Serializable]
    public class Marcas : IMarca, IEnumerable<Marca>
    {

        #region ESTADO 

        static List<Marca> marcas; // lista que contem as marcas presentes na loja

        #endregion

        #region COMPORTAMENTO

        #region CONSTRUTORES

        /// <summary>
        /// Construtor por omissão
        /// </summary>
        static Marcas()
        {
            marcas = new List<Marca>();
        }

        #endregion

        #region PROPRIEDADES

        /// <summary>
        /// Propriedades da lista marcas
        /// </summary>
        public static List<Marca> MARCAS
        {
            get { return marcas; }
            set { marcas = value; }
        }

        #endregion

        #region OUTROSMETODOS

        /// <summary>
        /// Funcao para adicionar uma marca a lista
        /// </summary>
        /// <param name="m">variavel para a marca</param>
        /// <returns>retorna true se for adicionado e false se nao</returns>
        public bool InserirMarca(Marca m)
        {
            if (ExisteMarca(m.Id) == false)
            {
                marcas.Add(m);
                return true;
                
            }
            return false;
        }

        /// <summary>
        /// Funcao para retirar uma marca
        /// </summary>
        /// <param name="id">variavel para o id da marca</param>
        /// <returns>retorna true se removeu a marca ou false se nao</returns>
        public bool RetirarMarca(int id)
        {
            for (int i = 0; i < marcas.Count; i++)
            {
                if (marcas[i].Id == id)
                {
                    marcas.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Funcao para alterar uma marca
        /// </summary>
        /// <param name="id">variavel para o id da marca</param>
        /// <param name="i">variavel que determina que propriedade da marca deve ser alterada</param>
        /// <param name="nome">variavel para o nome da marca</param>
        /// <param name="site">variavel para o site da marca</param>
        /// <returns>retorna true se for alterado uma propriedade da marca e false se nao</returns>
        public bool AlterarMarca(int id, int[] i, string nome, string site)
        { 
            for (int o = 0; o < marcas.Count; o++)
            {
                if (marcas[o].Id == id)
                {
                    for(int t = 0; t < i.Length; t++)
                    {
                        switch (i[t])
                        {
                            case 1:
                                marcas[o].Nome = nome;
                                break;
                            case 2:
                                marcas[o].Site = site;
                                break;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Funcao para verificar se uma marca ja existe
        /// </summary>
        /// <param name="id">variavel para o id da marca</param>
        /// <returns>retorna true se a marca existe e false se nao</returns>
        public bool ExisteMarca(int id)
        {
 
            for (int i = 0; i < marcas.Count; i++)
            {
                if (marcas[i].Id == id)
                {
                    return true;
                }

            }
            return false;
        }

        /// <summary>
        /// funcao para buscar o proximo id da marca
        /// </summary>
        /// <param name="id">variavel para o id da marca</param>
        /// <returns>retorna o id</returns>
        public int ID(int id)
        {
            for(int i = 0; i < marcas.Count; i++)
            {
                id = marcas[i].Id;
            }
            id++;
            return id;
        }

        /// <summary>
        /// Funcao para guardar as marcas num ficheiro binario
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool GravarMarcasB(string m) 
        {
            Stream s = File.Open(m, FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, marcas);
            s.Close();
            return true;
        }

        /// <summary>
        /// Funcao para ler as marcas de um ficheiro bianrio
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool LerMarcasB(string m) 
        {
            Stream s = File.Open(m, FileMode.Open);
            BinaryFormatter b = new BinaryFormatter();
            marcas = (List<Marca>)b.Deserialize(s);
            s.Close();
            return true;
        }

        /// <summary>
        /// Funcao para guardar as marcas num ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool GravarMarcas(string m)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(m))
                {
                    foreach (var marca in marcas)
                    {
                        writer.WriteLine($"{marca.Id}#{marca.Nome}#{marca.Site}");
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
        /// Funcao para ler as marcas de um ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool LerMarcas(string m)
        {
            using (StreamReader sr = File.OpenText(m))
            {
                string linha = sr.ReadLine();
                while (linha != null)
                {
                    string[] sdados = linha.Split('#');
                    int id = int.Parse(sdados[0]);
                    string nome = sdados[1];
                    string site = sdados[2];

                    Marca marca = new Marca(id,nome,site);
                   
                    marcas.Add(marca);

                    linha = sr.ReadLine();
                }
            }
            return true;
        }

        #endregion

        #region IEnumerable<Marca> Members

        public IEnumerator<Marca> GetEnumerator()
        {
            return marcas.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return marcas.GetEnumerator();
        }

        #endregion

        #endregion
    }
}

