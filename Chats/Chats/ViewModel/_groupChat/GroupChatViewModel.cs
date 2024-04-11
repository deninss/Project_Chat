using Chats.Pages.Main.ListChats;
using Chats.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chats.ViewModel._groupChat
{
    public class GroupChatViewModel : INotifyPropertyChanged
    {
        private ApiSService _apiService;
        public event PropertyChangedEventHandler PropertyChanged;
        private string _search;
        public ICommand PersonChatCommand { get; private set; }
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

        public GroupChatViewModel()
        {
           /* _apiService = new ApiSService();
            _apiService.Connect();*/
            PersonChatCommand = new Command(GoToPersonChat); 
        }
        public ICommand SearchCommand => new Command<string>(async (string query) => await _apiService.Search(Search, "Group"));
        private async void GoToPersonChat() => await Shell.Current.GoToAsync($"//{nameof(PersonChats)}"); 
        

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    
    }
}
