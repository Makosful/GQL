using System.Threading.Tasks;
using ExampleGQL.Data;
using ExampleGQL.Entities;
using ExampleGQL.GraphQL.Commands;
using ExampleGQL.GraphQL.Platforms;
using HotChocolate;
using HotChocolate.Data;

namespace ExampleGQL.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(AppDataContext))]
        public async Task<AddPlatformPayload> AddPlatformAsync(AddPlatformInput input,
            [ScopedService] AppDataContext context)
        {
            var platform = new Platform
            {
                Name = input.Name
            };

            context.Platforms.Add(platform);
            await context.SaveChangesAsync();
            return new AddPlatformPayload(platform);
        }

        [UseDbContext(typeof(AppDataContext))]
        public async Task<AddCommandPayload> AddCommandAsync(AddCommandInput input,
            [ScopedService] AppDataContext context)
        {
            var command = new Command
            {
                CommandLine = input.CommandLine,
                HowTo = input.HowTo,
                PlatformId = input.PlatformId
            };

            context.Commands.Add(command);
            await context.SaveChangesAsync();
            return new AddCommandPayload(command);
        }
    }
}