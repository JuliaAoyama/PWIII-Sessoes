using System.ComponentModel.DataAnnotations;

namespace EnvioEmail.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Campo de nome vazio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo de email vazio")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo de senha vazio")]
        public string Senha { get; set; }
    }
}
