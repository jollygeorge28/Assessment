using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Name_SorterLibrary;

namespace Name_Sorter
{
    class Program
    {        
        public static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices.ServiceProviders();
            var nameSorter = serviceProvider.GetService<NameSorter>();
            var createOutputFile = serviceProvider.GetService<CreateOutputFile>();
            var logger = serviceProvider.GetService<ILogger<Program>>();

            // Take each argument as a filename:
            foreach (string arg in args)
            {
                if (arg == "unsorted-names-list.txt")
                {                  
                        var names = nameSorter.SortNames(arg);
                        if (names[0].ToString() != "Sorting Failed!")
                        {
                          nameSorter.DisplaySortedNames(names);
                          Console.WriteLine("\nSorted input file sorted-names-list.txt !");                      
                          bool status = createOutputFile.CreateSortedFile(names);
                         logger.LogInformation("Is the soted file Created : " + status);                      
                    }                                        
                }
                else
                {
                    logger.LogInformation("Please give a valid input file!");
                    Console.WriteLine("Please give a valid input file!");
                }               
            }
            Console.ReadLine();
        }       
    }
}
