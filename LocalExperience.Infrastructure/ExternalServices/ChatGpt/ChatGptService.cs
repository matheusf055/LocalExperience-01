using Azure.Core;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LocalExperience.Infrastructure.ExternalServices.ChatGpt
{
    public class ChatGptService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public ChatGptService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["OpenAI:ApiKey"];
        }

        public async Task<string> GenerateItinerary(string prompt)
        {
            var request = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "user", content = prompt }
                },
                temperature = 0.7
            };

            var requestContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

            var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", requestContent);

            if (response.IsSuccessStatusCode == false) throw new Exception("Erro ao chamar a API do ChatGPT");

            var responseContent = await response.Content.ReadAsStringAsync();

            using var jsonDoc = JsonDocument.Parse(responseContent);
            var message = jsonDoc.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            return message!;
        }
    }
}
