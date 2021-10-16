using System.Linq;
using ExampleGQL.Data;
using ExampleGQL.Entities;
using HotChocolate;
using HotChocolate.Data;

namespace ExampleGQL.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDataContext))] // Parallel query support
        public IQueryable<Platform> GetPlatform([ScopedService] AppDataContext context)
        {
            return context.Platforms;
        }
    }
}