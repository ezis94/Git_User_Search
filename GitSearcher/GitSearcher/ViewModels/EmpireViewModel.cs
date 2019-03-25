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
       

        public ICommand OpenOtherPageCommand { get; set; }
        public INavigation Navigation { get; set; } 
       // Constructor
        public EmpireViewModel(INavigation input )
        {
            Navigation = input;
            OpenOtherPageCommand = new Command(async () => await GotoSearchPage());

        }
        //Handler of button press
        public async Task GotoSearchPage()
        {
            
            await Navigation.PushModalAsync(new SearchPage(), true);
        }
    }
}