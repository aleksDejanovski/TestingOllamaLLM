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

        [Fact]
        public async Task CheckStarWarsMovies()
        {
            await CreateRequestForOllama("How many parts has the movie Star Wars. Give answer in a list starting from 1. Be short and dont give explanations. Give only the name of the movies.");
            CheckResponseStatusCode(200);
            CheckResponseContent("The Empire Strikes Back");
            CheckResponseContent("The Phantom Menace");
            CheckResponseContentDoesNotHave("Star Trek");
        }
        [Fact]
        public async Task CheckTennisPlayer()
        {
            await CreateRequestForOllama("which tennis playes has the most grand slams. Give me just his name not his surname?");
            CheckResponseStatusCode(200);
            CheckResponseContent("Novak");
            CheckResponseContentDoesNotHave("Djokovic");
        }
    }
}