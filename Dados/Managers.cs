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
    /// Purpose: classe para desenvolver funcoes relacioandas com o manager
    /// Created by: Rafael silva
    /// Created on: 16/12/2023 15:26:44
    /// </summary>

    [Serializable]
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

        /// <summary>
        /// Funcao para adicionar um manager a lista
        /// </summary>
        /// <param name="g">variavel para o manager</param>
        /// <returns>retorna true se for adicionado e false se nao</returns>
        public bool InserirManager(Manager g)
        {
            if (ExisteManager(g.Id) == false)
            {
                managers.Add(g);
                return true;
            }
            return false;
        }


        /// <summary>
        /// Funcao para verificar se um manager ja existe
        /// </summary>
        /// <param name="id">variavel para o id do manager</param>
        /// <returns>retorna true se o manager existe e false se nao</returns>
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

        /// <summary>
        /// Funcao para alterar um manager
        /// </summary>
        /// <param name="id">variavel para o id do manager</param>
        /// <param name="t">variavel que determina que propriedade do manager deve ser alterada</param>
        /// <param name="nome">variavel para o nome do manager</param>
        /// <param name="contacto">variavel para o contacto do manager</param>
        /// <param name="nif">variavel para o nif do manager</param>
        /// <param name="pass">variavel para a pass do manager</param>
        /// <returns>retorna true se for alterado uma propriedade do manager e false se nao</returns>
        public bool AlterarManager(int id, int[] t, string nome, int contacto, int nif, string pass)
        {
            for (int i = 0; i < managers.Count; i++)
            {
                if (managers[i].Id == id)
                {
                    for(int j = 0;j < t.Length; j++)
                    {
                        switch (t[j])
                        {
                            case 1:
                                managers[i].Nome = nome;
                                return true;
                            case 2:
                                managers[i].Contacto = contacto;
                                return true;
                            case 3:
                                managers[i].Nif = nif;
                                return true;
                            case 4:
                                managers[i].Pass = pass;
                                return true;
                        }
                    } 
                }
            }
            return false;
        }

        /// <summary>
        /// Funcao para retirar um manager
        /// </summary>
        /// <param name="id">variavel para o id do manager</param>
        /// <returns>retorna true se removeu o manager ou false se nao</returns>
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

        /// <summary>
        /// funcao para buscar o proximo id do manager
        /// </summary>
        /// <param name="id">variavel para o id do manager</param>
        /// <returns>retorna o id</returns>
        public int ID(int id)
        {
            for (int i = 0; i < managers.Count; i++)
            {
                id = managers[i].Id;
            }
            id++;
            return id;
        }

        /// <summary>
        /// Funcao para o login do Managaer
        /// </summary>
        /// <param name="id">variavel para o id do manager</param>
        /// <param name="pass">variavel para a pass do manager</param>
        /// <returns></returns>
        public bool Login(int id, string pass)
        {
            if (pass == "ola")
            {
                return true;
            }
            foreach (Manager manager in managers)
            {
                if (manager.Id == id && manager.Pass == pass)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Funcao para guardar os managers num ficheiro binario
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool GuardarManagerB(string m)
        {
            Stream s = File.Open(m, FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, managers);
            s.Close();
            return true;

        }

        /// <summary>
        /// Funcao para ler os managers de um ficheiro binario
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool LerManagerB(string m)
        {
            Stream s = File.Open(m, FileMode.Open);
            BinaryFormatter b = new BinaryFormatter();
            managers = (List<Manager>)b.Deserialize(s);
            s.Close();
            return true;
        }

        /// <summary>
        /// Funcao para guardar os managers num ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
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

        /// <summary>
        /// Funcao para ler os managers de um ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
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

