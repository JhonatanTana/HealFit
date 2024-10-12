using HealFit.Model;
using Newtonsoft.Json;
using System.Text;


namespace HealFit.Service;
public class DadosService : IDadosService {

    private string base_url;

    public async Task<bool> AddDados(DadosPessoais dados) {

        var returnResponse = false;

        try {

            base_url = await SecureStorage.GetAsync("servidor");

            if (string.IsNullOrEmpty(base_url)) {
                throw new Exception("Base URL não encontrada no SecureStorage.");
            }

            using (var client = new HttpClient()) {

                var url = $"{base_url}/dados";

                var serializeContent = JsonConvert.SerializeObject(dados);

                var apiResponse = await client.PostAsync(url, new StringContent(serializeContent, Encoding.UTF8, "application/json"));

                if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK) {

                    var response = await apiResponse.Content.ReadAsStringAsync();
                    var deserializeResponse = JsonConvert.DeserializeObject<DadosPessoais>(response);

                    if (deserializeResponse != null) {

                        return true;
                    }

                }
            }
        }
        catch (Exception ex) {
            string msg = ex.Message;
        }

        return returnResponse;
    }

    public async Task<bool> DeleteDados(int id) {

        var returnResponse = false;

        try {
            base_url = await SecureStorage.GetAsync("servidor");

            if (string.IsNullOrEmpty(base_url)) {
                throw new Exception("Base URL não encontrada no SecureStorage.");
            }

            using (var client = new HttpClient()) {
                var url = $"{base_url}/Dados/{id}";

                var apiResponse = await client.DeleteAsync(url);

                if (apiResponse.StatusCode == System.Net.HttpStatusCode.NoContent) {
                    returnResponse = true; // Success if the user was deleted
                }
            }
        }
        catch (Exception ex) {
            string msg = ex.Message;
        }

        return returnResponse;
    }

    public async Task<DadosPessoais> GetDadosById(int id) {

        var returnResponse = new DadosPessoais();

        base_url = await SecureStorage.GetAsync("servidor");

        if (string.IsNullOrEmpty(base_url)) {
            throw new Exception("Base URL não encontrada no SecureStorage.");
        }

        using (var client = new HttpClient()) {
            var url = $"{base_url}/Dados/{id}";
            var apiResponse = await client.GetAsync(url);

            if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK) {

                var response = await apiResponse.Content.ReadAsStringAsync();
                returnResponse = JsonConvert.DeserializeObject<DadosPessoais>(response) ?? new DadosPessoais();
            }

            return returnResponse;
        }
    }

    public async Task<bool> GetDadosByUserId(int id) {

        var returnResponse = false;

        base_url = await SecureStorage.GetAsync("servidor");

        if (string.IsNullOrEmpty(base_url)) {
            throw new Exception("Base URL não encontrada no SecureStorage.");
        }

        using (var client = new HttpClient()) {

            var url = $"{base_url}/Dados/Usuario/{id}";
            var apiResponse = await client.GetAsync(url);

            if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK) {

                returnResponse = true;
            }

            return returnResponse;
        }
    }

    public async Task<bool> UpdateDados(DadosPessoais dados) {

        var returnResponse = false;

        try {
            base_url = await SecureStorage.GetAsync("servidor");

            if (string.IsNullOrEmpty(base_url)) {
                throw new Exception("Base URL não encontrada no SecureStorage.");
            }

            using (var client = new HttpClient()) {
                var url = $"{base_url}/Dados"; // A URL inclui o ID do usuário

                var serializeContent = JsonConvert.SerializeObject(dados);
                var content = new StringContent(serializeContent, Encoding.UTF8, "application/json");

                var apiResponse = await client.PutAsync(url, content); // Faz a chamada PUT

                if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK) {

                    returnResponse = true; // Retorna true se a atualização foi bem-sucedida
                }
            }
        }
        catch (Exception ex) {
            string msg = ex.Message;
        }

        return returnResponse;
    }
}
