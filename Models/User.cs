using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace library.Models{
    public class User{
        public int Id {get; set;}
        public string Name {get; set;} = string.Empty;
        public string Password {get; set;} = string.Empty;
    }
}