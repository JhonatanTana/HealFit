using HealFit.Model;

namespace HealFit.Service;
public interface IConsumoService {
    Task<List<ProdutoConsumido>> GetConsumoByUserId(int id);
    Task<bool> AddConsumo(ProdutoConsumido consumo);
    Task<bool> UpdateConsumo(ProdutoConsumido consumo);
    Task<bool> DeleteConsumo(int id);
    Task<List<ProdutoConsumido>> GetAllConsumoByDate(int id, string data);
    Task<ProdutoConsumido> GetConsumoById(int id);
}
