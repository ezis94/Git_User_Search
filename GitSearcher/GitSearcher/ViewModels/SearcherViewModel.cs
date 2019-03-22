using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using GitSearcher.Models;
using GitSearcher.Handler;
using System.Threading.Tasks;

namespace GitSearcher.ViewModels
{
    public class SearcherViewModel : INotifyPropertyChanged
    {
        GitServices _gitServices = new GitServices();
        private UserModel _userModel;  

        public Action DisplayInvalidLoginPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public UserModel UserModel
        {
            get { return _userModel; }
            set
            {
                _userModel = value;
                OnPropertyChanged();
            }
        }

        private string query;
        public string Query
        {
            get { return query; }
            set
            {
                query = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Query"));


            }
        }
        private bool _isBusy;   // for showing loader when the task is initializing
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }


        private async Task InitializeGetUsersAsync()
        {
            try
            {
                IsBusy = true; 
                UserModel = await _gitServices.GetGitDetails(query);
                Console.WriteLine("---------------"+UserModel.items.Count);
            }
            finally
            {
                IsBusy = false;
            }
        }


        public ICommand SubmitCommand { protected set; get; }
        public ICommand ItemClickCommand
        {
            get
            {
                return new Command((item) =>
                {
                    Models.Item txc = (Item)item;

                    Device.OpenUri(new Uri(txc.url));
                });
            }
        }
        public SearcherViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }
        public void OnSubmit()
        {

            Task.Run(async () => {
                await InitializeGetUsersAsync();
            });
            OnPropertyChanged();
        }
      
    }
   }
