using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Libraries.Sessao.Login;
using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LojaVirtual.Libraries.Filtro
{
    /*
     * - Tipos de Filtros:
     * - Autorização
     * - Recurso 
     * - Ação
     * - Exceção
     * - Resultado
     */
    public class ClienteAutorizacaoAttribute : Attribute, IAuthorizationFilter
    {
        LoginSessao _loginSessao;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //Resolvendo o problema de injeção de dependencia.
            //Buscando a informação direto do serviço no startup.cs
            _loginSessao = (LoginSessao)context.HttpContext.RequestServices.GetService(typeof(LoginSessao));

            Cliente cliente = _loginSessao.ObterLoginCliente();

            if (cliente == null)
            {
                context.Result = new ContentResult() { Content = "Acesso Negado." };
            }
        }
    }
}
