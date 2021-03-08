using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using apiAuth.Middleware;
using apiAuth.Repositories.Interfaces;
using apiAuth.Services;
using apiAuth.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace apiAuth
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
      StaticConfig = configuration;
    }

    public IConfiguration Configuration { get; }
    public static IConfiguration StaticConfig { get; private set; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers(options => options.Filters.Add<ValidationMiddleware>()).ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);
            // services.AddMvc(options => options.Filters.Add<ValidationMiddleware>());
            services.AddSwaggerGen(c =>
      {
        c.SchemaFilter<SwaggerSkipPropertyFilter >();
        c.SwaggerDoc("v1", new OpenApiInfo
        {
          Version = "v1",
          Title = "Microservice Autentication",
          Description = "Documentação das Rotas do Projeto",
          Contact = new OpenApiContact
          {
            Name = "Marcos Ferrare",
            Email = "kakoferrare87@gmail.com",
          },

        });
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);
      });

      services.AddScoped<IAutenticationService, AutenticationService>();
      services.AddScoped<IAutenticationRepository, AutenticationRepository>();

        }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseSwagger();

      app.UseSwaggerUI(c =>
      {
        //c.DefaultModelsExpandDepth(-1); // Disable swagger schemas at bottom
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Auth Service API");
      });
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
