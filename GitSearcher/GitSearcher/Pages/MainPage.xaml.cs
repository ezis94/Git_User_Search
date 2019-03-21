using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using GitSearcher.ViewModels;

namespace GitSearcher.Pages
{
    public partial class MainPage : ContentPage
    {
     
        public MainPage()
        {
            
            InitializeComponent();
            
            BindingContext = new ViewModels.EmpireViewModel(Navigation);
            
        }

      
    }
}
