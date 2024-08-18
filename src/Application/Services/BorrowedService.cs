using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library.src.Application.Extensions;
using library.src.Domain.Interfaces;
using library.src.Domain.Models;
using Microsoft.AspNetCore.Identity;



namespace library.src.Application.Services{
    public class BorrowedService: IBorrowedService
    {
        private readonly UserManager<User> _userManager;
        private readonly IBookRepository _bookRepo;
        private readonly IBorrowedRepository _borrowedRepo;
        
        public BorrowedService(UserManager<User> userManager, IBookRepository bookRepo, IBorrowedRepository borrowedRepo)
        {
            _userManager = userManager;
            _bookRepo = bookRepo;
            _borrowedRepo = borrowedRepo;
        }

        public async Task<List<Borrowed>> GetUserBorrowed(string username){
            try
            {
                var user = await _userManager.FindByNameAsync(username);

                return await _borrowedRepo.GetUserBorrowed(user);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<bool> CreateBorrowed(string username, int bookId){
            try
            {
                var user = await _userManager.FindByNameAsync(username);

                var book = await _bookRepo.GetByIdAsync(bookId);

                if (book == null ||book.IsBorrowed)
                {
                    return false;
                }

                var borrowed = new Borrowed{
                    UserId = user.Id,
                    BookId = book.Id,
                    Closed = false
                };

                await _borrowedRepo.CreateAsync(borrowed);

                if(borrowed == null){
                    return false;
                }

                await _bookRepo.UpdateBorrowedStatus(book, true);

                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}