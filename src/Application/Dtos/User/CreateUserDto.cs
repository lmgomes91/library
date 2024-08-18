// using System;
// using System.Collections.Generic;
// using System.ComponentModel;
// using System.ComponentModel.DataAnnotations;
// using System.Linq;
// using System.Threading.Tasks;

// namespace library.src.Application.Dtos.User{
//     public class CreateUserDto{
//         [Required]
//         [MinLength(5, ErrorMessage = "Name must be 5 characters at least")]
//         public string Name {get; set;} = string.Empty;
        
//         [Required]
//         [MinLength(5, ErrorMessage = "Email must be 5 characters at least")]
//         public string Email {get; set;} = string.Empty;

//         [Required]
//         [MinLength(5, ErrorMessage = "Email must be 5 characters at least")]
//         public string Password {get; set;} = string.Empty;
//     }
// }