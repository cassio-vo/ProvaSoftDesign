using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ProvaSoftDesign.Negocio;
using ProvaSoftDesign.ViewModel;

namespace ProvaSoftDesign.Controllers
{
    public class AutentificacaoController : Controller
    {
        UsuarioNegocio _usuarioNegocio = new UsuarioNegocio();

        // GET: Autentificação
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string returnURL)
        {
            /*Recebe a url que o usuário tentou acessar*/
            ViewBag.ReturnUrl = returnURL;
            return View(new UsuarioVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string login, string senha)
        {
            if (ModelState.IsValid)
            {
                var existe = _usuarioNegocio.ValidaUsuarioSenha(login, senha);
                if (existe)
                {
                    FormsAuthentication.SetAuthCookie(login, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(new UsuarioVM
                    {
                        Login = login,
                        Mensagem = "Login ou Senha errados."
                    });
                }
            }
            else
                return View(new UsuarioVM());
        }
    }
}