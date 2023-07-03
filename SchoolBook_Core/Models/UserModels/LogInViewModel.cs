﻿using System.ComponentModel.DataAnnotations;

namespace SchoolBook_Core.Models.UserModels
{
    public class LogInViewModel
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
