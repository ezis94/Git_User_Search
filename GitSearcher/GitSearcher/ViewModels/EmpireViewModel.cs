using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Windows;
using GitSearcher.Pages;
using System.Threading.Tasks;

namespace GitSearcher.ViewModels
{
    public class EmpireViewModel 
    {
       

        public Action DisplayInvalidLoginPrompt;
        public ICommand OpenOtherPageCommand { get; set; }
        public INavigation Navigation { get; set; } 

        public EmpireViewModel(INavigation input )
        {
            Navigation = input;
            OpenOtherPageCommand = new Command(async () => await GotoPage2());
        }
        public async Task GotoPage2()
        {
            await Navigation.PushAsync(new SearchPage());
        }
    }
}