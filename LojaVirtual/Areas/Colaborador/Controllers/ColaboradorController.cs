﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Libraries.Lang;
using LojaVirtual.Libraries.Texto;
using LojaVirtual.Repositories;
using LojaVirtual.wwwroot.Libraries.Email;
using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account.Manage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using X.PagedList;

namespace LojaVirtual.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    public class ColaboradorController : Controller
    {
        private IColaboradorRepository _colaboradorRepository;
        private GerenciadorEmail _gerenciadorEmail;

        public ColaboradorController(IColaboradorRepository colaboradorRepository, GerenciadorEmail gerenciadorEmail)
        {
            _colaboradorRepository = colaboradorRepository;
            _gerenciadorEmail = gerenciadorEmail;
        }

        public IActionResult Index(int? pagina)
        {
            IPagedList<Models.Colaborador> colaboradores = _colaboradorRepository.ObterTodosColaboradores(pagina);

            return View(colaboradores);
        }

        [HttpGet]
        public IActionResult GerarSenha(int id)
        {
            Models.Colaborador colaborador = _colaboradorRepository.ObterColaborador(id);
            colaborador.Senha = KeyGenerator.GetUniqueKey(8);
            _colaboradorRepository.AtualizarSenha(colaborador);
                
            _gerenciadorEmail.EnviarSenhaParaColaboradorPorEmail(colaborador);

            TempData["MSG_S"] = Mensagem.MSG_S003;

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm]Models.Colaborador colaborador)
        {
            //Sistema irá ignorar o campo senha
            ModelState.Remove("Senha");
            if(ModelState.IsValid)
            {
                colaborador.Tipo = "C";
                colaborador.Senha = KeyGenerator.GetUniqueKey(8);
                _colaboradorRepository.Cadastrar(colaborador);

                _gerenciadorEmail.EnviarSenhaParaColaboradorPorEmail(colaborador);

                TempData["MSG_S"] = Mensagem.MSG_S001;

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Atualizar(int id)
        {
             Models.Colaborador colaborador = _colaboradorRepository.ObterColaborador(id);

            return View(colaborador);
        }

        [HttpPost]
        public IActionResult Atualizar([FromForm] Models.Colaborador colaborador, int id)
        {
            if(ModelState.IsValid)
            {
                _colaboradorRepository.Atualizar(colaborador);

                TempData["MSG_S"] = Mensagem.MSG_S002;

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            _colaboradorRepository.Excluir(id);
            TempData["MSG_S"] = Mensagem.MSG_S001;

            return RedirectToAction(nameof(Index));
        }
    }
}