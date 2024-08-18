using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace library.src.Domain.Models{
    [Table("Borrowed")]
    public class Borrowed{
        public int Id {get; set;}
        
        public int BookId {get; set;}
        public Book? Book {get; set;}
        
        public string UserId {get; set;}
        public User? User {get; set;}
        
        public bool Closed {get; set;}
    }
}