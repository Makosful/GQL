using System;
using System.Linq;
using ExampleGQL.Data;
using ExampleGQL.Entities;

namespace ExampleGQL
{
    public static class Seed
    {
        public static void SeedDatabase(AppDataContext context)
        {
            if (context is null) throw new ArgumentNullException(nameof(context));

            SeedPlatforms(context);

            SeedCommands(context);
        }

        private static void SeedCommands(AppDataContext context)
        {
            var commands = context.Commands;
            if (commands.Any()) return;

            commands.Add(new Command
            {
                Id = 1,
                PlatformId = 1,
                CommandLine = "dotnet build",
                HowTo = "Build a project"
            });
            commands.Add(new Command
            {
                Id = 2,
                PlatformId = 1,
                CommandLine = "dotnet run",
                HowTo = "Run a project"
            });
            commands.Add(new Command
            {
                Id = 3,
                PlatformId = 2,
                CommandLine = "docker-compose up",
                HowTo = "Start a docker compose file"
            });
            commands.Add(new Command
            {
                Id = 4,
                PlatformId = 2,
                CommandLine = "docker-compose down",
                HowTo = "Stop a docker compose file"
            });

            context.SaveChanges();
        }

        private static void SeedPlatforms(AppDataContext context)
        {
            var platforms = context.Platforms;
            if (platforms.Any()) return;

            platforms.Add(new Platform {Id = 1, Name = ".NET 5"});
            platforms.Add(new Platform {Id = 2, Name = "Docker"});
            platforms.Add(new Platform {Id = 3, Name = "Windows", LicenseKey = "987987987"});

            context.SaveChanges();
        }
    }
}