using System.Security.Cryptography;
using System.Text;

public class FatSecretService {
    private readonly HttpClient _httpClient;
    private readonly string _consumerKey = ""; 
    private readonly string _consumerSecret = "";

    public FatSecretService(HttpClient httpClient) {
        _httpClient = httpClient;
    }

    // Função para pesquisar alimentos
    public async Task<string> SearchFoodsAsync(string searchExpression) {
        string endpoint = "https://platform.fatsecret.com/rest/server.api";
        var parameters = new SortedDictionary<string, string>
        {
            { "method", "foods.search" },
            { "format", "json" },
            { "search_expression", searchExpression }
        };

        return await SendRequestAsync(endpoint, parameters);
    }

    // Função para obter detalhes de um alimento por ID
    public async Task<string> GetFoodDetailsAsync(string foodId) {
        string endpoint = "https://platform.fatsecret.com/rest/food/v4";
        var parameters = new SortedDictionary<string, string>
        {
            { "food_id", foodId },
            { "format", "json" }
        };

        return await SendRequestAsync(endpoint, parameters);
    }

    // Função auxiliar para enviar a solicitação com os parâmetros OAuth
    private async Task<string> SendRequestAsync(string endpoint, SortedDictionary<string, string> parameters) {
        string signatureMethod = "HMAC-SHA1";
        string version = "1.0";
        string nonce = Guid.NewGuid().ToString();
        string timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();

        parameters.Add("oauth_consumer_key", _consumerKey);
        parameters.Add("oauth_signature_method", signatureMethod);
        parameters.Add("oauth_timestamp", timestamp);
        parameters.Add("oauth_nonce", nonce);
        parameters.Add("oauth_version", version);

        string baseString = GenerateBaseString("GET", endpoint, parameters);
        string signature = GenerateSignature(baseString, _consumerSecret);

        parameters.Add("oauth_signature", signature);

        var requestUri = $"{endpoint}?{string.Join("&", parameters.Select(kvp => $"{Uri.EscapeDataString(kvp.Key)}={Uri.EscapeDataString(kvp.Value)}"))}";

        var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }

    private string GenerateBaseString(string method, string url, SortedDictionary<string, string> parameters) {
        var parameterString = string.Join("&", parameters.Select(kvp => $"{Uri.EscapeDataString(kvp.Key)}={Uri.EscapeDataString(kvp.Value)}"));
        return $"{method.ToUpper()}&{Uri.EscapeDataString(url)}&{Uri.EscapeDataString(parameterString)}";
    }

    private string GenerateSignature(string baseString, string consumerSecret) {
        var key = $"{Uri.EscapeDataString(consumerSecret)}&"; // Token secret é vazio
        using (var hasher = new HMACSHA1(Encoding.ASCII.GetBytes(key))) {
            var hashBytes = hasher.ComputeHash(Encoding.ASCII.GetBytes(baseString));
            return Convert.ToBase64String(hashBytes);
        }
    }
}
