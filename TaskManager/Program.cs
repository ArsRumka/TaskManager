using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.Interfaces;
using TaskManager.Application.Services;
using TaskManager.Infrastructure.Factory;
using TaskManager.Infrastructure.Migrations;
using TaskManager.Infrastructure.Interfaces;
using TaskManager.Infrastructure.Repository;
using TaskManager.Presentation.Interfaces;
using TaskManager.Presentation.UI;

namespace TaskManager.App
{
class Program
{
    static async Task Main(string[] args)
    {
        var services = new ServiceCollection();
        ConfigureServices(services);

        using var provider = services.BuildServiceProvider();
        using var scope = provider.CreateScope();

        UpdateDatabase(scope.ServiceProvider);

        var consoleUI = scope.ServiceProvider.GetRequiredService<IConsoleUI>();
        await consoleUI.RunAsync();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        services.AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                .AddSqlServer()
                .WithGlobalConnectionString(configuration.GetConnectionString("SqlServer"))
                .ScanIn(typeof(CreateTaskTable).Assembly).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole());

        services.AddScoped<IFactoryDbConnection>(_ =>
            new FactoryDbConnection(configuration.GetConnectionString("SqlServer")));

        services.AddScoped<ITaskRepository, TaskRepository>();

        services.AddScoped<ITaskService, TaskService>();

        services.AddScoped<ITaskUi, TaskUI>();
        services.AddScoped<IConsoleUI, ConsoleUI>();
    }

    private static void UpdateDatabase(IServiceProvider provider)
    {
        var runner = provider.GetRequiredService<IMigrationRunner>();
        runner.MigrateUp();
    }
}
}
