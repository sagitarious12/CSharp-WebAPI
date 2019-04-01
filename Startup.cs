using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Web_API_Test.Models;
using Web_API_Test.Services;

namespace Web_API_Test
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
        services.AddScoped<CompanyService>();
        services.AddCors(options =>
        {
            options.AddPolicy("CorsAllowAll",
                builder =>
                {
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
                });

            options.AddPolicy("CorsAllowSpecific",
                p => p.WithHeaders("Content-Type", "Accept", "Auth-Token")
                    .WithMethods("POST", "PUT", "DELETE")
                    .SetPreflightMaxAge(new TimeSpan(1728000))
                    .AllowAnyOrigin()
                    .AllowCredentials()
                );
        });
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }
      var corsAllowAll = Configuration["AppSettings:CorsAllowAll"] ?? "false";
      app.UseCors(corsAllowAll == "true" ? "CorsAllowAll" : "CorsAllowSpecific");
      app.UseHttpsRedirection();
      app.UseMvc();
    }
  }
}
