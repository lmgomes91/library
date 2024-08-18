using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library.src.Application.Dtos.Book;
using library.src.Domain.Interfaces;
using library.src.Domain.Models;
using library.src.Infrastructure.Data;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;

namespace library.src.Infrastructure.Repositories{
    public class BorrowedRepository : IBorrowedRepository
    {
        private readonly ApplicationDBContext _context;
        
        public BorrowedRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Borrowed> CreateAsync(Borrowed borrowed)
        {
            await _context.Borrowed.AddAsync(borrowed);
            await _context.SaveChangesAsync();

            return borrowed;
        }

        public async Task<List<Borrowed>> GetUserBorrowed(User user)
        {
            return await _context.Borrowed.Where(u => u.UserId == user.Id)
                .Select(b => new Borrowed{
                    Id = b.Id,
                    Book = b.Book,
                    BookId = b.BookId,
                    Closed = b.Closed,
                    User = b.User,
                    UserId = b.UserId
                }).ToListAsync();
        }
    }
}


