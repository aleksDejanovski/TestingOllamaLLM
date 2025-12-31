using System.Text.Json;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace TestingOllamaLLM
{
    public abstract class BaseClass
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<string> CreateRequestForOllama(string promptMessage)
        {
            var requestBody = new
            {
                model = "gemma3:4b",
                prompt = promptMessage,
                stream = false
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("http://localhost:11434/api/generate", content);
            response.EnsureSuccessStatusCode();

            var responseText = await response.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(responseText);
            string output = doc.RootElement.GetProperty("response").GetString();

            return output;
        }

        public void CheckResponseContent(string responseText, string expectedValue)
        {
            if (!responseText.ToLower().Contains(expectedValue.ToLower()))
            {
                throw new Exception($"Test failed: expected '{expectedValue}' not found in response.");
            }

            Console.WriteLine("✅ Test passed");
        }
    }

}
