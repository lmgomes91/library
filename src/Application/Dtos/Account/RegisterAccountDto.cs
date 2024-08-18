using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace library.src.Application.Dtos.Account
{
    public class RegisterAccountDto{
        [Required]
        public string? Username {get; set;}

        [Required]
        [EmailAddress]
        public string? Email {get; set;}

        [Required]
        public string? Password {get; set;}
    }
}