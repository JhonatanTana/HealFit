using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json; // Certifique-se de incluir esta referência

public class TranslationService {
    private readonly HttpClient _httpClient;

    public TranslationService(HttpClient httpClient) {
        _httpClient = httpClient;
    }

    public async Task<string> TranslateAsync(string text, string targetLanguage) {
        var url = $"https://api.cognitive.microsofttranslator.com/translate?api-version=3.0&to={targetLanguage}";

        var request = new HttpRequestMessage(HttpMethod.Post, url);
        request.Headers.Add("Ocp-Apim-Subscription-Key", "BsWwi6JkO12z1gejxfRwKuU0Sx9ewsSAUK7rZnqENHTJIBazyh3qJQQJ99AJACZoyfiXJ3w3AAAbACOGpDbM"); // Substitua pela sua chave
        request.Headers.Add("Ocp-Apim-Subscription-Region", "brazilsouth"); // Altere conforme necessário

        var content = new StringContent($"[{{\"Text\":\"{text}\"}}]", Encoding.UTF8, "application/json");
        request.Content = content;

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        // Ler o conteúdo da resposta
        var jsonResponse = await response.Content.ReadAsStringAsync();

        // Extrair o texto traduzido
        using (JsonDocument doc = JsonDocument.Parse(jsonResponse)) {
            // A resposta geralmente é uma matriz, então pegamos o primeiro elemento
            var translatedText = doc.RootElement[0].GetProperty("translations")[0].GetProperty("text").GetString();
            return translatedText;
        }
    }
}
