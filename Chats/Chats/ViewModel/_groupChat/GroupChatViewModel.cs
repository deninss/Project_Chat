using Chats.Pages.Main.ListChats;
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
        public ICommand PersonChatCommand { get; private set; } 

        public GroupChatViewModel()
        {
            PersonChatCommand = new Command(GoToPersonChat); 
        }

        private async void GoToPersonChat()
        {
            // Переход на страницу 1
            await Shell.Current.GoToAsync($"//{nameof(PersonChats)}");
        }

      
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
