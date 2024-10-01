using HealFit.Model;

namespace HealFit.Service; 
public interface IUsuarioService {

    Task<List<UsuarioModel>> GetAllUsuarios();
    Task<UsuarioModel> GetUsuarioById(int registroId);
    Task<int> AddUsuario(UsuarioModel usuario);
    Task<int> UpdateUsuario(UsuarioModel usuario);
    Task<int> DeleteUsuarioById(int registroId);
}
