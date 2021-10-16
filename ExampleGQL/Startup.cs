using ExampleGQL.Data;
using ExampleGQL.GraphQL;
using ExampleGQL.GraphQL.Commands;
using ExampleGQL.GraphQL.Platforms;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ExampleGQL
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Enable DI to make multiple instances of DbContext.
            // Allows for parallel querying.
            services.AddPooledDbContextFactory<AppDataContext>(opt =>
                opt.UseInMemoryDatabase(_configuration.GetConnectionString("InMemoryGraphQL")));

            services.AddControllers();
            services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddType<PlatformType>()
                .AddType<CommandType>()
                .AddFiltering()
                .AddSorting();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                var factory = app.ApplicationServices.CreateScope()
                    .ServiceProvider.GetService<IDbContextFactory<AppDataContext>>();
                using var context = factory?.CreateDbContext();
                Seed.SeedDatabase(context);
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGraphQL();
                endpoints.MapGraphQLVoyager();
            });
        }
    }
}