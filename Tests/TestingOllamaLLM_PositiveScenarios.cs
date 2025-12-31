using System.Text.Json;
using System.Text;
using TestingOllamaLLM.Basics;

namespace TestingOllamaLLM.Tests
{
    public class TestingOllamaLLM_PositiveScenarios : BaseClass
    {
        [Fact]
        public async Task TestingCapitalOfFrance()
        {
            await CreateRequestForOllama("What is the capital of France?");
            CheckResponseStatusCode(200);
            CheckResponseContent("paris");
        }

        [Fact]
        public async Task TestingCapitalOfSerbia()
        {
            await CreateRequestForOllama("What is the capital of Serbia?");
            CheckResponseStatusCode(200);
            CheckResponseContent("belgrade");
        }

        [Fact]
        public async Task TestingCapitalOfSpain()
        {
            await CreateRequestForOllama("What is the capital of Spain?");
            CheckResponseStatusCode(200);
            CheckResponseContent("madrid");
            CheckResponseContentDoesNotHave("barcelona");
        }

        [Fact]
        public async Task CheckPresiedentOfUSA_2023Model()
        {
            await CreateRequestForOllama("Who is the current US president?");
            CheckResponseStatusCode(200);
            CheckResponseContent("Joe Biden");
        }

        [Fact]
        public async Task CheckCapitalOfCroatiaOnMacedonianLanguage()
        {
            await CreateRequestForOllama("Koj e glaven grad na Hrvatska");
            CheckResponseStatusCode(200);
            CheckResponseContent("Zagreb");
        }
        [Fact]
        public async Task CheckTallestMountainOnMacedonian()
        {
            await CreateRequestForOllama("koja e najvisoka planina na svetot");
            CheckResponseStatusCode(200);
            CheckResponseContent("Mount Everest");
        }

        [Fact]
        public async Task CheckWhyIsParacetamolUsed()
        {
            await CreateRequestForOllama("Why is paracetamol used? Give Short answer");
            CheckResponseStatusCode(200);
            CheckResponseContent("pain");
        }
    }
}