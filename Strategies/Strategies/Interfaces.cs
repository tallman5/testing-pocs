using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Strategies
{
    public interface IItem
    {
        Guid ItemId { get; set; }
    }

    public interface ILaunchRepo
    {
        Task<List<Launch>> GetUpcomingLaunchesAsync();
    }

    public interface IRocketRepo
    {
        Task<List<Rocket>> GetRocketsAsync();
    }
}
