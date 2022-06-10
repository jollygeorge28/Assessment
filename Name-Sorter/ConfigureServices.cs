using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Name_SorterLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Name_Sorter
{
    public class ConfigureServices
    {

        public static void ConfigureService(IServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole())
           .Configure<LoggerFilterOptions>(options => options.MinLevel = LogLevel.Information)
           .AddTransient<NameSorter>()
            .AddTransient<CreateOutputFile>();
        }
        public static ServiceProvider ServiceProviders()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureService(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
