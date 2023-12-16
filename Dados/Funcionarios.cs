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
    /// Purpose:
    /// Created by: Rafael silva
    /// Created on: 14/12/2023 16:36:16
    /// </summary>
    [Serializable]
    public class Funcionarios : IFuncionario, IEnumerable<Funcionario>
    {
        #region ESTADO 

        static List<Funcionario> funcionarios;

        #endregion

        #region COMPORTAMENTO

        #region CONSTRUTORES

        /// <summary>
        /// Construtor por omissão
        /// </summary>
        static Funcionarios()
        {
            funcionarios = new List<Funcionario>();
        }

        #endregion

        #region PROPRIEDADES

        public List<Funcionario> Lista
        {
            get { return funcionarios; }
            set { funcionarios = value; }
        }

        #endregion

        #region OUTROSMETODOS

        public bool InserirFuncionario(Funcionario f)
        {
            if(ExisteFuncionario(f.Id) == false)
            {
                funcionarios.Add(f);
                return true;
            }
            return false;
        }

        public bool ExisteFuncionario(int id)
        {
            foreach(Funcionario f in funcionarios)
            {
                if (f.Id == id)
                {
                    return true;
                }     
            }   
            return false;
        }

        public bool AlterarFuncionario(int id, int t, string nome, int contacto, int nif)
        {
            for(int i = 0;i< funcionarios.Count; i++)
            {
                if (funcionarios[i].Id == id)
                {
                    switch(t)
                    {
                        case 1:
                            funcionarios[t].Nome = nome;
                            return true;
                        case 2:
                            funcionarios[t].Contacto = contacto;
                            return true;
                        case 3:
                            funcionarios[t].Nif = nif;
                            return true;
                    }
                }
            }
            return false;
        }

        public bool RetirarFuncionario(int id)
        {
            for(int i = 0;i<funcionarios.Count;i++ )
            {
                if (funcionarios[i].Id == id) 
                {
                    funcionarios.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public int ID(int id)
        {
            for (int i = 0; i < funcionarios.Count; i++)
            {
                id = funcionarios[i].Id;
            }
            id++;
            return id;
        }

        public bool GuardarFuncionarioB(string m)
        {
            Stream s = File.Open(m, FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, funcionarios);
            s.Close();
            return true;
           
        }

        public bool LerFuncionarioB(string m)
        {
            Stream s = File.Open(m, FileMode.Open);
            BinaryFormatter b = new BinaryFormatter();
            funcionarios = (List<Funcionario>)b.Deserialize(s);
            s.Close();
            return true;
        }

        public bool GuardarFuncionario(string m)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(m))
                {
                    foreach (var funcionario in funcionarios)
                    {
                        writer.WriteLine($"{funcionario.Id}#{funcionario.Nome}#{funcionario.Contacto}#{funcionario.Nif}");
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

        public bool LerFuncionario(string m)
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
                    

                    Funcionario funcionario = new Funcionario(id, nome, contacto, nif);

                    funcionarios.Add(funcionario);

                    linha = sr.ReadLine();
                }
            }
            return true;
        }

        #endregion

        #region IEnumerable<Funcionario> Members

        public IEnumerator<Funcionario> GetEnumerator()
        {
            return funcionarios.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return funcionarios.GetEnumerator();
        }

        #endregion

        #endregion
    }
}

