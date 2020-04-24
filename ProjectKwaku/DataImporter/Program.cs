using DataImporter.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models.Entities;
using Repositories;
using System;
using System.Collections.Generic;

namespace DataImporter
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            var appSettingsPath = $"appsettings.Development.json";
#else
            var appSettingsPath = $"appsettings.json";
#endif

            var serviceProvider = new ServiceCollection()
                .AddDbContext<CheckSheetContext>()
                .AddScoped<IDbContext, CheckSheetContext>()
                .AddTransient<IConfiguration>(sp =>
                {
                    IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
                    configurationBuilder.AddJsonFile(appSettingsPath);
                    return configurationBuilder.Build();
                })
                .AddTransient<IGenericRepository<CheckSheet>, GenericRepository<CheckSheet>>()
                .AddTransient<IGenericRepository<CheckSheetType>, GenericRepository<CheckSheetType>>()
                .AddTransient<IGenericRepository<Task>, GenericRepository<Task>>()
                .AddTransient<IGenericRepository<TaskStatus>, GenericRepository<TaskStatus>>()
                .BuildServiceProvider();

            var configService = serviceProvider.GetService<IConfiguration>();
            var importConfigs = configService.GetSection("DataImport").Get<List<DataImportConfig>>();

            Console.WriteLine("====================================================");
            Console.WriteLine("              Checksheet Data Importer              ");
            Console.WriteLine("====================================================");
            Console.WriteLine("                                                    ");
            Console.WriteLine("Use this tool to pre-populate an empty database.    ");
            Console.WriteLine("                                                    ");
            Console.WriteLine($"appsettings loaded: {appSettingsPath}");
            Console.WriteLine("                                                    ");
            Console.WriteLine($"# of imports: {importConfigs.Count}");
            Console.WriteLine("                                                    ");
            Console.WriteLine("Press Y to continue, or any key to quit.            ");
            Console.WriteLine("                                                    ");
            Console.WriteLine("====================================================");
            Console.WriteLine("                                                    ");

            while (Console.ReadKey().Key != ConsoleKey.Y)
            {
                Environment.Exit(0);
            }

            var dataService = new DataService(
                serviceProvider.GetRequiredService<IGenericRepository<CheckSheet>>(),
                serviceProvider.GetRequiredService<IGenericRepository<CheckSheetType>>(),
                serviceProvider.GetRequiredService<IGenericRepository<Task>>(),
                serviceProvider.GetRequiredService<IGenericRepository<TaskStatus>>()
            );

            foreach (var config in importConfigs)
            {
                Console.WriteLine("                                                    ");
                Console.WriteLine("                                                    ");
                Console.WriteLine($"Importing...");
                Console.WriteLine($"> Check Sheet Name: " + config.CheckSheetName);
                Console.WriteLine($"> Time Zone: " + config.CheckSheetTimeZoneId);
                Console.WriteLine($"> File Path: " + config.FilePath);

                var checkSheetTypeId = dataService.AddCheckSheetType(config.CheckSheetName, config.CheckSheetTimeZoneId);
                var tasks = dataService.ImportTasks(config.FilePath, checkSheetTypeId);
                var checkSheetId = dataService.AddCheckSheet(checkSheetTypeId);
                dataService.AddTaskStatuses(tasks, checkSheetId);

                Console.WriteLine($"Tasks Added: " + tasks.Length);
            }

            Console.WriteLine("====================================================");
            Console.WriteLine("Import finished. Press any key to quit.");
            Console.WriteLine("====================================================");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
