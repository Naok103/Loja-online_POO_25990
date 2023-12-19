using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Objetos;

namespace Dados
{
    /// <summary>
    /// Purpose: Classe para guardar os metodos relacionados com Campanha
    /// Created by: Rafael silva
    /// Created on: 21/11/2023 10:54:43
    /// </summary>
    [Serializable]
    public class Campanhas : ICampanha, IEnumerable<Campanha>
    {
        #region ESTADO 

        static List<Campanha> campanhas;

        #endregion

        #region COMPORTAMENTO

        #region CONSTRUTORES

        /// <summary>
        /// Construtor por omissão
        /// </summary>
        static Campanhas()
        {
            campanhas = new List<Campanha>();
        }

        #endregion

        #region PROPRIEDADES

        public static List<Campanha> CAMPANHAS
        {
            get { return campanhas; }
            set { campanhas = value; }
        }

        #endregion

        #region OUTROSMETODOS

        public bool InseirCampanha(Campanha campanha)
        {
            campanhas.Add(campanha);
            return false;
        }

        public bool AdicionarProdutoCampanha(string nome,int id, Produtos produtos)
        {
            foreach(Campanha campanha in campanhas)
            {
                if(campanha.Nome == nome)
                {
                    if (ExisteProdutoCampanha(id, nome) == false)
                    {
                        foreach(Produto produto in produtos)
                        {
                            if(produto.Id == id)
                            {
                                campanha.IDP.Add(produto);
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public bool RetirarProdutoCampanha(string nome, int id)
        {
            foreach(Campanha campanha in campanhas)
            {
                if(campanha.Nome == nome)
                {
                    foreach(Produto produto in campanha.IDP)
                    {
                        if(produto.Id == id)
                        {
                            campanha.IDP.Remove(produto);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool AlterarCampanha(int t, string nome, int duracao, int desconto)
        {
            foreach(Campanha campanha in campanhas)
            {
                if(campanha.Nome == nome)
                {
                    switch (t)
                    {
                        case 1:
                            campanha.Nome = nome;
                            return true;
                        case 2:
                            campanha.Duracao = duracao;
                            return true;
                        case 3:
                            campanha.Desconto = desconto;
                            return true;
                    }
                }
            }
            return false;
        }

        public bool RetirarCampanha(string nome)
        {
            foreach(Campanha campanha in campanhas)
            {
                if(campanha.Nome == nome)
                {
                    campanhas.Remove(campanha);
                    return true;
                }
            }
            return false;
        }

        public bool ExisteCampanha(string nome)
        {
            foreach(Campanha campanha in campanhas)
            {
                if (campanha.Nome == nome)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ExisteProdutoCampanha(int id, string nome)
        {
            foreach(Campanha campanha in campanhas)
            {
                if(campanha.Nome == nome)
                {
                    foreach(Produto produto in campanha.IDP)
                    {
                        if(produto.Id == id)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool GuardarCampanhasB(string m)
        {
            Stream s = File.Open(m, FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, campanhas);
            s.Close();
            return true;
        }

        public bool LerCampanhasB(string m)
        {
            Stream s = File.Open(m, FileMode.Open);
            BinaryFormatter b = new BinaryFormatter();
            campanhas = (List<Campanha>)b.Deserialize(s);
            s.Close();
            return true;
        }

        public bool GuardarCampanhas(string m)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(m))
                {
                    foreach (var campanha in campanhas)
                    {
                        writer.WriteLine($"{campanha.Nome}#{campanha.Desconto}#{campanha.Duracao}");
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

        public bool LerCampanhas(string m)
        {
            using (StreamReader sr = File.OpenText(m))
            {
                string linha = sr.ReadLine();
                while (linha != null)
                {
                    string[] sdados = linha.Split('#');
                    string nome = sdados[0];
                    int desconto = int.Parse(sdados[1]);
                    int duracao = int.Parse(sdados[2]);
                    
                    Campanha campanha = new Campanha(nome,duracao,desconto);

                    campanhas.Add(campanha);

                    linha = sr.ReadLine();
                }
            }
            return true;
        }

        public bool GuardarProdutoCampanha(string m)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(m))
                {
                    foreach (var campanha in campanhas)
                    {
                        foreach(Produto produto in campanha.IDP)
                        {
                            writer.WriteLine($"{campanha.Nome}#{produto.Id}");
                        }
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

        public bool LerProdutoCampanha(string m, Produtos produtos)
        {
            using (StreamReader sr = File.OpenText(m))
            {
                string linha = sr.ReadLine();
                while (linha != null)
                {
                    string[] sdados = linha.Split('#');
                    string nomeC = sdados[0];
                    int id = int.Parse(sdados[1]);

                    AdicionarProdutoCampanha(nomeC, id, produtos);

                    linha = sr.ReadLine();
                }
            }
            return true;
        }
        #endregion

        #region IEnumerable<Venda> Members

        public IEnumerator<Campanha> GetEnumerator()
        {
            return campanhas.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return campanhas.GetEnumerator();
        }

        #endregion

        #endregion
        
    }
}

