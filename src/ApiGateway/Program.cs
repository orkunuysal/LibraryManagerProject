using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;

namespace ApiGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog((context, configuration) =>
            {
            configuration.Enrich.FromLogContext()
            .Enrich.WithMachineName()
            .WriteTo.Console()
            .WriteTo.Elasticsearch(
                new Serilog.Sinks.Elasticsearch.ElasticsearchSinkOptions(
                    new Uri(context.Configuration["ElasticConfiguration:Uri"]))
                {
                    IndexFormat = $"librarymanager-apigateway-logs-{ context.HostingEnvironment.EnvironmentName?.ToLower()}",
                    AutoRegisterTemplate = true,
                    NumberOfShards = 2,
                    NumberOfReplicas = 1
                })
            .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
            .ReadFrom.Configuration(context.Configuration);

        })
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddJsonFile($"ApiGatewayConfig.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true);
            }
                )
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
