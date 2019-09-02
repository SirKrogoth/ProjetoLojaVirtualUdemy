using LojaVirtual.Database;
using LojaVirtual.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using LojaVirtual.Libraries.Sessao;
using LojaVirtual.Libraries.Sessao.Login;

namespace LojaVirtual
{
    public static class InjetarDepedencia
    {
        public static void RegistrarServicos(this IServiceCollection services)
        {            
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<INewsLetterRepository, NewsLetterRepository>();
            services.AddScoped<Sessao>();
            services.AddScoped<LoginSessao>();
        }        
    }
}
