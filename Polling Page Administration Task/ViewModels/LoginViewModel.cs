﻿using System.ComponentModel.DataAnnotations;

namespace Polling_Page_Administration_Task.ViewModels
{
    public class LoginViewModel
    {
         
        [Required]
       // [EmailAddress]
       // [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
