

using Castle.Core.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using TodoApi.Core.Entities;
using TodoApi.Core.Services;

namespace Todo.Xunit
{
    public class Start
    {

        public Start(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.adcon().addcontrol
            services.AddDbContext<TodoContext>();

            services.AddScoped<ITodoItemService, TodoItemService>();

            //services.AddControllers();
            //services.AddSwaggerGen(c =>
            //{
            //	c.SwaggerDoc("v1", new OpenApiInfo { Title = "TodoApi", Version = "v1" });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {

        }
    }
}
