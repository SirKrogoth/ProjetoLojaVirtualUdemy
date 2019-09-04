using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Database;
using LojaVirtual.Models;

namespace LojaVirtual.Repositories
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private LojaVirtualContext _banco;

        public ColaboradorRepository(LojaVirtualContext banco)
        {
            _banco = banco;
        }
        
        public void Atualizar(Colaborador colaborador)
        {
            _banco.Add(colaborador);
            _banco.SaveChanges();
        }

        public void Cadastrar(Colaborador colaborador)
        {
            _banco.Add(colaborador);
            _banco.SaveChanges();
        }

        public void Excluir(int Id)
        {
            _banco.Remove(Id);
            _banco.SaveChanges();
        }

        public Colaborador Login(string email, string senha)
        {
            Colaborador colaborador = _banco.Colaboradores.Where(m => m.Email == email && m.Senha == senha).FirstOrDefault();
            return colaborador;
        }

        public Colaborador ObterColaborador(int Id)
        {
            return _banco.Colaboradores.Find(Id);
        }

        public IEnumerable<Colaborador> ObterTodosColaboradores()
        {
            return _banco.Colaboradores.ToList();
        }
    }
}
