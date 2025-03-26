
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using name_sorter;
using name_sorter.Application.Contracts;
using name_sorter.Application.File;
using name_sorter.Application.File.TextFile;
using name_sorter.Application.Sort;

using IHost host = createHostBuilder(args).Build();
using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    services.GetRequiredService<App>().Run(args);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

static IHostBuilder createHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) =>
        {
            services.AddSingleton<App>();
            services.AddTransient<FileProcessor>();
            services.AddTransient<IFileProcessor, TextFileProcessor>();
            services.AddTransient<IFileReader, TextFileActions>();
            services.AddTransient<IFileWriter, TextFileActions>();
            services.AddTransient<ISortingAlgorythms, SortingAlgorythms>();
            services.AddTransient<IFilePathGenerator, FilePathGenerator>();
            services.AddTransient<IFileValidator, FileValidator>();
        });
}
