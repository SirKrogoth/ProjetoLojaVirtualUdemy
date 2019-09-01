using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Database;
using LojaVirtual.Models;
using LojaVirtual.Repositories;
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
        public IActionResult Login([FromBody]Cliente cliente)
        {
            return View();
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