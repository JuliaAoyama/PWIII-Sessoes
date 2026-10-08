using EnvioEmail.Models;
using EnvioEmail.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EnvioEmail.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsuarioRepository usuarioRepository;
        public HomeController(IUsuarioRepository userRep)
        {
            usuarioRepository = userRep;
        }
        public IActionResult Index()
        {
            int usuarioId = HttpContext.Session.GetInt32("UsuarioId")!.Value;
            Usuario? usuario = usuarioRepository.BuscarPorId(usuarioId);
            return View(usuario);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
