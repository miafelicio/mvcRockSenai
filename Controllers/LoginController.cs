using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using exemplo.Models;

namespace mvc_rockINsenai.Controllers
{
    public class LoginController : Controller
    {
       
        Usuario UsuarioModel = new Usuario();
        [Route("Logar")]
        public IActionResult Logar(IFormCollection form){
            List<string> csv = UsuarioModel.ReadAllLinesCSV("DataBase/usuario.csv");

            var logado = csv.Find(
                x =>
                x.Split(";")[1] == form["E-mail"] &&
                x.Split(";")[2] == form["Senha"]
            );
            Console.WriteLine($"Text");
            
            Console.WriteLine(logado);
            Console.WriteLine(logado.Split(";")[1]);
            
            

            if(logado != null)
            {
                
                HttpContext.Session.SetString("_UserName", logado.Split(";")[1]);

                return LocalRedirect("~/Home");
            }


            return LocalRedirect("~/");
        }

        public IActionResult Index()
        {
            return View();
        }

    }

}