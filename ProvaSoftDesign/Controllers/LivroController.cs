using ProvaSoftDesign.Models.Entity;
using ProvaSoftDesign.Negocio;
using ProvaSoftDesign.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProvaSoftDesign.Controllers
{
    [Authorize]
    public class LivroController : Controller
    {
        LivroNegocio _livroNegocio = new LivroNegocio();

        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var livro = _livroNegocio.RetornaLivro((int)id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            return View(livro);
        }

        [HttpPost]
        public ActionResult Index([Bind(Include = "Id,NomeLivro,AutorLivro,DataLancamento,Alugado")] LivroVM livroParameter)
        {
            if (livroParameter == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var livro = _livroNegocio.RetornaLivro(livroParameter.Id);
            if (livro == null)
            {
                return HttpNotFound();
            }

            bool alugado = false;
            if (ModelState.IsValid)
            {
                alugado = _livroNegocio.AlugaLivro(livro.Id);
            }

            if (alugado)
                livro.Mensagem = "Alugado com sucesso";
            else
                livro.Mensagem = "Não foi possível alugar pois já esta alugado.";

            return View(livro);
        }
    }
}