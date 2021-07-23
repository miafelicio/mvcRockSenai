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

        


    }
}