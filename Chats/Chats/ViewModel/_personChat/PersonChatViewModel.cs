using Chats.Pages.Main.ListChats;
using Chats.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Chats.ViewModel._personChat
{
    public class PersonChatViewModel : INotifyPropertyChanged
    {
        private ApiSService _apiService;
        public event PropertyChangedEventHandler PropertyChanged;
        private string _search;
        public ICommand GroupChatCommand { get; private set; }
        
        public string Search
        {
            get { return _search; }
            set
            {
                if (_search != value)
                {
                    _search = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }
        public PersonChatViewModel()
        { 
            _apiService = new ApiSService();
            _apiService.Connect();
            GroupChatCommand = new Command(GoToGroupChat); 
        }
        public ICommand SearchCommand => new Command<string>(async (string query) => await _apiService.Search(Search,"User"));
      
        private async void GoToGroupChat() =>await Shell.Current.GoToAsync($"//{nameof(GroupChats)}");
    

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
