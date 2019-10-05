using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Database;
using LojaVirtual.Models;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace LojaVirtual.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        const int _registroPorPagina = 10;
        LojaVirtualContext _banco;

        public CategoriaRepository(LojaVirtualContext banco)
        {
            _banco = banco;
        }

        public void Atualizar(Categoria categoria)
        {
            _banco.Update(categoria);
            _banco.SaveChanges();
        }

        public void Cadastrar(Categoria categoria)
        {
            _banco.Add(categoria);
            _banco.SaveChanges();
        }

        public void Excluir(int id)
        {
            Categoria categoria = ObterCategoria(id);

            _banco.Remove(categoria);
            _banco.SaveChanges();
        }

        public Categoria ObterCategoria(int id)
        {
            return _banco.Categorias.Find(id);
        }

        //public IEnumerable<Categoria> ObterTodasCategorias()
        //{
        //    return _banco.Categorias.ToList();
        //}

        public IPagedList<Categoria> ObterTodasCategorias(int? pagina)
        {
            int numeroPagina = pagina ?? 1;
            return _banco.Categorias.Include(a=>a.CategoriaID).ToPagedList<Categoria>(numeroPagina, _registroPorPagina);
        }

        public IEnumerable<Categoria> ObterTodasCategorias()
        {
            return _banco.Categorias;
        }
    }
}
