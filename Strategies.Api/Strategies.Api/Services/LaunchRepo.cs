using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Strategies.Api.Services
{
    // This would typically be in a different project
    public class LaunchRepo : ILaunchRepo
    {
        public async Task<List<Launch>> GetUpcomingLaunchesAsync()
        {
            using HttpClient httpClient = new HttpClient();
            var httpResponseMessage = await httpClient.GetAsync("https://api.spacexdata.com/v4/launches/upcoming");
            httpResponseMessage.EnsureSuccessStatusCode();

            var contentString = await httpResponseMessage.Content.ReadAsStringAsync();
            var returnValue = JsonSerializer.Deserialize<List<Launch>>(
                contentString,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return returnValue;
        }
    }
}
