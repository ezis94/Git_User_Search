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
        //Git variable
        GitServices _gitServices = new GitServices();
        //The object for response storage

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //The object for response storage
        private UserModel _userModel;
        public UserModel UserModel
        {
            get { return _userModel; }
            set
            {
                _userModel = value;
                OnPropertyChanged();
            }
        }

        //The search query for Git API
        private string query;
        public string Query
        {
            get { return query; }
            set
            {
                query = value;
                OnPropertyChanged();


            }
        }
        //The loading animation handler

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

        //The caller to Git API
        public async Task InitializeGetUsersAsync()
        {
            try
            {
                IsBusy = true; 
                UserModel = await _gitServices.GetGitDetails(Query);

            }
            finally
            {
               IsBusy = false;
            }
        }

        //The Command executed upon search
        public ICommand SubmitCommand { protected set; get; }
        //Opening of each Git in Browser
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
        //Constructor
        public SearcherViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }
        //Search query submit event
        public void OnSubmit()
        {

            Task.Run(async () => {
                await InitializeGetUsersAsync();
            });
            OnPropertyChanged();
        }
      
    }
   }
