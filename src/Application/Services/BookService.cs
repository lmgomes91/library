using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library.src.Application.Dtos.Book;
using library.src.Application.Mappers;
using library.src.Domain.Interfaces;
using library.src.Domain.Models;


namespace library.src.Application.Services{
    public class BookServices : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookServices(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book?> CreateAsync(CreateBookDto createBook)
        {
            try
            {
                var bookModel = createBook.ToBookFomCreateDto();

                var book = await _bookRepository.CreateAsync(bookModel);

                return book;
                
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var book = await _bookRepository.GetByIdAsync(id);

                if (book == null || book.IsBorrowed)
                {
                    return false;
                }

                var bookModel = await _bookRepository.DeleteAsync(book);

                if(bookModel == null){
                    return false;
                }

                return true;   
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<IEnumerable<BookDto>?> GetAllAsync()
        {
            try
            {
                var books = await _bookRepository.GetAllAsync();
            
                var booksDto = books.Select(b => b.ToBookDto());

                return booksDto;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            try
            {
                return await _bookRepository.GetByIdAsync(id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<Book?> UpdateAsync(int id, UpdateBookDto updateBook)
        {
            try
            {
                var book = await _bookRepository.GetByIdAsync(id);

                if (book == null || book.IsBorrowed)
                {
                    return null;
                }

                return await _bookRepository.UpdateAsync(book, updateBook);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public async Task<IEnumerable<BookDto>?> FindBooksByTitleAsync(string pattern){
            try
            {
                var books =  await _bookRepository.FindBooksByTitlePatternAsync($"%{pattern}%");

                var booksDto = books.Select(b => b.ToBookDto());

                return booksDto;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

    }
}