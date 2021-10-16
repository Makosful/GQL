using ExampleGQL.Entities;
using HotChocolate;
using HotChocolate.Types;

namespace ExampleGQL.GraphQL
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Platform OnPlatformAdded([EventMessage] Platform platform) => platform;
    }
}