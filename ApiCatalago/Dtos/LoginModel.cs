﻿using System.ComponentModel.DataAnnotations;

namespace ApiCatalago.Dtos
{
    public class LoginModel
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
