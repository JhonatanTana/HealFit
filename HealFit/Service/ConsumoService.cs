using HealFit.Model;
using Newtonsoft.Json;
using System.Text;

namespace HealFit.Service;
public class ConsumoService : IConsumoService {

    private string? base_url;
    private Page _page;

    public async Task<bool> AddConsumo(ProdutoConsumido consumo) {

        var returnResponse = false;

        try {
            base_url = await SecureStorage.GetAsync("servidor");

            if (string.IsNullOrEmpty(base_url)) {
                throw new Exception("Base URL não encontrada no SecureStorage.");
            }

            using (var client = new HttpClient()) {

                var url = $"{base_url}/Consumo";

                var serializeContent = JsonConvert.SerializeObject(consumo);
                var content = new StringContent(serializeContent, Encoding.UTF8, "application/json");

                var apiResponse = await client.PostAsync(url, content);

                if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK) {

                    var responseString = await apiResponse.Content.ReadAsStringAsync();
                    returnResponse = true;
                }
            }
        }
        catch (Exception ex) {
            string msg = ex.Message;
        }

        return returnResponse;
    }

    public Task<bool> DeleteConsumo(int id) {
        throw new NotImplementedException();
    }

    public Task<List<ProdutoConsumido>> GetAllConsumo() {
        throw new NotImplementedException();
    }

    public Task<ProdutoConsumido> GetConsumoById(int id) {
        throw new NotImplementedException();
    }
}
