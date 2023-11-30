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
            bool aux = ExisteMarca(m);
            if (aux == false)
            {
                marcas.Add(m);
                Console.WriteLine("exito!");
                return true;
                
            }

            return false;
        }

        public bool AlterarMarca(Marca m)
        {
            return true;
        }

        public bool RetirarMarca(Marca m)
        {
            bool aux = ExisteMarca(m);
            if(aux == false)
            {
                foreach (Marca marca in marcas)
                {
                    if(marca == m)
                    {
                        marcas.Remove(marca);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool ExisteMarca(Marca m)
        {
            foreach (Marca marca in marcas)
            {
                if(marca == m)
                {
                    return true;
                }
            }
            return false;
        }

        public bool GravarMarcasB(string m) 
        {
            Stream s = File.Open(m, FileMode.Create);
            //testar se ficheiro...
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, marcas);
            s.Close();
            return true;
        }

        public bool LerMarcasB(string m) 
        {
            Stream s = File.Open(m, FileMode.Open);
            //testar se ficheiro...
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

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return marcas.GetEnumerator();
        }

        #endregion

        #endregion
    }
}

