using HealFit.Model;

namespace HealFit.Service;
public interface IConsumoService {
    Task<ProdutoConsumido> GetConsumoById(int id);
    Task<bool> AddConsumo(ProdutoConsumido consumo);
    Task<bool> DeleteConsumo(int id);
    Task<List<ProdutoConsumido>> GetAllConsumo();
}
