using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library.src.Domain.Models;

namespace library.src.Domain.Interfaces{
    public interface IBorrowedRepository{
        Task<List<Borrowed>> GetUserBorrowed(User user);
        Task<Borrowed> CreateAsync(Borrowed borrowed);
    }

}