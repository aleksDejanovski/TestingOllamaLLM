using System.Text.Json;
using System.Text;

namespace TestingOllamaLLM
{
    public class TetingOllamaLLM : BaseClass
    {
        [Fact]
        public async Task TestingCapitalOfFrance()
        {
            await CreateRequestForOllama("What is the capital of France?");
            CheckResponseStatusCode();
            CheckResponseContent("paris");
        }

        [Fact]
        public async Task TestingCapitalOfSerbia()
        {
            await CreateRequestForOllama("What is the capital of Serbia?");
            CheckResponseStatusCode();
            CheckResponseContent("belgrade");
        }

        [Fact]
        public async Task TestingCapitalOfSpain()
        {
            await CreateRequestForOllama("What is the capital of Spain?");
            CheckResponseStatusCode();
            CheckResponseContent("madrid");
        }
    }
}