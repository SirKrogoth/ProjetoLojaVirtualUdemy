using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using LojaVirtual.Models;

namespace LojaVirtual.wwwroot.Libraries.Email
{
    public class ContatoEmail
    {
        public static void EnviarContatoPorEmail(Contato contato)
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

            mensagem.From = new MailAddress("menezes.jrafael@gmail.com");
            mensagem.To.Add("menezes.jrafael@gmail.com");
            mensagem.Subject = "Contato - LojaVirtual - Email: " + contato.Email;
            mensagem.Body = corpoMsg;
            mensagem.IsBodyHtml = true;

            //Enviar mensagem pelo protocolo SMTP
            smtp.Send(mensagem);
        }
    }
}