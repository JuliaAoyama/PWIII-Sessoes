using System.ComponentModel.DataAnnotations;

namespace EnvioEmail.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int NivelPermissao { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
