using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HealFit.DTO.Response;

namespace HealFit.Service; 
public class CepService {

    private readonly HttpClient _httpClient;

    public CepService(HttpClient httpClient) {
        _httpClient = httpClient;
    }

    public async Task<CepResponse> GetCepInfo(string cep) {
        return await _httpClient.GetFromJsonAsync<CepResponse>($"https://viacep.com.br/ws/{cep}/json/");
    }
}
