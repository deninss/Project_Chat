using Chats.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Chats.ViewModel._register;
using Chats.Pages.Auth;

namespace Chats.ViewModel
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        private readonly IApiService _apiService;
        private string _name;
        private string _surname;
        private string _patronymic;
        private string _email;
        private string _password;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        public string Surname
        {
            get { return _surname; }
            set
            {
                if (_surname != value)
                {
                    _surname = value;
                    OnPropertyChanged(nameof(Surname));
                }
            }
        }
        public string Patronymic
        {
            get { return _patronymic; }
            set
            {
                if (_patronymic != value)
                {
                    _patronymic = value;
                    OnPropertyChanged(nameof(Patronymic));
                }
            }
        }
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

        public ICommand RegisterCommand { get; private set; }

        public RegisterViewModel(IApiService apiService)
        {
            _apiService = apiService;
            RegisterCommand = new Command(async () => await ExecuteRegisterCommand());
        }

        private async Task ExecuteRegisterCommand()
        {
            var registerModel = new RegisterModel
            {
                Name = Name,
                Surname = Surname,
                Patronymic = Patronymic,
                Email = Email,
                Password = Password
            };

            bool registerSuccess = await _apiService.RegisterAsync(registerModel);

            if (registerSuccess)
            { 
                //возвращаемся на страницу назад, к странице Login 
                await Shell.Current.GoToAsync($"//{nameof(Login)}");
            }
            else await Application.Current.MainPage.DisplayAlert("Ошибка", "Неверный логин или пароль", "OK");
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
