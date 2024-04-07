 
using Chats.Services;
using Chats.ViewModel._login;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Chats.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly IApiService _apiService;
        private string _email;
        private string _password;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        } 
        public ICommand LoginCommand { get; private set; }

        public LoginViewModel(IApiService apiService)
        {
            _apiService = apiService;
            LoginCommand = new Command(async () => await ExecuteLoginCommand());
        }

        private async Task ExecuteLoginCommand()
        {
            var loginModel = new LoginModel
            {
                Email = Email,
                Password = Password,
                RememberMe = false
            };

            bool loginSuccess = await _apiService.LoginAsync(loginModel);

            if (loginSuccess)
            {
                // Переход на следующую страницу или выполнение других действий после успешного входа
                // Например, переход на главную страницу приложения
                await Shell.Current.Navigation.PushAsync(new MainPage());
            }
            else  await Application.Current.MainPage.DisplayAlert("Ошибка", "Неверный логин или пароль", "OK");
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
