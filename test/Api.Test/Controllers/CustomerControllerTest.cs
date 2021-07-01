using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace Api.Test.Controllers
{
    public class CustomerControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

        public CustomerControllerTest(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async Task Get_リクエストが正しい場合はHttpStatusCode200が返却される()
        {
            var body = new CustomerRequest() { };
            var uri = "/api/v1/customers/search";

            using (var client = factory.CreateClient())
            {
                var response = await client.PostAsJsonAsync(uri, body);

                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        class CustomerRequest
        {
            private static string ShopCode { get; set; }
        }
    }
}
