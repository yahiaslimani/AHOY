using Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Persistence;
using System.Text.Json.Serialization;

namespace WebApi;
public class Startup
{
    private IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration) => Configuration = configuration;
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddPersistence(Configuration);
        services.AddApplication(Configuration);
        services.AddSwaggerGen(c =>
        {
            c.IncludeXmlComments($@"{AppDomain.CurrentDomain.BaseDirectory}DocumentationFile.xml");
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "AHOY :D",
            });
        });
        services.AddControllers().AddJsonOptions(o => o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseExceptionHandler(env.IsDevelopment() ? "/development" : "/live");
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "AHOY :D");
        });
        app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}