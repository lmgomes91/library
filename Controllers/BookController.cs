using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library.Data;
using Microsoft.AspNetCore.Mvc;

namespace library.Controllers{
    [Route("books")]
    [ApiController]
    public class BookController: ControllerBase{

        private readonly ApplicationDBContext _context;
        public BookController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetResult(){
            var books = _context.Book.ToList();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id){
            var book = _context.Book.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }
    }
}