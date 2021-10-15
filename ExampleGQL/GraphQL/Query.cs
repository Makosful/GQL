using System.Linq;
using ExampleGQL.Data;
using ExampleGQL.Entities;
using HotChocolate;

namespace ExampleGQL.GraphQL
{
    public class Query
    {
        public IQueryable<Platform> GetPlatform([Service] AppDataContext context)
        {
            return context.Platforms;
        }
    }
}