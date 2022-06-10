using NUnit.Framework;
using Name_SorterLibrary;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        NameSorter nameSorter= null;

        public Tests()
        {
            nameSorter = new NameSorter();
        }

        [Test]
        public void Test_MoveLastNameToFirst_WithDependency_InjectionLogger()
        {
            var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection()
                .AddLogging(config => config.AddConsole())     
                .BuildServiceProvider();
            using (var loggerFactory = services.GetRequiredService<ILoggerFactory>())
            {
                var svc = new NameSorter(loggerFactory.CreateLogger<Name_SorterLibrary.NameSorter>());
                var result = svc.MoveLastNameToFirst("Adonis Julius Archer");
                Assert.AreEqual("Archer Adonis Julius", result);
            }
        }

        [Test]
        public void Test_SortNames_WithDependency_InjectionLogger()
        {
            var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection()
                .AddLogging(config => config.AddConsole())
                .BuildServiceProvider();
            using (var loggerFactory = services.GetRequiredService<ILoggerFactory>())
            {
                var svc = new NameSorter(loggerFactory.CreateLogger<Name_SorterLibrary.NameSorter>());
                var desiredResult = svc.SortNames("unsorted-names-list.txt");
                IEnumerable<string> actualResult = System.IO.File.ReadAllLines("sample-sorted-names-list.txt");              
                CollectionAssert.AreEqual(actualResult, desiredResult);
            }
        }
        [Test]
        public void Test_SortNames_WithCreateNewObject()
        {
           
            IEnumerable<string> actualResult = nameSorter.SortNames("unsorted-names-list.txt");
            IEnumerable<string> desiredResult = System.IO.File.ReadAllLines("sample-sorted-names-list.txt");
            CollectionAssert.AreEqual(actualResult, desiredResult);
        }
        [Test]
        public void Test_MoveLastNameToFirst_WithCreateNewObject()
        {
            var result = nameSorter.MoveLastNameToFirst("Adonis Julius Archer");
            Assert.AreEqual("Archer Adonis Julius", result);
        }
    }
}