using Chats.Pages.Main.ListChats;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chats.ViewModel._personChat
{
    public class PersonChatViewModel : INotifyPropertyChanged
    {
        public ICommand GrouChatCommand { get; private set; }
        public PersonChatViewModel()
        { 
            GrouChatCommand = new Command(GoToGroupChat);
        }
         

        private async void GoToGroupChat()
        {
            // Переход на страницу 2
            await Shell.Current.GoToAsync($"//{nameof(GroupChats)}");
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
