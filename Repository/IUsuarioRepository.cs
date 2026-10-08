using EnvioEmail.Models;

namespace EnvioEmail.Repository
{
    public interface IUsuarioRepository
    {
        public Usuario BuscarUsuarioLogin(Login login);
        public bool UsuarioExistente(Login login);
        public Usuario? BuscarPorId(int id);
    }
}
