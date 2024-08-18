using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace library.Dtos.Book{
    public class UpdateBookDto{
        [Required]
        [MinLength(2, ErrorMessage = "Title must be 2 characters at least")]
        public string Title {get; set;} = string.Empty;
        
        [Required]
        [MinLength(2, ErrorMessage = "Author must be 2 characters at least")]
        public string Author {get; set;} = string.Empty;
        
        [Required]
        [Range(1,10000)]
        public int Edition {get; set;}
        
        [Required]
        public bool IsBorrowed {get; set;}
    }
}