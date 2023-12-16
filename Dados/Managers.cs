using objetos;
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
    /// Purpose:
    /// Created by: Rafael silva
    /// Created on: 16/12/2023 15:26:44
    /// </summary>
    public class Managers : IManager, IEnumerable<Manager>
    {
        #region ESTADO 

        static List<Manager> managers;

        #endregion

        #region COMPORTAMENTO

        #region CONSTRUTORES

        /// <summary>
        /// Construtor por omissão
        /// </summary>
        static Managers()
        {
            managers = new List<Manager>();
        }

        #endregion

        #region PROPRIEDADES

        public List<Manager> MANAGAERS
        {
            get { return managers; }
            set { managers = value; }
        }

        #endregion

        #region OUTROSMETODOS

        public bool InserirManager(Manager g)
        {
            if (ExisteManager(g.Id) == false)
            {
                managers.Add(g);
                return true;
            }
            return false;
        }

        public bool ExisteManager(int id)
        {
            foreach (Manager managaer in managers)
            {
                if (managaer.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool AlterarManager(int id, int t, string nome, int contacto, int nif, string pass)
        {
            for (int i = 0; i < managers.Count; i++)
            {
                if (managers[i].Id == id)
                {
                    switch (t)
                    {
                        case 1:
                            managers[t].Nome = nome;
                            return true;
                        case 2:
                            managers[t].Contacto = contacto;
                            return true;
                        case 3:
                            managers[t].Nif = nif;
                            return true;
                        case 4:
                            managers[t].Pass = pass;
                            return true;
                    }
                }
            }
            return false;
        }

        public bool RetirarManager(int id)
        {
            for (int i = 0; i < managers.Count; i++)
            {
                if (managers[i].Id == id)
                {
                    managers.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public int ID(int id)
        {
            for (int i = 0; i < managers.Count; i++)
            {
                id = managers[i].Id;
            }
            id++;
            return id;
        }

        public bool GuardarManagerB(string m)
        {
            Stream s = File.Open(m, FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, managers);
            s.Close();
            return true;

        }

        public bool LerManagerB(string m)
        {
            Stream s = File.Open(m, FileMode.Open);
            BinaryFormatter b = new BinaryFormatter();
            managers = (List<Manager>)b.Deserialize(s);
            s.Close();
            return true;
        }

        public bool GuardarManager(string m)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(m))
                {
                    foreach (var manager in managers)
                    {
                        writer.WriteLine($"{manager.Id}#{manager.Nome}#{manager.Contacto}#{manager.Nif}#{manager.Pass}");
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

        public bool LerManager(string m)
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
                    string pass = sdados[4];



                    Manager manager = new Manager(id, nome, contacto, nif, pass);

                    managers.Add(manager);

                    linha = sr.ReadLine();
                }
            }
            return true;
        }

        #endregion

        #region IEnumerable<Manager> Members

        public IEnumerator<Manager> GetEnumerator()
        {
            return managers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return managers.GetEnumerator();
        }

        #endregion

        #endregion
    }
}

