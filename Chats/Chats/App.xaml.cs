using Chats.Pages.Auth; 

namespace Chats
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent(); 
            MainPage = new AppShell();
        }
        protected override async void OnStart()
        {
            base.OnStart();

            // Переход на страницу LoginPage при запуске приложения
            await Shell.Current.GoToAsync($"//{nameof(Login)}");
        }
    }
}
