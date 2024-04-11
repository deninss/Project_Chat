using Chats.Model;
using Chats.Pages.Main.ListChats;
using Chats.Services;
using System.Collections.ObjectModel;
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
        public string Id { get; set; }

        private ObservableCollection<Search> _searchResults;
        public ObservableCollection<Search> SearchResults
        {
            get { return _searchResults; }
            set
            {
                if (_searchResults != value)
                {
                    _searchResults = value;
                    OnPropertyChanged();
                }
            }
        }
         
        public string Search
        {
            get { return _search; }
            set
            {
                if (_search != value)
                {
                    _search = value;
                    OnPropertyChanged(nameof(Search));
                    if (string.IsNullOrEmpty(_search))SearchResults.Clear();
                }
            }
        } 
        public PersonChatViewModel()
        {
            _apiService = new ApiSService(this);
            _apiService.Connect();
            SearchResults = new ObservableCollection<Search>(); 
        }
        public ICommand GroupChatCommand => new Command(async () => await Shell.Current.GoToAsync($"//{nameof(GroupChats)}"));
        public ICommand SearchCommand => new Command<string>(async (string query) =>
        {
            await _apiService.Search(Search, "User");
        });
        public ICommand ItemTappedCommand =>  new Command(async () => await _apiService.AddChat(Id));
       
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
