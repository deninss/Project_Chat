using Chats.Pages.Auth;
using Chats.ViewModel;

namespace Chats
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent(); 
            MainPage = new AppShell();
        }
    }
}
