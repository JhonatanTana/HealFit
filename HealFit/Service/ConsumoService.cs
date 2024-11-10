using HealFit.Model;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Storage;
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

                    returnResponse = true;
                }

                return returnResponse;
            }
        }
        catch (Exception ex) {

            string msg = ex.Message;

            await MainThread.InvokeOnMainThreadAsync(async () => {
                await App.Current.MainPage.DisplayAlert("Erro", msg, "OK");
            });
        }

        return returnResponse;
    }

    public async Task<bool> DeleteConsumo(int id) {

        var returnResponse = false;

        try {

            base_url = await SecureStorage.GetAsync("servidor");

            if (string.IsNullOrEmpty(base_url)) {
                throw new Exception("Base URL não encontrada no SecureStorage.");
            }

            using (var client = new HttpClient()) {
                var url = $"{base_url}/Consumo/{id}";

                var apiResponse = await client.DeleteAsync(url);

                if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK) {

                    returnResponse = true;
                }

                return returnResponse;
            }
        }
        catch (Exception ex) {

            string msg = ex.Message;

            await MainThread.InvokeOnMainThreadAsync(async () => {
                await App.Current.MainPage.DisplayAlert("Erro", msg, "OK");
            });
        }

        return returnResponse;
    }

    public async Task<List<ProdutoConsumido>> GetAllConsumoByDate(int id, string data) {

        var returnResponse = new List<ProdutoConsumido>();

        try {

            base_url = await SecureStorage.GetAsync("servidor");

            if (string.IsNullOrEmpty(base_url)) {

                throw new Exception("Base URL não encontrada no SecureStorage.");
            }

            using (var client = new HttpClient()) {

                var url = $"{base_url}/Consumo/Usuario/{id}/{data}";
                var apiResponse = await client.GetAsync(url);

                if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK) {

                    var response = await apiResponse.Content.ReadAsStringAsync();
                    returnResponse = JsonConvert.DeserializeObject<List<ProdutoConsumido>>(response) ?? new List<ProdutoConsumido>();
                }

                return returnResponse;
            }
        }
        catch (Exception ex) {

            string msg = ex.Message;

            await MainThread.InvokeOnMainThreadAsync(async () => {
                await App.Current.MainPage.DisplayAlert("Erro", msg, "OK");
            });
        }

        return returnResponse;
    }

    public async Task<ProdutoConsumido> GetConsumoById(int id) {

        var returnResponse = new ProdutoConsumido();

        try {

            base_url = await SecureStorage.GetAsync("servidor");

            if (string.IsNullOrEmpty(base_url)) {

                throw new Exception("Base URL não encontrada no SecureStorage.");
            }

            using (var client = new HttpClient()) {

                var url = $"{base_url}/Consumo/{id}";
                var apiResponse = await client.GetAsync(url);

                if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK) {

                    var response = await apiResponse.Content.ReadAsStringAsync();
                    returnResponse = JsonConvert.DeserializeObject<ProdutoConsumido>(response) ?? new ProdutoConsumido();
                }

                return returnResponse;
            }
        }
        catch (Exception ex) {

            string msg = ex.Message;

            await MainThread.InvokeOnMainThreadAsync(async () => {
                await App.Current.MainPage.DisplayAlert("Erro", msg, "OK");
            });
        }

        return returnResponse;
    }

    public async Task<List<ProdutoConsumido>> GetConsumoByUserId(int id) {

        var returnResponse = new List<ProdutoConsumido>();

        try {

            base_url = await SecureStorage.GetAsync("servidor");

            if (string.IsNullOrEmpty(base_url)) {

                throw new Exception("Base URL não encontrada no SecureStorage.");
            }

            using (var client = new HttpClient()) {

                var url = $"{base_url}/Consumo/Usuario/{id}";
                var apiResponse = await client.GetAsync(url);

                if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK) {

                    var response = await apiResponse.Content.ReadAsStringAsync();
                    returnResponse = JsonConvert.DeserializeObject<List<ProdutoConsumido>>(response) ?? new List<ProdutoConsumido>();
                }

                return returnResponse;
            }
        }
        catch (Exception ex) {

            string msg = ex.Message;

            await MainThread.InvokeOnMainThreadAsync(async () => {
                await App.Current.MainPage.DisplayAlert("Erro", msg, "OK");
            });
        }

        return returnResponse;
    }

    public async Task<bool> UpdateConsumo(ProdutoConsumido consumo) {

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

                var apiResponse = await client.PutAsync(url, content); 

                if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK) {

                    returnResponse = true;
                }

                return returnResponse;
            }
        }
        catch (Exception ex) {

            string msg = ex.Message;

            await MainThread.InvokeOnMainThreadAsync(async () => {
                await App.Current.MainPage.DisplayAlert("Erro", msg, "OK");
            });
        }

        return returnResponse;
    }
}
