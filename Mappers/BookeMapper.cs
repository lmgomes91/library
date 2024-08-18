using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library.Dtos;
using library.Models;


public static class BookMappers{
    public static BookDto ToBookDto(this Book book){
        return new BookDto{
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Edition = book.Edition,
            IsBorrowed = book.IsBorrowed
        };
    }

    public static Book ToBookFomCreateDto(this CreateBookDto createBook){
        return new Book{
            Title = createBook.Title,
            Author = createBook.Author,
            Edition = createBook.Edition,
            IsBorrowed = createBook.IsBorrowed
        };
    }
}