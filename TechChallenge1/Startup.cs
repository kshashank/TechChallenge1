using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;

namespace TechChallenge1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("TST"));
            services.AddMvc();
            services.AddControllers();
            services.AddScoped<ApiContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var context = app.ApplicationServices.GetService<ApiContext>();
            AddTestData(context);
        }

        private static void AddTestData(ApiContext context)
        {
            List<Server> servers = new List<Server>
            {
                new Server { Date = DateTime.Now.ToShortDateString(), ServerName = "TST1", Status = "Online" },
                 new Server { Date = DateTime.Now.ToShortDateString(), ServerName = "TST2", Status = "Online" },
                  new Server { Date = DateTime.Now.ToShortDateString(), ServerName = "TST3", Status = "Online" },
                new Server { Date = DateTime.Now.AddDays(-1).ToShortDateString(), ServerName = "TST1", Status = "Online" },
                  new Server { Date = DateTime.Now.AddDays(-1).ToShortDateString(), ServerName = "TST2", Status = "Offline" },
                    new Server { Date = DateTime.Now.AddDays(-1).ToShortDateString(), ServerName = "TST3", Status = "Online" },
                     new Server { Date = DateTime.Now.AddDays(-2).ToShortDateString(), ServerName = "TST1", Status = "Online" },
                  new Server { Date = DateTime.Now.AddDays(-2).ToShortDateString(), ServerName = "TST2", Status = "Offline" },
                    new Server { Date = DateTime.Now.AddDays(-2).ToShortDateString(), ServerName = "TST3", Status = "Offline" }
            };

            foreach (Server server in servers)
            {
                context.Servers.Add(server);
            }

            context.SaveChanges();
        }
    }
}
