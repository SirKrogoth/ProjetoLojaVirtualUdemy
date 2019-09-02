using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Sessao
{
    public interface ISessao
    {
        void Cadastrar(string chave, string valor);
        void Atualizar(string chave, string valor);
        void Remover(string chave);
        string Consultar(string chave);
        bool Existe(string chave);
        void RemoverTodos();
    }
}
