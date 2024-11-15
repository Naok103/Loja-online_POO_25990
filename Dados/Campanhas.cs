﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Objetos;
using Excecoes;

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

        static List<Campanha> campanhas; // lista que contem todas as campanhas da loja

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

        /// <summary>
        /// Propriedades da lista
        /// </summary>
        public static List<Campanha> CAMPANHAS
        {
            get { return campanhas; }
            set { campanhas = value; }
        }

        #endregion

        #region OUTROSMETODOS

        /// <summary>
        /// Funcao para adicionar uma campanha a lista
        /// </summary>
        /// <param name="campanha">variavel para a campanha</param>
        /// <returns>retorna true se for adicionado e false se nao</returns>
        public bool InserirCampanha(Campanha campanha)
        {
            if (ExisteCampanha(campanha.Id) == true)
                throw new CampanhaE();

            campanhas.Add(campanha);
            return true;
        }

        /// <summary>
        /// Funcao para adicionar um produto a uma campanha
        /// </summary>
        /// <param name="id">variavel para o id da campanha</param>
        /// <param name="idp">variavel para o id do produtos</param>
        /// <param name="produtos">variavel para a lista de produtos</param>
        /// <returns>retorna true se for adicionado e false se nao</returns>
        public bool AdicionarProdutoCampanha(int id,int idp, Produtos produtos)
        {
            if (!ExisteCampanha(id))
            {
                throw new CampanhaE();
            }
                

            foreach (Campanha campanha in campanhas)
            {
                if(campanha.Id == id)
                {
                    if (ExisteProdutoCampanha(idp, id) == false)
                    {
                        foreach(Produto produto in produtos)
                        {
                            if(produto.Id == idp)
                            {
                                campanha.IDP.Add(produto);
                                return true;
                            }
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Funcao para retirar um produto de uma campanha
        /// </summary>
        /// <param name="id">variavel para o id da campanha</param>
        /// <param name="idp">variavel para o id do produto</param>
        /// <returns>retorna true se removeu o produto da campanha ou false se nao</returns>
        public bool RetirarProdutoCampanha(int id, int idp)
        {
            foreach(Campanha campanha in campanhas)
            {
                if(campanha.Id == id)
                {
                    foreach(Produto produto in campanha.IDP)
                    {
                        if(produto.Id == idp)
                        {
                            campanha.IDP.Remove(produto);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Funcao para alterar uma campanha
        /// </summary>
        /// <param name="id">variavel para o id da campanha</param>
        /// <param name="t">variavel que determina que propriedade da campanha deve ser alterada</param>
        /// <param name="nome">variavel para o nome da campanha</param>
        /// <param name="duracao">variavel para a duracao da campanha</param>
        /// <param name="desconto">variavel para o desconto no produto durante a campanha</param>
        /// <returns>retorna true se for alterado uma propriedade da campanha e false se nao</returns>
        public bool AlterarCampanha(int id, int[] t, string nome, int duracao, double desconto)
        {
            if (!ExisteCampanha(id))
            {
                throw new CampanhaE();
            }
                

            for (int k = 0; k < campanhas.Count; k++)
            {
                if (campanhas[k].Nome == nome)
                {
                    for(int i = 0;i < t.Length; i++)
                    {
                        switch (t[i])
                        {
                            case 1:
                                campanhas[k].Nome = nome;
                                break;
                            case 2:
                                campanhas[k].Duracao = duracao;
                                break;
                            case 3:
                                campanhas[k].Desconto = desconto;
                                break;
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Funcao para retirar uma campanha
        /// </summary>
        /// <param name="id">variavel para o id da campanha</param>
        /// <returns>retorna true se removeu a campanha ou false se nao</returns>
        public bool RetirarCampanha(int id)
        {
            foreach(Campanha campanha in campanhas)
            {
                if(campanha.Id == id)
                {
                    campanhas.Remove(campanha);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Funcao para verificar se uma campanha ja existe
        /// </summary>
        /// <param name="id">variavel para o id da campanha</param>
        /// <returns>retorna true se a  campanha existe e false se nao</returns>
        public bool ExisteCampanha(int id)
        {
            foreach(Campanha campanha in campanhas)
            {
                if (campanha.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Funcao para verificar se um produto existe numa campanha
        /// </summary>
        /// <param name="id">variavel para o id da campanha</param>
        /// <param name="idp">variavel para o id do produto</param>
        /// <returns>retorna true se o produto existe e false se nao</returns>
        public bool ExisteProdutoCampanha(int idp, int id)
        {
            foreach(Campanha campanha in campanhas)
            {
                if(campanha.Id == id)
                {
                    foreach(Produto produto in campanha.IDP)
                    {
                        if(produto.Id == idp)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// funcao para buscar o proximo id da campanha
        /// </summary>
        /// <param name="id">variavel para o id da campanha</param>
        /// <returns>retorna o id</returns>
        public int ID(int id)
        {
            for (int i = 0; i < campanhas.Count; i++)
            {
                id = campanhas[i].Id;
            }
            id++;
            return id;
        }

        /// <summary>
        /// Funcao para guardar as campanhas num ficheiro binario
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool GuardarCampanhasB(string m)
        {
            Stream s = File.Open(m, FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, campanhas);
            s.Close();
            return true;
        }

        /// <summary>
        /// Funcao para ler as campanhas de um ficheiro binario
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool LerCampanhasB(string m)
        {
            Stream s = File.Open(m, FileMode.Open);
            BinaryFormatter b = new BinaryFormatter();
            campanhas = (List<Campanha>)b.Deserialize(s);
            s.Close();
            return true;
        }

        /// <summary>
        /// Funcao para guardar as campanhas num ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool GuardarCampanhas(string m)
        {
            try
            {
                using (StreamWriter writer = File.CreateText(m))
                {
                    foreach (var campanha in campanhas)
                    {
                        writer.WriteLine($"{campanha.Id}#{campanha.Nome}#{campanha.Desconto}#{campanha.Duracao}");
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
        /// Funcao para ler as campanhas de um ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
        public bool LerCampanhas(string m)
        {
            using (StreamReader sr = File.OpenText(m))
            {
                string linha = sr.ReadLine();
                while (linha != null)
                {
                    string[] sdados = linha.Split('#');
                    int id = int.Parse(sdados[0]);
                    string nome = sdados[1];
                    double desconto = double.Parse(sdados[2]);
                    int duracao = int.Parse(sdados[3]);
                    
                    Campanha campanha = new Campanha(id,nome,duracao,desconto);

                    campanhas.Add(campanha);

                    linha = sr.ReadLine();
                }
            }
            return true;
        }

        /// <summary>
        /// Funcao para guardar os produtos de uma campanha num ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <returns></returns>
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
                            writer.WriteLine($"{campanha.Id}#{produto.Id}");
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

        /// <summary>
        /// Funcao para ler os produtos de uma campanha de um ficheiro de texto
        /// </summary>
        /// <param name="m">variavel para o nome do ficheiro</param>
        /// <param name="produtos">variavel para a lista de produtos</param>
        /// <returns></returns>
        public bool LerProdutoCampanha(string m, Produtos produtos)
        {
            using (StreamReader sr = File.OpenText(m))
            {
                string linha = sr.ReadLine();
                while (linha != null)
                {
                    string[] sdados = linha.Split('#');
                    int id = int.Parse(sdados[1]);
                    int idp = int.Parse(sdados[1]);

                    AdicionarProdutoCampanha(id, idp, produtos);

                    linha = sr.ReadLine();
                }
            }
            return true;
        }

        public void Ordenar()
        {
            campanhas.Sort();
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

