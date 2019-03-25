using GitSearcher.ViewModels;
using NUnit.Framework;
using System.Threading.Tasks;

namespace GitSearcher.Tests
{
    public class UnitTest
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test1()
        {
            var vm = new SearcherViewModel();
            vm.Query = "ezis94";
            Assert.IsFalse(vm.IsBusy, "The App is busy");
            vm.SubmitCommand.Execute(null);
            Assert.IsFalse(vm.IsBusy, "The App has not finished its task");

           // Assert.Pass();
        }
        [Test]
        public async Task Test2()
        {
            var vm = new SearcherViewModel();
            vm.Query = "ezis94";
            Assert.IsNotNull(vm.SubmitCommand,"command not initialized");
            Assert.IsTrue(vm.Query=="ezis94", "wrong query");
            Task.Run(async () =>
            {
                await vm.InitializeGetUsersAsync();
            }).GetAwaiter().GetResult();
            Assert.IsNull(vm.UserModel, "There is not 1 response from Git");

        }
    }
}