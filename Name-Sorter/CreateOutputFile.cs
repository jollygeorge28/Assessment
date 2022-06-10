using Microsoft.Extensions.Logging;
using Name_SorterLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Name_Sorter
{
    public class CreateOutputFile
    {
        private readonly ILogger _logger;
        public CreateOutputFile()
        {
        }
        public CreateOutputFile(ILogger<NameSorter> logger)
        {
            _logger = logger;
        }
        public bool CreateSortedFile(string[] names)
        {
            bool isSucess = false;
            try
            {
                if (!(System.IO.File.Exists(@"sorted-names-list.txt")))
                    System.IO.File.WriteAllLines(@"sorted-names-list.txt", names);
                else
                {
                    System.IO.File.Delete(@"sorted-names-list.txt");
                    System.IO.File.WriteAllLines(@"sorted-names-list.txt", names);
                }
                isSucess = true;
            }
            catch (Exception ex)
            {
                //log the exception here               
                _logger.LogInformation("CreateSortedFile :  " + ex.Message.ToString());
            }
            return isSucess;
        }
    }
}
