using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Database;
using LojaVirtual.Models;

namespace LojaVirtual.Repositories
{
    public class NewsLetterRepository : INewsLetterRepository
    {
        private LojaVirtualContext _banco;

        public NewsLetterRepository(LojaVirtualContext banco)
        {
            _banco = banco;
        }

        public void Cadastrar(NewsLetterEmail newsLetter)
        {
            _banco.NewsLetterEmails.Add(newsLetter);
            _banco.SaveChanges();
        }

        public IEnumerable<NewsLetterEmail> ObterTodosNewsLetter()
        {
            return _banco.NewsLetterEmails.ToList();
        }
    }
}
