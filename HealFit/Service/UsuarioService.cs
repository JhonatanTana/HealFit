using HealFit.Model;
using Newtonsoft.Json;
using System.Text;

namespace HealFit.Service;
public class UsuarioService : IUsuarioService {

    private string? base_url;
    private Page _page;

    public async Task<int?> VerificaUsuario(Usuario usuario) {

        int? usuarioId = null;

        try {

            base_url = await SecureStorage.GetAsync("servidor");

            if (string.IsNullOrEmpty(base_url)) {
                throw new Exception("Base URL não encontrada no SecureStorage.");
            }

            using (var client = new HttpClient()) {
                var url = $"{base_url}/usuario/login";

                var serializeContent = JsonConvert.SerializeObject(usuario);
                var apiResponse = await client.PostAsync(url, new StringContent(serializeContent, Encoding.UTF8, "application/json"));

                if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK) {
                    var response = await apiResponse.Content.ReadAsStringAsync();
                    var deserializeResponse = JsonConvert.DeserializeObject<Usuario>(response);

                    if (deserializeResponse != null) {

                        usuarioId = deserializeResponse.UsuarioId;
                    }
                }
            }

        }
        catch (Exception ex) {

            string msg = ex.Message;

            await MainThread.InvokeOnMainThreadAsync(async () => {
                await App.Current.MainPage.DisplayAlert("Erro", msg, "OK");
            });
        }

        return usuarioId;
    }

    public async Task<Usuario> GetUsuarioById(int id) {

        var returnResponse = new Usuario();

        try {

            base_url = await SecureStorage.GetAsync("servidor");

            if (string.IsNullOrEmpty(base_url)) {
                throw new Exception("Base URL não encontrada no SecureStorage.");
            }

            using (var client = new HttpClient()) {
                var url = $"{base_url}/Usuario/{id}";
                var apiResponse = await client.GetAsync(url);

                if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK) {
                    var response = await apiResponse.Content.ReadAsStringAsync();
                    returnResponse = JsonConvert.DeserializeObject<Usuario>(response) ?? new Usuario();
                }
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

    public async Task<bool> UpdateUsuario(Usuario usuario) {

        var returnResponse = false;

        try {

            base_url = await SecureStorage.GetAsync("servidor");

            if (string.IsNullOrEmpty(base_url)) {

                throw new Exception("Base URL não encontrada no SecureStorage.");
            }

            using (var client = new HttpClient()) {

                var url = $"{base_url}/Usuario/RedefinirSenha"; 

                var serializeContent = JsonConvert.SerializeObject(usuario);
                var content = new StringContent(serializeContent, Encoding.UTF8, "application/json");

                var apiResponse = await client.PutAsync(url, content); 

                if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK) {

                    returnResponse = true;
                }
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

    public async Task<Usuario> AddUsuario(Usuario usuario) {

        var returnResponse = new Usuario();

        try {
            base_url = await SecureStorage.GetAsync("servidor");

            if (string.IsNullOrEmpty(base_url)) {
                throw new Exception("Base URL não encontrada no SecureStorage.");
            }

            using (var client = new HttpClient()) {

                var url = $"{base_url}/Usuario/Registro";

                var serializeContent = JsonConvert.SerializeObject(usuario);
                var content = new StringContent(serializeContent, Encoding.UTF8, "application/json");

                var apiResponse = await client.PostAsync(url, content);

                if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK) {

                    var responseString = await apiResponse.Content.ReadAsStringAsync();
                    returnResponse = JsonConvert.DeserializeObject<Usuario>(responseString) ?? new Usuario();
                }
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

    public async Task<bool> DeleteUsuario(int id) {
        var returnResponse = false;

        try {
            base_url = await SecureStorage.GetAsync("servidor");

            if (string.IsNullOrEmpty(base_url)) {
                throw new Exception("Base URL não encontrada no SecureStorage.");
            }

            using (var client = new HttpClient()) {
                var url = $"{base_url}/Usuario/{id}";

                var apiResponse = await client.DeleteAsync(url);

                if (apiResponse.StatusCode == System.Net.HttpStatusCode.NoContent) {
                    returnResponse = true; // Success if the user was deleted
                }
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

    public async Task<List<Usuario>> GetAllUsuarios() {

        var returnResponse = new List<Usuario>();

        try {

            base_url = await SecureStorage.GetAsync("servidor");

            if (string.IsNullOrEmpty(base_url)) {
                throw new Exception("Base URL não encontrada no SecureStorage.");
            }

            using (var client = new HttpClient()) {

                var url = $"{base_url}/Usuario";
                var apiResponse = await client.GetAsync(url);

                if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK) {

                    var response = await apiResponse.Content.ReadAsStringAsync();
                    returnResponse = JsonConvert.DeserializeObject<List<Usuario>>(response) ?? new List<Usuario>();
                }
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
