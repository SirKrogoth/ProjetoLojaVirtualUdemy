using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Sessao
{
    public class Sessao : ISessao
    {
        private IHttpContextAccessor _context;

        public Sessao(IHttpContextAccessor context)
        {
            _context = context;
        }

        public void Atualizar(string chave, string valor)
        {
            if(Existe(chave))
            {
                _context.HttpContext.Session.Remove(chave);
                Cadastrar(chave, valor);
            }
        }

        public void Cadastrar(string chave, string valor)
        {
            _context.HttpContext.Session.SetString(chave, valor);
        }

        public string Consultar(string chave)
        {
            return _context.HttpContext.Session.GetString(chave);
        }

        public bool Existe(string chave)
        {
            if (_context.HttpContext.Session.GetString(chave) == null)
                return false;
            else
                return true;
        }

        public void Remover(string chave)
        {
            _context.HttpContext.Session.Remove(chave);
        }

        public void RemoverTodos()
        {
            _context.HttpContext.Session.Clear();
        }
    }
}