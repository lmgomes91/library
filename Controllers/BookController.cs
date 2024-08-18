using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library.Data;
using library.Dtos;
using library.Dtos.Book;
using library.Interfaces;
using library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace library.Controllers{
    [Route("books")]
    [ApiController]
    public class BookController: ControllerBase{

        private readonly IBookService _service;
        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var booksDto = await _service.GetAllAsync();

            return Ok(booksDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            var book = await _service.GetByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book.ToBookDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookDto createBook){
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var bookCreated = await _service.CreateAsync(createBook);

            if(bookCreated == null){
                return BadRequest();
            }

            return CreatedAtAction(
                nameof(GetById), 
                new {id = bookCreated.Id}, 
                bookCreated.ToBookDto()
            );

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBookDto updateBook){
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var bookModel = await _service.UpdateAsync(id, updateBook);

            if(bookModel == null){
                return NotFound();
            }

            return Ok(bookModel.ToBookDto());

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id){
            var deleted = await _service.DeleteAsync(id);

            if(!deleted){
                return NotFound();
            }

            return NoContent();

        }

    
        [HttpGet("search")]
        public async Task<IActionResult> FindByTitle([FromQuery] string pattern){
            var books = await _service.FindBooksByTitleAsync(pattern);

            return Ok(books);
        }

    }
}