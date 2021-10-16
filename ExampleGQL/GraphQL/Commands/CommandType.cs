using System.Linq;
using ExampleGQL.Data;
using ExampleGQL.Entities;
using HotChocolate;
using HotChocolate.Types;

namespace ExampleGQL.GraphQL.Commands
{
    public class CommandType : ObjectType<Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor.Description("Represents any executable command");

            descriptor.Field(x => x.Platform)
                .ResolveWith<Resolvers>(x => x.GetPlatform(default!, default!))
                .UseDbContext<AppDataContext>()
                .Description("This is the platform to which the command belongs");
        }

        private class Resolvers
        {
            public Platform GetPlatform([Parent] Command command, [ScopedService] AppDataContext context)
            {
                return context.Platforms.FirstOrDefault(x => x.Id == command.PlatformId);
            }
        }
    }
}