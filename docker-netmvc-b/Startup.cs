using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
		loggerFactory.AddConsole();
		
		app.UseIISPlatformHandler();
		
		app.UseDeveloperExceptionPage();

		app.UseMvcWithDefaultRoute();
   }
}

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return new ContentResult { Content = "Hello from ASP.NET MVC ! - " + DateTime.Now + " - Web Server B." };
    }
}
