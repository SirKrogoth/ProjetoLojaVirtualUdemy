using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Controllers
{
    public class ProdutoController : Controller
    {
        //deve retornar iactionresult ou actionresult
        public ActionResult Visualizar()
        {
            var produto = GetProduto();
            //return new ContentResult() {Content = "<h3>Produto->Visualizar</h3>", ContentType = "text/html"};
            return View(produto);
        }

        private Produto GetProduto()
        {
            return new Produto()
            {
                Id = 1,
                Descricao = "Jogue em 4K",
                Nome = "Xbox One X",
                Valor = 2000.00M
            };
        }
    }
}
