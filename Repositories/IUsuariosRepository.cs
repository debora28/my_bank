using MyLastApi.Model;
using MyLastApi.Models.Entities.Usuarios;

namespace MyLastApi.Repositories
{
    public interface IUsuariosRepository
    {
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<Usuario> GetUsuario(int id);
        Task<Usuario> CreateUsuario(Usuario usuario);
        Task<Usuario> UpdateUsuario(Usuario usuario);
        Task DeleteUsuario(int id);
    }
}
