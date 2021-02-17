using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace Strategies.Api.Test
{
    [TestClass]
    public class ComponentTest
    {
        // Dependencies to be mocked

        private async Task<T> GetAsync<T>(string url)
        {
            using var httpClient = testServer.CreateClient();
            var rs = await httpClient.GetAsync(url);
            rs.EnsureSuccessStatusCode();
            var contentString = rs.Content.ReadAsStringAsync().Result;
            T returnValue = JsonSerializer.Deserialize<T>(
                contentString,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return returnValue;
        }

        [TestMethod]
        public void GetRocketLaunches()
        {
            var rs = GetAsync<List<Rocket>>("space/rocketLaunches").Result;
            Assert.IsNotNull(rs);
            Assert.IsTrue(rs.Count > 0);
        }

        [TestCleanup]
        public void Tc()
        {
            if (null != _testServer) _testServer.Dispose();
        }

        private TestServer _testServer;
        private TestServer testServer
        {
            get
            {
                if (null == _testServer)
                {
                    var settings = new List<KeyValuePair<string, string>>
                    {
                        //new KeyValuePair<string, string>("Key:SubKey", "SubKeyValue"),
                    };

                    var config = new ConfigurationBuilder()
                        .AddInMemoryCollection(settings)
                        .Build();

                    string contentRoot = Path.GetDirectoryName(Assembly.GetAssembly(typeof(Startup)).Location);

                    IWebHostBuilder builder = new WebHostBuilder()
                        .UseContentRoot(contentRoot)
                        .UseEnvironment("Development")
                        .UseStartup<Startup>()
                        .UseConfiguration(config);

                    _testServer = new TestServer(builder);
                }
                return _testServer;
            }
        }
    }
}
