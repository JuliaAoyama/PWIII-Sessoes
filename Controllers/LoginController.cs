using EnvioEmail.Filters;
using EnvioEmail.Models;
using EnvioEmail.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EnvioEmail.Controllers
{
    [UsuarioLogado]
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository usuarioRepository;

        public LoginController(IUsuarioRepository userRep)
        {
            usuarioRepository = userRep;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("UsuarioId") != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Entrar(Login login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario usuarioExistente = usuarioRepository.BuscarUsuarioLogin(login);

                    if (usuarioExistente != null)
                    {
                        HttpContext.Session.SetInt32("UsuarioId", usuarioExistente.Id);
                        HttpContext.Session.SetString("UsuarioNome", usuarioExistente.Nome);
                        return View("~/Views/Home/Index.cshtml", usuarioExistente);
                    }
                    else
                    {
                        ViewBag.MensagemLogin = "Usuário não encontrado.";
                        return View("Index");
                    }
                }

                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Falha ao realizar o login. Por favor, tente novamente. Detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
