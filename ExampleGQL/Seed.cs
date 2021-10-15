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
        }

        private static void SeedPlatforms(AppDataContext context)
        {
            var platforms = context.Platforms;
            if (platforms.Any()) return;

            platforms.Add(new Platform {Name = ".NET 5"});
            platforms.Add(new Platform {Name = "Docker"});
            platforms.Add(new Platform {Name = "Windows", LicenseKey = "987987987"});

            context.SaveChanges();
        }
    }
}