using ProvaSoftDesign.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProvaSoftDesign.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        LivroNegocio _livroNegocio = new LivroNegocio();
        public ActionResult Index()
        {
            return View(_livroNegocio.RetornaListaLivros());
        }

        [HttpPost]
        public ActionResult Index([Bind(Include = "titulo")] string titulo)
        {
            return View(_livroNegocio.RetornaListaLivrosPeloNome(titulo));
        }
    }
}