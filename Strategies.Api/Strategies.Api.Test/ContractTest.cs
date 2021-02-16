using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Strategies.Api.Test
{
    [TestClass]
    public class ContractTest
    {
        [TestMethod]
        public async Task CheckLaunchDependenciesAsync()
        {
            using var httpClient = new HttpClient();
            var httpResponseMessage = await httpClient.GetAsync("https://api.spacexdata.com/v4/launches/upcoming");
            httpResponseMessage.EnsureSuccessStatusCode();
            var contentString = await httpResponseMessage.Content.ReadAsStringAsync();
            var launches = JsonSerializer.Deserialize<List<Launch>>(
                contentString,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            Assert.IsNotNull(launches);
            Assert.IsTrue(launches.Count > 0);
        }
    }
}
