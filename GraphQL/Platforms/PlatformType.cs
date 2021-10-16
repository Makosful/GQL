using System.Linq;
using ExampleGQL.Data;
using ExampleGQL.Entities;
using HotChocolate;
using HotChocolate.Types;

namespace ExampleGQL.GraphQL.Platforms
{
    public class PlatformType : ObjectType<Platform>
    {
        protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
        {
            descriptor.Description("Represents any software or service that has a command line interface.");

            descriptor.Field(x => x.LicenseKey).Ignore();

            descriptor.Field(x => x.Commands)
                .ResolveWith<Resolvers>(x => x.GetCommands(default!, default!))
                .UseDbContext<AppDataContext>()
                .Description("This is the list of available commands for this platform");
        }

        private class Resolvers
        {
            public IQueryable<Command> GetCommands([Parent] Platform platform, [ScopedService] AppDataContext context)
            {
                return context.Commands.Where(command => command.PlatformId == platform.Id);
            }
        }
    }
}