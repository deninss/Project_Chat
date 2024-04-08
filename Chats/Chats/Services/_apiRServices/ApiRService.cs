using Chats.ViewModel._login;
using Chats.ViewModel._register;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Chats.Services
{
    public class ApiRService : IApiRService
    {
        private readonly HttpClient _httpClient; 

        public ApiRService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://10.0.2.2:5117/")
            };
        }
        public async Task<bool> LoginAsync(LoginModel loginModel)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Auth/Login", loginModel);
                if (response.IsSuccessStatusCode)
                {
                    var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
                    if (loginResponse.Success)
                    {
                        // Вход успешно выполнен, обработка токена аутентификации и сохранение токена аутентификации в SecureStorage
                        string authToken = loginResponse.Token;
                        await SecureStorage.SetAsync("auth_token", authToken);
                    }
                    else
                    {
                        // Обработка ошибки входа
                    }
                }
                return response.IsSuccessStatusCode;
             }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine($"HttpRequestException: {ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
            }
            return false;
        }

        public async Task<bool> RegisterAsync(RegisterModel registerModel)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Auth/Register", registerModel);
                if (response.IsSuccessStatusCode)
                {
                    var registerResponse = await response.Content.ReadFromJsonAsync<bool>();
                    if (registerResponse == true) return response.IsSuccessStatusCode;
                    else return false;
                }
                
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine($"HttpRequestException: {ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
            }
            return false;
        }
    }
}
