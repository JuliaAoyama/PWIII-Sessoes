using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EnvioEmail.Filters
{
    public class UsuarioLogadoAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Recupera para saber se o usuario esta logado ou não
            int? usuarioId = context.HttpContext.Session.GetInt32("UsuarioId");

            // Impede o acesso sem login
            if (usuarioId == null)
            {
                //Redireciona para o index de LoginController
                //Result apenas para seguir um caminho diferente do padrão
                context.Result = 
                    new RedirectToActionResult("Index", "Login", null);
            }

            base.OnActionExecuting(context);
        }
    }
}
