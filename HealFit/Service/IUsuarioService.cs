using HealFit.Model;

namespace HealFit.Service; 
public interface IUsuarioService {

    Task<int?> VerificaUsuario(Usuario usuario);
    Task<Usuario> GetUsuarioById(int id);
    Task<bool> UpdateUsuario(Usuario usuario);
    Task<Usuario> AddUsuario(Usuario usuario);
    Task<bool> DeleteUsuario(int id);
    Task<List<Usuario>> GetAllUsuarios();

}
