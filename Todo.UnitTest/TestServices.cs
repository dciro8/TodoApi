using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Todo.UnitTest
{
    public class TestServices : IDisposable
    {

        private readonly TestServer _testSserver;
        public TestServices()
        {
            var webBuilder = new WebHostBuilder();
            webBuilder.UseStartup<Startup>();
            _testSserver = new TestServer(webBuilder);
        }

        public void Dispose()
        {
            _testSserver.Dispose();
        }

        [Fact]
        public async Task TestConsept()
        {
            var response = await _testSserver.CreateRequest("/api/TodoItems/GetTodoItems").SendAsync("GET");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        public static IEnumerable<object[]> TestData => new[]
        {
            new object[] { 1, "pruebadciro11", true},

            new object[] { 2, "pruebadciro22", false  },

            new object[] { 3, "pruebadciro33", true }
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public async Task TestCreateMethodToParameter(int id, string name, bool isComple)
        {
            //ARRANGE
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/TodoItems/CreateItemAsync");
            var client = _testSserver.CreateClient();

            //ACT
            request.Content = new StringContent(JsonConvert.SerializeObject(new Dictionary<string, object> {
                {"Id",id},
                {"Name", name},
                {"IsComplete", isComple}
            }), Encoding.Default, "application/json");

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.SendAsync(request);

            //client = _testSserver.CreateClient();
            //client.DefaultRequestHeaders.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //request = new HttpRequestMessage(HttpMethod.Get, "/api/TodoItems/GetTodoItems");
            //response = await client.SendAsync(request);
            response = await _testSserver.CreateRequest(response.Headers.Location.AbsolutePath).SendAsync("GET");
            //ASSERT
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        public class TestDataCalls : IEnumerable<object[]>
        {
            private readonly List<object[]> _testData = new List<object[]>
        {
            new object[] { 1, "pruebadciro111", true},

            new object[] { 2, "pruebadciro222", false  },

            new object[] { 3, "pruebadciro333", true }
        };
            public IEnumerator<object[]> GetEnumerator() => _testData.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        [Theory]
        [ClassData(typeof(TestDataCalls))]
        public async Task TestCreateMethodToCalss(int id, string name, bool isComple)
        {
            //ARRANGE
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/TodoItems/CreateItemAsync");
            var client = _testSserver.CreateClient();

            //ACT
            request.Content = new StringContent(JsonConvert.SerializeObject(new Dictionary<string, object> {
                {"Id",id},
                {"Name", name},
                {"IsComplete", isComple}
            }), Encoding.Default, "application/json");

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.SendAsync(request);

            //client = _testSserver.CreateClient();
            //client.DefaultRequestHeaders.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //request = new HttpRequestMessage(HttpMethod.Get, "/api/TodoItems/GetTodoItems");
            //response = await client.SendAsync(request);
            response = await _testSserver.CreateRequest(response.Headers.Location.AbsolutePath).SendAsync("GET");
            //ASSERT
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData(1, "pruebadciro1", true)]

        [InlineData(2,"pruebadciro2",true)]

        [InlineData(3, "pruebadciro3", false)]
        public async Task TestCreateMethod(int id, string name, bool isComple)
        {
            //ARRANGE
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/TodoItems/CreateItemAsync");
            var client = _testSserver.CreateClient();

            //ACT
            request.Content = new StringContent(JsonConvert.SerializeObject(new Dictionary<string, object> {
                {"Id",id},
                {"Name", name},
                {"IsComplete", isComple}
            }), Encoding.Default, "application/json");

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.SendAsync(request);

            //client = _testSserver.CreateClient();
            //client.DefaultRequestHeaders.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //request = new HttpRequestMessage(HttpMethod.Get, "/api/TodoItems/GetTodoItems");
            //response = await client.SendAsync(request);
            response = await _testSserver.CreateRequest(response.Headers.Location.AbsolutePath).SendAsync("GET");
            //ASSERT
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task TestCreateMethod1()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/TodoItems/CreateItemAsync");

            request.Content = new StringContent(JsonConvert.SerializeObject(new Dictionary<string, object> {

            {"Id", 1},
              {"Name", "David"},
              {"IsComplete", true}

            }), Encoding.Default, "application/json");


            var client = _testSserver.CreateClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                var response = await client.SendAsync(request);
                response = await _testSserver.CreateRequest("/api​/TodoItems/1").SendAsync("GET");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
