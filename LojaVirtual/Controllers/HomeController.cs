﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Database;
using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        private LojaVirtualContext _lojaVirtualContext;
        
        public HomeController(LojaVirtualContext lojaVirtualContext)
        {
            _lojaVirtualContext = lojaVirtualContext;
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
                _lojaVirtualContext.Add(newsLetterEmail);
                _lojaVirtualContext.SaveChanges();

                TempData["MSG_S"] = "E-mail Cadastrado com sucesso. Agora você poderá receber as novidades da loja virtual por email.";

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }                        
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult CadastroCliente()
        {
            return View();
        }

        public IActionResult CarrinhoCompras()
        {
            return View();
        }
    }
}   