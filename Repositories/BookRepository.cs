using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library.Data;
using library.Dtos.Book;
using library.Interfaces;
using library.Models;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;

namespace library.Repositories{
    public class BookRepository : IBookRepository
    {
        
        private readonly ApplicationDBContext _context;
        public BookRepository(ApplicationDBContext context)
        {
             _context = context;
        }

        public async Task<Book?> CreateAsync(Book bookModel)
        {
            await _context.Book.AddAsync(bookModel);
            await _context.SaveChangesAsync();
            return bookModel;
        }

        public async Task<Book?> DeleteAsync(Book bookModel)
        {
            _context.Book.Remove(bookModel);
            await _context.SaveChangesAsync();

            return bookModel;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Book.ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Book.FindAsync(id);
        }

        public async Task<Book?> UpdateAsync(Book book, UpdateBookDto updateBook)
        {

            book.Author = updateBook.Author;
            book.IsBorrowed = updateBook.IsBorrowed;
            book.Edition = updateBook.Edition;
            book.Title = updateBook.Title;

            await _context.SaveChangesAsync();

            return book;
        }

        public async Task<List<Book>> FindBooksByTitlePatternAsync(string pattern)
        {
            return await _context.Book
            .Where(b => EF.Functions.Like(b.Title, pattern))
            .ToListAsync();
        }
    }
}