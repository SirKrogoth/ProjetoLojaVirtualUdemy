using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Database;
using LojaVirtual.Models;
using LojaVirtual.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        private IClienteRepository _clienteRepository;
        private INewsLetterRepository _newsLetterRepository;

        public HomeController(IClienteRepository clienteRepository, INewsLetterRepository newsLetterRepository)
        {
            _clienteRepository = clienteRepository;
            _newsLetterRepository = newsLetterRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index([FromForm]NewsLetterEmail newsLetterEmail)
        {
            if(ModelState.IsValid)
            {
                //_lojaVirtualContext.Add(newsLetterEmail);
                //_lojaVirtualContext.SaveChanges();

                _newsLetterRepository.Cadastrar(newsLetterEmail);

                TempData["MSGS"] = "E-mail Cadastrado com sucesso. Agora você poderá receber as novidades da loja virtual por email.";

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }                        
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromForm]Cliente cliente)
        {
            if (cliente.Email == "joao@gmail.com" && cliente.Senha == "506829")
            {
                HttpContext.Session.Set("Id", new byte[] { 52 });
                HttpContext.Session.SetString("Email", cliente.Email);
                HttpContext.Session.SetInt32("Idade", 30);

                return new ContentResult(){ Content="Logado!"};
            }
            else
            {
                return new ContentResult() { Content = "Não Logado!" };
            }
        }

        [HttpGet]
        public IActionResult Painel()
        {
            byte[] UsuarioID;

            if (HttpContext.Session.TryGetValue("Id", out UsuarioID))
                return new ContentResult() { Content = $"Usuário ID: {UsuarioID[0]}, Email: {HttpContext.Session.GetString("Email")} e Idade: {HttpContext.Session.GetInt32("Idade")} está logado com sucesso." };
            else
                return new ContentResult() { Content = "Acesso Negado." };

        }

        [HttpGet]
        public IActionResult CadastroCliente()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastroCliente([FromForm]Cliente cliente)
        {
            if(ModelState.IsValid)
            {
                _clienteRepository.Cadastrar(cliente);

                TempData["MSG_S"] = "Cadastro realizado com sucesso.";

                //TODO - Implementar redirecionamentos diferentes
                //return RedirectToAction(nameof(CadastroCliente));
                return View();
            }
            else
            {
                return View();
            }
        }

        public IActionResult CarrinhoCompras()
        {
            return View();
        }
    }
}