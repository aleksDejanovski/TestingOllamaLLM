using System.Text.Json;
using System.Text;

namespace TestingOllamaLLM
{
    public class TetingOllamaLLM : BaseClass
    {
        [Fact]
        public async Task TestingCapitalOfFrance()
        {
            string response = await CreateRequestForOllama("What is the capital of France?");
            CheckResponseContent(response, "paris");
        }

        [Fact]
        public async Task TestingCapitalOfSerbia()
        {
            string response = await CreateRequestForOllama("What is the capital of Serbia?");
            CheckResponseContent(response, "belgrade");
        }

        [Fact]
        public async Task TestingCapitalOfSpain()
        {
            string response = await CreateRequestForOllama("What is the capital of Spain?");
            CheckResponseContent(response, "madrid");
        }
    }
}