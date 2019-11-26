using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaVirtual.Models;
using LojaVirtual.wwwroot.Libraries.Email;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Contato()
        {
            return View();
        }

        public IActionResult EnviarEmailContato()
        {
            Contato contato = new Contato();
            
            contato.Nome = HttpContext.Request.Form["nome"];
            contato.Email = HttpContext.Request.Form["email"];
            contato.Texto = HttpContext.Request.Form["texto"];

            var listaMensagens = new List<ValidationResult>();
            var contexto = new ValidationContext(contato);

            bool isValid = Validator.TryValidateObject(contato, contexto, listaMensagens, true);
               
            if(isValid)
            {
                try
                {
                    GerenciadorEmail.EnviarContatoPorEmail(contato);

                    //Aqui deverá ter tratamento de erro.
                    ViewData["MSG_Success"] = "Email enviado com sucesso!";
                }
                catch
                {
                    ViewData["MSG_Erro"] = "Falha ao enviar email para o cliente.";

                    //TODO - Implementar log
                }
            }
            else
            {
                StringBuilder sb = new StringBuilder();

                foreach (var item in listaMensagens)
                {
                    sb.Append(item.ErrorMessage + "<br/>");
                }

                ViewData["MSG_Erro"] = sb.ToString();
                ViewData["Contato"] = contato;
            }

            return View("Contato");
       }
   }
}