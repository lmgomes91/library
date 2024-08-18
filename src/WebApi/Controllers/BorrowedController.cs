using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library.src.Application.Extensions;
using library.src.Domain.Interfaces;
using library.src.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;




namespace library.src.WebApi.Controllers
{
    [Route("borrowed")]
    [ApiController]
    public class BorrowedController : ControllerBase{
        private readonly IBorrowedService _service;
        
        public BorrowedController(IBorrowedService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserBorrowed(){
            var username = User.GetUsername();

            var userBorrowed = await _service.GetUserBorrowed(username);

            return Ok(userBorrowed);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateBorrowed([FromBody] int bookId){
            var username = User.GetUsername();
            
            var borrowed = await _service.CreateBorrowed(username, bookId);

            if(!borrowed){
                return BadRequest("Failed to borrow the book");
            }

            return Ok();
        }

    }
}