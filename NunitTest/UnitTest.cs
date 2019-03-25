using GitSearcher.ViewModels;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GitSearcher.NunitTest
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
        public void Test2()
        {
            var vm = new SearcherViewModel();
            vm.Query = "ez";
            Assert.IsNotNull(vm.SubmitCommand, "command not initialized");
            Assert.IsTrue(vm.Query == "ez", "wrong query");
            vm.SubmitCommand.Execute(null);
            //GitHub does not like when Bots are making requests to it
            Assert.IsNull(vm.UserModel, "The response was successfull");

        }
        [Test]
        public void Test3()

        {
            var temp = new ContentPage();
            var vm = new EmpireViewModel(temp.Navigation);
            vm.OpenOtherPageCommand.Execute(null);
            Assert.AreEqual(temp.Navigation.ModalStack[temp.Navigation.ModalStack.Count - 1].ToString(), "GitSearcher.Pages.SearchPage");

        }
}
}