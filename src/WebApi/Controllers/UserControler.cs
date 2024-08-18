// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using library.src.Application.Dtos.User;
// using library.src.Application.Mappers;
// using library.src.Domain.Interfaces;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;

// namespace library.Controllers
// {
//     [Route("users")]
//     [ApiController]
//     public class UserController: ControllerBase{
//         private readonly IUserService _service;

//         public UserController(IUserService service)
//         {
//             _service = service;
//         }

//         [HttpGet]
//         public async Task<IActionResult> GetAll(){
//             var usersDto = await _service.GetAllAsync();

//             return Ok(usersDto);
//         }

//         [HttpGet("{id:int}")]
//         public async Task<IActionResult> GetById([FromRoute] int id){
//             var user = await _service.GetByIdAsync(id);

//             if (user == null)
//             {
//                 return NotFound();
//             }

//             return Ok(user.ToUserDto());
//         }

//         [HttpPost]
//         public async Task<IActionResult> Create([FromBody] CreateUserDto createUser){
//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(ModelState);
//             }
            
//             var userCreated = await _service.CreateAsync(createUser);

//             if(userCreated == null){
//                 return BadRequest();
//             }

//             return CreatedAtAction(
//                 nameof(GetById), 
//                 new {id = userCreated.Id}, 
//                 userCreated.ToUserDto()
//             );

//         }

//         [HttpPut]
//         [Route("{id:int}")]
//         public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserDto updateUser){
//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(ModelState);
//             }
            
//             var user = await _service.UpdateAsync(id, updateUser);

//             if(user == null){
//                 return NotFound();
//             }

//             return Ok(user.ToUserDto());

//         }

//         [HttpDelete]
//         [Route("{id:int}")]
//         public async Task<IActionResult> Delete([FromRoute] int id){
//             var deleted = await _service.DeleteAsync(id);

//             if(!deleted){
//                 return NotFound();
//             }

//             return NoContent();

//         }

//         [HttpGet("search")]
//         public async Task<IActionResult> FindByTitle([FromQuery] string pattern){
//             var users = await _service.FindUsersByNameAsync(pattern);

//             return Ok(users);
//         }



//     }
// }