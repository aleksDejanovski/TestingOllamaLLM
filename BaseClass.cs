using System.Text.Json;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using TestingOllamaLLM.Models;

namespace TestingOllamaLLM
{
    public abstract class BaseClass
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _response;
        private string _responseText;

        public async Task CreateRequestForOllama(string promptMessage)
        {
            var requestBody = new
            {
                model = "gemma3:4b",
                prompt = promptMessage,
                stream = false
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            _response = await _httpClient.PostAsync("http://localhost:11434/api/generate", content);
            _response.EnsureSuccessStatusCode();

            var responseText = await _response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<OllamaResponse>(responseText);

            _responseText = result.response; // ✅ store internally
        }

        public void CheckResponseStatusCode()
        {
            if (_response == null)
                throw new InvalidOperationException("No request was made.");

            if (!_response.IsSuccessStatusCode)
                throw new Exception($"Request failed with status {_response.StatusCode}");

            Console.WriteLine("✅ HTTP status OK");
        }

        public void CheckResponseContent(string expectedValue)
        {
            if (string.IsNullOrEmpty(_responseText))
                throw new InvalidOperationException("No response content available.");

            if (!_responseText.ToLower().Contains(expectedValue.ToLower()))
                throw new Exception($"Test failed: expected '{expectedValue}' not found.");

            Console.WriteLine("✅ Content validation passed");
        }


    }
}
