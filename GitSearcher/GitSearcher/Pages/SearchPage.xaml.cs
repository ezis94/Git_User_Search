using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GitSearcher.ViewModels;
using GitSearcher.Models;
using System.Collections.Generic;

namespace GitSearcher.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            var vm = new SearcherViewModel();
            this.BindingContext = vm;
            InitializeComponent();
            Query.Completed += (object sender, EventArgs e) =>
            {
                Search.Command.Execute(null);
            };

        }
        
    }
}