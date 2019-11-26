using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Configuration;

namespace LojaVirtual.wwwroot.Libraries.Email
{
    public class GerenciadorEmail
    {
        private SmtpClient _smtp;
        private IConfiguration _configuration;

        public GerenciadorEmail(SmtpClient smtp, IConfiguration configuration)
        {
            _smtp = smtp;
            _configuration = configuration;
        }

        public void EnviarContatoPorEmail(Contato contato)
        {
            /*
             *SMTP -> Servidor que irá enviar as mensagens         
             */
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("menezes.jrafael@gmail.com", "506829506829");
            smtp.EnableSsl = true;
                
            string corpoMsg = string.Format("<h2>Contato - LojaVirtual</h2>" +
                                            "<b>Nome: </b> {0} <br/>" +
                                            "<b>Email: </b> {1} <br/>" +
                                            "<b>Texto: <b> {2} <br/>" +
                                            "Email enviado automaticamente do site LojaVirtual.",
                contato.Nome,
                contato.Email,
                contato.Texto);

            /*
             * MailMessage -> Construir a mensagem
             */
            MailMessage mensagem = new MailMessage();

            mensagem.From = new MailAddress(_configuration.GetValue<string>("Email:UserName"));
            mensagem.To.Add("menezes.jrafael@gmail.com");
            mensagem.Subject = "Contato - LojaVirtual - Email: " + contato.Email;
            mensagem.Body = corpoMsg;
            mensagem.IsBodyHtml = true;

            //Enviar mensagem pelo protocolo SMTP
            _smtp.Send(mensagem);
        }
    }
}