using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using TodoApi.Core.Entities;
using TodoApi.Core.Services;

namespace Todo.UnitTest
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
            services.AddDbContext<TodoContext>(opt =>
            {
                //Temporal por si no se crean mas isntancias de la misma base de datos
                //opt.UseInMemoryDatabase("TodoList"));
                opt.UseInMemoryDatabase("TodoList" + Guid.NewGuid());
            }, ServiceLifetime.Singleton
            );
            services.AddScoped<ITodoItemService, TodoItemService>();
            services.AddControllers().AddApplicationPart(Assembly.Load("TodoApi")).AddControllersAsServices();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
