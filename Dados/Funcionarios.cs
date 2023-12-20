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
    /// Purpose: classe para desenvolver funcoes relacioandas com o funcionario
    /// Created by: Rafael silva
    /// Created on: 14/12/2023 16:36:16
    /// </summary>
    [Serializable]
    public class Funcionarios : IFuncionario, IEnumerable<Funcionario>
    {
        #region ESTADO 

        static List<Funcionario> funcionarios; // lista que contem os funcionarios da loja

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

        /// <summary>
        /// Propriedades da lista
        /// </summary>
        public List<Funcionario> Lista
        {
            get { return funcionarios; }
            set { funcionarios = value; }
        }

        #endregion

        #region OUTROSMETODOS

        /// <summary>
        /// Funcao para adicionar um funcionario a lista
        /// </summary>
        /// <param name="f">variavel para o funcionarios</param>
        /// <returns>retorna true se for adicionado e false se nao</returns>
        public bool InserirFuncionario(Funcionario f)
        {
            if(ExisteFuncionario(f.Id) == false)
            {
                funcionarios.Add(f);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Funcao para verificar se um funcionario ja existe
        /// </summary>
        /// <param name="id">variavel para o id do funcionario</param>
        /// <returns>retorna true se o funcionario existe e false se nao</returns>
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

        /// <summary>
        /// Funcao para alterar um funcionario
        /// </summary>
        /// <param name="id">variavel para o id do funcionario</param>
        /// <param name="t">variavel que determina que propriedade do funcionario deve ser alterada</param>
        /// <param name="nome">variavel para o nome do funcionario</param>
        /// <param name="contacto">variavel para o contacto do funcionario</param>
        /// <param name="nif">variavel para o nif do funcionario</param>
        /// <returns>retorna true se for alterado uma propriedade do funcionario e false se nao</returns>
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

        /// <summary>
        /// Funcao para retirar um funcionario
        /// </summary>
        /// <param name="id">variavel para o id do funcionario</param>
        /// <returns>retorna true se removeu o funcionario ou false se nao</returns>
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

        /// <summary>
        /// funcao para buscar o proximo id do funcionario
        /// </summary>
        /// <param name="id">variavel para o id do funcionario</param>
        /// <returns>retorna o id</returns>
        public int ID(int id)
        {
            for (int i = 0; i < funcionarios.Count; i++)
            {
                id = funcionarios[i].Id;
            }
            id++;
            return id;
        }

        /// <summary>
        /// Funcao para guardar os funcionarios num ficheiro binario
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool GuardarFuncionarioB(string m)
        {
            Stream s = File.Open(m, FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, funcionarios);
            s.Close();
            return true;
           
        }

        /// <summary>
        /// Funcao para ler os funcionarios de um ficheiro binario
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool LerFuncionarioB(string m)
        {
            Stream s = File.Open(m, FileMode.Open);
            BinaryFormatter b = new BinaryFormatter();
            funcionarios = (List<Funcionario>)b.Deserialize(s);
            s.Close();
            return true;
        }

        /// <summary>
        /// Funcao para guardar os funcionarios num ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
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

        /// <summary>
        /// Funcao para ler os funcionarios de um ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
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

