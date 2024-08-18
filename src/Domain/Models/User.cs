using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace library.src.Domain.Models{
    public class User: IdentityUser{
        public List<Borrowed> Borroweds {get; set;} = new List<Borrowed>();
    }
}