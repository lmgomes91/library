using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library.src.Application.Dtos.Book;
using library.src.Domain.Models;


namespace library.src.Domain.Interfaces{
    public interface IBookRepository{
        Task<List<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task<Book?> CreateAsync(Book bookModel);
        Task<Book?> UpdateAsync(Book book, UpdateBookDto bookModel);
        Task<Book?> DeleteAsync(Book bookModel);
        Task<List<Book>> FindBooksByTitlePatternAsync(string pattern);
    }
}