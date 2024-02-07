using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Real_Time_Stock_Exchange_Application.Hubs;
using System;
using System.Net.Http;

namespace Real_Time_Stock_Exchange_Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices(services =>
                    {
                        services.AddControllers();
                        services.AddHttpClient<AlphaVantageService>();
                        services.AddSingleton<AlphaVantageService>(sp =>
                        {
                            var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
                            var httpClient = httpClientFactory.CreateClient();
                            var apiKey = "YV9VW07WNXOIQUF5";
                            return new AlphaVantageService(httpClient, apiKey);
                        });

                        // Add SignalR services
                        services.AddSignalR();
                    })
                    .Configure(app =>
                    {
                        app.UseHttpsRedirection();
                        app.UseRouting();

                        // Add authentication middleware
                        app.Use(async (context, next) =>
                        {
                            var apiKey = context.Request.Headers["ApiKey"];
                            if (!string.IsNullOrEmpty(apiKey) && apiKey == "ASDFGHJKL:")
                            {
                                await next();
                            }
                            else
                            {
                                context.Response.StatusCode = 401; // Unauthorized
                            }
                        });

                        app.UseAuthorization();

                        // Serve default files and static files
                        app.UseDefaultFiles();
                        app.UseStaticFiles();

                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllers();
                            // Map the SignalR hub
                            endpoints.MapHub<StockUpdatesHub>("/stockUpdatesHub");
                        });
                    });
                })
                .Build();

            host.Run();
        }
    }
}
