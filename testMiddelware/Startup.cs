using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using testMiddelware.classes;
using testMiddelware.filters;

namespace testMiddelware
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup()
        {
            var builder = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json");
            Configuration = builder.Build();

        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            var cof = Configuration.GetSection("information");
            services.Configure<ClassTest>(cof);

            string connection = Configuration.GetConnectionString("services");
            services.AddDbContext<DataBase>(option => option.UseNpgsql(connection));

            var ind = Configuration.GetSection("Admin");
            services.Configure<indentity>(ind);

            services.AddScoped<ActionFilter>();
            services.AddScoped<ValidationFilter>(); 
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
   
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           /* app.Run(context =>
            {
                var n = Configuration["information:name"];
                var l = Configuration["information : lastname"];
                //context.Response.WriteAsync(/br);
                context.Response.WriteAsync($"defult name is: {n}");
                context.Response.WriteAsync($"defult lastname is: {l}" );
                return context.Response.WriteAsync("down");
            });*/

          /*  app.Use(async (context, next) =>
            {
                
                await context.Response.WriteAsync("Before Invoke from 1st app.Use()\n");
                await next();
                await context.Response.WriteAsync("After Invoke from 1st app.Use()\n");
                
            });
           
            app.Use(async (context, next) =>
            {
                StringValues x ;
                context.Request.Headers.TryGetValue("User-Agent", out x);
                Console.WriteLine(x.ToString());
                await context.Response.WriteAsync("Before Invoke from 2nd app.Use()\n");
                await next();
                await context.Response.WriteAsync("After Invoke from 2nd app.Use()\n");
            });
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello from 1st app.Run()\n");
            });
             app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello from 2nd app.Run()\n");
            });
          */
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
