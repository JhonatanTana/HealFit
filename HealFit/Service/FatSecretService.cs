using HealFit.Model;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;

namespace HealFit.Service; 
public class FatSecretService {
    private readonly HttpClient _httpClient;
    private readonly string _consumerKey = ""; // Substitua pelo seu Consumer Key
    private readonly string _consumerSecret = ""; // Substitua pelo seu Consumer Secret

    public FatSecretService(HttpClient httpClient) {
        _httpClient = httpClient;
    }

    public async Task<string> SearchFoodsAsync(string searchExpression) {
        string signatureMethod = "HMAC-SHA1"; // Método de assinatura
        string version = "1.0";
        string nonce = Guid.NewGuid().ToString();
        string timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();

        var parameters = new SortedDictionary<string, string>
        {
        { "method", "foods.search" },
        { "format", "json" },
        { "search_expression", searchExpression },
        { "oauth_consumer_key", _consumerKey },
        { "oauth_signature_method", signatureMethod },
        { "oauth_timestamp", timestamp },
        { "oauth_nonce", nonce },
        { "oauth_version", version }
    };

        string baseString = GenerateBaseString("GET", "https://platform.fatsecret.com/rest/server.api", parameters);
        string signature = GenerateSignature(baseString, _consumerSecret);

        parameters.Add("oauth_signature", signature);

        var requestUri = $"https://platform.fatsecret.com/rest/server.api?{string.Join("&", parameters.Select(kvp => $"{Uri.EscapeDataString(kvp.Key)}={Uri.EscapeDataString(kvp.Value)}"))}";

        var request = new HttpRequestMessage(HttpMethod.Get, requestUri);

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();

        if (string.IsNullOrEmpty(jsonResponse)) {

            Console.WriteLine("A resposta da API está vazia.");
            return null; // Ou outra lógica que você preferir
        }

        return jsonResponse;

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