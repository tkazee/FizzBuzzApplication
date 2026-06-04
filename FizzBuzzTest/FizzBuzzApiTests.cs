using FizzBuzz.Entity;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using Xunit;
    
namespace FizzBuzzTest
{
    public class FizzBuzzApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public FizzBuzzApiTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Post_ReturnsSuccessAndCorrectJson()
        {
            var content = JsonContent.Create(new[] { "1", "3", "5", "15" });
            var response = await _client.PostAsync("/api/fizzbuzz", content);

            response.EnsureSuccessStatusCode();
            var results = await response.Content.ReadFromJsonAsync<List<FizzBuzzResponse>>();

            Assert.Equal(4, results.Count);
            Assert.Equal("FizzBuzz", results.Last().Output);
        }
        [Fact]
        public async Task Post_ReturnStatusCode()
        {
            await using var app = new WebApplicationFactory<Program>();
            var content = JsonContent.Create(new[] { "1", "3", "5", "15","" });

            var response = await _client.PostAsync("/api/fizzbuzz", content);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
