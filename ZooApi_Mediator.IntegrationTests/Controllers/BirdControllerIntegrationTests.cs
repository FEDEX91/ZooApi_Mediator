using System.Net.Http.Json;
using ZooApi_Mediator.Domain.Entities;

namespace ZooApi_Mediator.IntegrationTests.Controllers
{
    public class BirdControllerIntegrationTests(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client = factory.CreateClient();

        [Fact]
        public async Task GetAll_ReturnsSeededBirds()
        {
            // Act
            var response = await _client.GetAsync("/api/bird");
            response.EnsureSuccessStatusCode();
            var birds = await response.Content.ReadFromJsonAsync<List<Bird>>();

            // Assert
            Assert.NotNull(birds);
            Assert.Contains(birds, b => b.Name == "Sparrow");
            Assert.Contains(birds, b => b.Name == "Eagle");
        }
    }
}
