using HealFit.Model;

namespace HealFit.Service;
public interface IDadosService {

    Task<DadosPessoais> GetDadosById(int id);
    Task<bool> GetDadosByUserId(int id);
    Task<bool> AddDados(DadosPessoais dados);
    Task<bool> UpdateDados(DadosPessoais dados);
    Task<bool> DeleteDados(int id);
}
