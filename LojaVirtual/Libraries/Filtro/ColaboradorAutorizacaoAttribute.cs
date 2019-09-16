using LojaVirtual.Libraries.Sessao.Login;
using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Filtro
{
    public class ColaboradorAutorizacaoAttribute : Attribute, IAuthorizationFilter
    {
        LoginColaborador _loginColaborador;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //Resolvendo o problema de injeção de dependencia.
            //Buscando a informação direto do serviço no startup.cs
            _loginColaborador = (LoginColaborador)context.HttpContext.RequestServices.GetService(typeof(LoginColaborador));

            Colaborador colaborador = _loginColaborador.ObterLoginColaborador();

            if (colaborador == null)
            {
                context.Result = new ContentResult() { Content = "Acesso Negado." };
            }
        }
    }
}
