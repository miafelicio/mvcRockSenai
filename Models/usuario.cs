using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using exemplo.Models;
using System.IO;

namespace exemplo.Models
{
    public class Usuario
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public virtual void Logar()
        {

        }

        public List<string> ReadAllLinesCSV(string PATH)
        {


            List<string> linhas = new List<string>();
            using (StreamReader file = new StreamReader(PATH))
            {

                string linha;
                while ((linha = file.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }
            return linhas;

        }

        public void CriarPastaEArquivo(string _caminho)
        {

            string pasta = _caminho.Split("/")[0];
            string arquivo = _caminho.Split("/")[1];

            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            if (!File.Exists(_caminho))
            {
                File.Create(_caminho).Close();
            }
        }

        private const string CAMINHO = "Database/Usuario.csv";

         private string Preparar(Usuario u){
            return $";{u.Email};{u.Nome};{u.Senha};";
        }


        public Usuario()
        {
            CriarPastaEArquivo(CAMINHO);

        }

        public void Cadastrar(Usuario u)
        {
            string[] linha = { Preparar(u) };
            File.AppendAllLines(CAMINHO, linha);
        }


    }
}