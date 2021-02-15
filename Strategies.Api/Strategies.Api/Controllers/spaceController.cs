using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Strategies.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Strategies.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class spaceController : ControllerBase
    {
        protected readonly ILaunchRepo _launchRepo;
        protected readonly ILogger<spaceController> _logger;
        protected readonly IRocketRepo _rocketRepo;

        public spaceController(ILogger<spaceController> logger, ILaunchRepo launchRepo, IRocketRepo rocketRepo)
        {
            _launchRepo = launchRepo;
            _logger = logger;
            _rocketRepo = rocketRepo;
        }

        [HttpGet("launches")]
        [Produces("application/json", Type = typeof(IEnumerable<Launch>))]
        public async Task<IEnumerable<Launch>> GetLaunchesAsync()
        {
            var returnValue = await _launchRepo.GetUpcomingLaunchesAsync();
            return returnValue;
        }

        [HttpGet("rockets")]
        [Produces("application/json", Type = typeof(IEnumerable<Rocket>))]
        public async Task<IEnumerable<Rocket>> GetRocketsAsync()
        {
            var returnValue = await _rocketRepo.GetRocketsAsync();
            return returnValue;
        }

        [HttpGet("rocketLaunches")]
        [Produces("application/json", Type = typeof(IEnumerable<Rocket>))]
        public IEnumerable<Rocket> GetRocketLaunches()
        {
            List<Rocket> returnValue = null;
            List<Launch> launches = null;

            var threads = new List<Thread>();

            threads.Add(new Thread(() =>
            {
                returnValue = _rocketRepo.GetRocketsAsync().Result;
            }));

            threads.Add(new Thread(() =>
            {
                launches = _launchRepo.GetUpcomingLaunchesAsync().Result;
            }));

            threads.ForEach(t => t.Start());
            threads.ForEach(t => t.Join());

            if (null == launches)
            {
                _logger?.LogDebug("No Launches");
            }
            else
            {
                returnValue.ForEach(r =>
                {
                    r.Launches = launches.Where(l => l.rocket == r.id).ToList();
                });
            }

            return returnValue;
        }
    }
}
