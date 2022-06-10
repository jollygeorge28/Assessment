using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Name_SorterLibrary
{
    public class NameSorter
    {

        private readonly ILogger _logger;

        public NameSorter()
        {

        }
        public NameSorter(ILogger<NameSorter> logger)
        {
            _logger = logger;
        }
        public  string[] SortNames(string fileName)
        {           
            string[] result = null;
            try
            {
                if (!System.IO.File.Exists(fileName))
                {
                    //log  the reason here: file not found
                    _logger.LogInformation("SortNames :  "+ "File  " +fileName + "  not found!");
                    return new string[] { "Sorting Failed!" };
                }
                else
                {
                    // read the content             
                    result = System.IO.File.ReadAllLines(fileName);
                    // get a parallel array for sorting
                    var sortKey = result.Select(MoveLastNameToFirst).ToArray();
                    System.Array.Sort(sortKey, result);
                    // _logger.LogInformation("Input File sorted");
                    return result;
                }               
            }
            catch (Exception ex)
            {
                //log the exception here               
                _logger.LogInformation("SortNames :  "+ex.Message.ToString());
                return new string[] { "Sorting Failed!" }; 
            }
        }
        public string MoveLastNameToFirst(string name)
        {
            // break up the name into words
            var names = name.Split(' ', System.StringSplitOptions.None);
            var length = names.Length;
            // put the LastName at the front
            return names[length - 1] + ' ' + string.Join(' ', names, 0, length - 1);
        }
        public void DisplaySortedNames(string[] names)
        {
            foreach (string name in names)
            {
                System.Console.WriteLine(name);
            }
        }        
    }
}
