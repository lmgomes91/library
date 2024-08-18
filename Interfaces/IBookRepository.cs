using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library.Dtos.Book;
using library.Models;

namespace library.Interfaces{
    public interface IBookRepository{
        Task<List<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task<Book?> CreateAsync(Book bookModel);
        Task<Book?> UpdateAsync(Book book, UpdateBookDto bookModel);
        Task<Book?> DeleteAsync(Book bookModel);
        Task<List<Book>> FindBooksByTitlePatternAsync(string pattern);
    }
}