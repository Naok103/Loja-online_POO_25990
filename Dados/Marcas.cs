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
    /// Purpose:
    /// Created by: Rafael silva
    /// Created on: 21/11/2023 11:19:58
    /// </summary>
    [Serializable]
    public class Marcas : IMarca, IEnumerable<Marca>
    {

        #region ESTADO 

        static List<Marca> marcas;

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

        public static List<Marca> MARCAS
        {
            get { return marcas; }
            set { marcas = value; }
        }

        #endregion

        #region OUTROSMETODOS

        public bool InserirMarca(Marca m)
        {
            if (ExisteMarca(m.Id) == false)
            {
                marcas.Add(m);
                return true;
                
            }

            return false;
        }

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

        public bool AlterarMarca(int id, int i, string nome, string site)
        { 
            for (int o = 0; o < marcas.Count; o++)
            {
                if (marcas[o].Id == id)
                {
                    switch (i)
                    {
                        case 1:
                            marcas[o].Nome = nome;
                            return true;
                        case 2:
                            marcas[o].Site = site;
                            return true;
                    }
                }
            }
            return false;
        }

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

        public int ID(int id)
        {
            for(int i = 0; i < marcas.Count; i++)
            {
                id = marcas[i].Id;
            }
            id++;
            return id;
        }

        public bool GravarMarcasB(string m) 
        {
            Stream s = File.Open(m, FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, marcas);
            s.Close();
            return true;
        }

        public bool LerMarcasB(string m) 
        {
            Stream s = File.Open(m, FileMode.Open);
            BinaryFormatter b = new BinaryFormatter();
            marcas = (List<Marca>)b.Deserialize(s);
            s.Close();
            return true;
        }

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

