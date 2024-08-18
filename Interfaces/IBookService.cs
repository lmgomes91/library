using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library.Dtos;
using library.Dtos.Book;
using library.Models;


namespace library.Interfaces{
    public interface IBookService{
        Task<IEnumerable<BookDto>?> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task<Book?> CreateAsync(CreateBookDto createBook);
        Task<Book?> UpdateAsync(int id, UpdateBookDto updateBook);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<BookDto>?> FindBooksByTitleAsync(string pattern);
    }
}