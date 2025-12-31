using System.Text.Json;
using System.Text;
using TestingOllamaLLM.Models;

namespace TestingOllamaLLM.Basics
{
    public abstract class BaseClass
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _response;
        private string _responseText;

        protected async Task CreateRequestForOllama(string promptMessage)
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

            var responseValue = await _response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<OllamaResponse>(responseValue);

            _responseText = result.response;
        }


        protected void CheckResponseStatusCode(int expectedStatusCode)
        {
            Assert.NotNull(_response);

            int actualStatusCode = (int)_response.StatusCode;

            Assert.True(
                actualStatusCode == expectedStatusCode,
                $"Expected status code {expectedStatusCode}, but got {actualStatusCode}"
            );
        }

        protected void CheckResponseContent(string expectedValue)
        {
            if (string.IsNullOrEmpty(_responseText))
                throw new InvalidOperationException("No response content available.");
            Assert.Contains(expectedValue.ToLower(), _responseText.ToLower());

            Console.WriteLine("✅ Content validation passed");
        }

        protected void CheckResponseContentDoesNotHave(string expectedValue)
        {
            if (string.IsNullOrEmpty(_responseText))
                throw new InvalidOperationException("No response content available.");
            Assert.DoesNotContain(expectedValue.ToLower(), _responseText.ToLower());
            Console.WriteLine("✅ Content is not contained");
        }


    }
}
