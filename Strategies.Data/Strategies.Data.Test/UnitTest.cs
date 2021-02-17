using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace Strategies.Data.Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public async Task GetRocketsAsync()
        {
            var builder = new DbContextOptionsBuilder<StratContext>()
                .UseInMemoryDatabase("strat-in-mem-db");

            using StratContext stratContext = new StratContext(builder.Options);

            var rockets = await stratContext.GetRocketsAsync();

            Assert.IsNotNull(rockets);
            Assert.IsTrue(rockets.Count == 4);
        }
    }
}
