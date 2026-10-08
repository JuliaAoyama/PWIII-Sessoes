using EnvioEmail.Data;
using EnvioEmail.Models;

namespace EnvioEmail.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DatabaseContext dbContext;

        public UsuarioRepository(DatabaseContext contexto)
        {
            dbContext = contexto;
        }

        public Usuario BuscarUsuarioLogin(Login login)
        {
            return dbContext.Usuarios.Where(x => x.Nome == login.Nome && x.Email == login.Email && x.Senha == login.Senha).FirstOrDefault();
        }

        public bool UsuarioExistente(Login login)
        {
            Usuario usuario = dbContext.Usuarios.Where(x => x.Nome == login.Nome && x.Email == login.Email && x.Senha == login.Senha).FirstOrDefault();

            if (usuario != null)
                return true;
            else
                return false;
        }

        public Usuario? BuscarPorId(int id)
        {
            return dbContext.Usuarios.FirstOrDefault(u => u.Id == id);
        }
    }
}
