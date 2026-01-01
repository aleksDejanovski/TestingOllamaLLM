using TestingOllamaLLM.Basics;

namespace TestingOllamaLLM.Tests
{
    public class TestingOllamaLLM_FromFile : BaseClass
    {
        [Theory]
        [MemberData(nameof(GetTestData))]
        public async Task TestOllamaUsingFile(string question, string expectedAnswer)
        {
            await CreateRequestForOllama(question);
            CheckResponseStatusCode(200);
            CheckResponseContent(expectedAnswer);
        }
    }
}
