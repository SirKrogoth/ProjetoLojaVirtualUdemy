using LojaVirtual.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Sessao.Login
{
    public class LoginColaborador
    {
        private Sessao _sessao;
        private const string chave = "Login.Colaborador";

        public LoginColaborador(Sessao sessao)
        {
            _sessao = sessao;
        }

        public void Login(Colaborador colaborador)
        {
            //Serialização
            string loginColaboradorJSONString = JsonConvert.SerializeObject(colaborador);

            _sessao.Cadastrar(chave, loginColaboradorJSONString);
        }

        public Colaborador ObterLoginCliente()
        {
            if (_sessao.Existe(chave))
            {
                //Descerialização
                string loginColaboradorJSONString = _sessao.Consultar(chave);

                return JsonConvert.DeserializeObject<Colaborador>(loginColaboradorJSONString);
            }
            else
            {
                return null;
            }

        }

        public void FecharLoginCliente()
        {
            _sessao.RemoverTodos();
        }
    }
}
