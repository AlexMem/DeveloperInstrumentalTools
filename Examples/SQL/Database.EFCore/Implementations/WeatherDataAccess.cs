using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Database.EFCore.Contracts;
using Database.EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.EFCore.Implementations
{
    public class WeatherDataAccess : IWeatherDataAccess
    {
        private ExampleContext ExampleContext { get; }
        
        public WeatherDataAccess(ExampleContext exampleContext)
        {
            ExampleContext = exampleContext;
        }

        public async Task<IEnumerable<WeatherEntity>> GetAllAsync(CancellationToken ct = default)
        {
            return await this.ExampleContext.Weathers
                .Include(x => x.Summary)
                .OrderBy(x => x.TimeStamp)
                .ToListAsync(ct);
        }
    }
}