using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace library.Models{
    public class Borrowed{
        public int Id {get; set;}
        
        public int BookId {get; set;}
        public Book? Book {get; set;}
        
        public int UserId {get; set;}
        public User? User {get; set;}
        
        public bool Closed {get; set;}
    }
}