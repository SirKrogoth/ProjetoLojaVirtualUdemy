using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LojaVirtual.Libraries.Sessao.Login
{
    public class LoginSessao
    {
        private Sessao _sessao;
        private const string chave = "Login.Cliente";

        public LoginSessao(Sessao sessao)
        {
            _sessao = sessao;
        }

        public void LoginCliente(Cliente cliente)
        {
            //Serialização
            string loginClienteJSONString = JsonConvert.SerializeObject(cliente);

            _sessao.Cadastrar(chave, loginClienteJSONString);
        }

        public Cliente ObterLoginCliente()
        {
            if(_sessao.Existe(chave))
            {
                //Descerialização
                string loginClienteJSONString = _sessao.Consultar(chave);

                return JsonConvert.DeserializeObject<Cliente>(loginClienteJSONString);
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
