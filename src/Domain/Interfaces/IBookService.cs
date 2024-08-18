using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library.src.Application.Dtos.Book;
using library.src.Domain.Models;


namespace library.src.Domain.Interfaces{
    public interface IBookService{
        Task<IEnumerable<BookDto>?> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task<Book?> CreateAsync(CreateBookDto createBook);
        Task<Book?> UpdateAsync(int id, UpdateBookDto updateBook);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<BookDto>?> FindBooksByTitleAsync(string pattern);
    }
}