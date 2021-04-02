using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;
using web_api;
using web_api.ViewModels;
using Xunit;
using MediaTypeHeaderValue = System.Net.Http.Headers.MediaTypeHeaderValue;

namespace MainUnitTests.Integration.Controllers
{
    public class ProductControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ProductControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAllProduct_With_No_Auth()
        {
            var httpResponse = await _client.GetAsync("products/list");
            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<Product>(stringResponse);
            Assert.NotNull(product);
            Assert.Equal(1, product.Id);
        }

        [Fact]
        public async Task Auth()
        {
            var user = new User
            {
                Username = "goku",
                Password = "goku",
            };
            var myContent = JsonConvert.SerializeObject(user);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //testing get with NO auth
            var httpResponse = await _client.PostAsync("/api/Auth/login", byteContent);
            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<AuthResponse>(stringResponse);
            Assert.NotNull(response);
            Assert.NotEmpty(response.Token);
        }


        [Fact]
        public async Task GetOneProduct_With_Auth()
        {
            /* auth */
            var user = new User
            {
                Username = "goku",
                Password = "goku",
            };
            var myContent = JsonConvert.SerializeObject(user);//converting c# object to json object
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            //add header that it's json
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //send post with content
            var httpResponse = await _client.PostAsync("/api/Auth/login", byteContent);
            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            //десериализуй в свой обьект, смотри какой обьект возвращает логин
            var response = JsonConvert.DeserializeObject<AuthResponse>(stringResponse);

            /*auth end*/

            //testing get with auth
            _client.DefaultRequestHeaders.Clear();
            //из обьекта берешь токен и говоришь что это JWT авторизация
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", response.Token);

            httpResponse = await _client.GetAsync("products/view/1");
            httpResponse.EnsureSuccessStatusCode();
            stringResponse = string.Empty;
            stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<Product>(stringResponse);
            Assert.NotNull(product);
            Assert.Equal(1, product.Id);
        }


    }

    public class AuthResponse
    {
        public User User { get; set; }
        public string Token { get; set; }
    }
}
