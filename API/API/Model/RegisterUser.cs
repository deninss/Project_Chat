﻿using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class RegisterUser
    {
        public string Name { get; set; } 
        public string Surname { get; set; } 
        public string Patronymic { get; set; } 
        public string Email { get; set; } 
        public string Password { get; set; }  
    }
}
