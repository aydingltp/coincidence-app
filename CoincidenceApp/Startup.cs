using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoincidenceApp.Models;
using CoincidenceApp.Models.Tesaduf;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using VueCliMiddleware;


namespace CoincidenceApp
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
      services.AddDbContext<DataContext>();
      //  options.UseSqlServer(Configuration.GetConnectionString("DataContext")));


      services.AddSingleton<IHostedService, TimedHostedService>();
      services.AddHostedService<TimedHostedService>();
        services.AddControllers();
      services.AddRazorPages();
      services.AddSpaStaticFiles(opt => opt.RootPath = "ClientApp/dist");
      
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
      app.UseSpaStaticFiles();
      // app.UseEndpoints(endpoints =>
      // {
      //     endpoints.MapControllers();
      // });
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();

        if (env.IsDevelopment())
        {
          endpoints.MapToVueCliProxy(
            "{*path}",
            new SpaOptions {SourcePath = "ClientApp"},
            npmScript: (System.Diagnostics.Debugger.IsAttached) ? "dev" : null,
            regex: "Compiled successfully",
            forceKill: true,
            port: 8080
          );
        }
      });
      app.UseSpa(spa => { spa.Options.SourcePath = "ClientApp"; });
    }
  }
}
