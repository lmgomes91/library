using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using library.src.Application.Dtos.Account;
using library.src.Domain.Interfaces;
using library.src.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace library.src.WebApi.Controllers
{
    [Route("account")]
    [ApiController]
    public class AccountController: ControllerBase{
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        
        public AccountController(UserManager<User> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterAccountDto registerDto){
            try
            {
                if(!ModelState.IsValid){
                    return BadRequest(ModelState);
                }

                var user = new User{
                    UserName = registerDto.Username,
                    Email = registerDto.Email
                };

                var createdUser = await _userManager.CreateAsync(user, registerDto.Password);

                if(createdUser.Succeeded){
                    var roleResult = await _userManager.AddToRoleAsync(user, "User");

                    if(roleResult.Succeeded){
                        return Ok(
                            new NewUserAccountDto{
                                UserName = user.UserName,
                                Email = user.Email,
                                Token = _tokenService.CreateToken(user)
                            }
                        );
                    } else{
                        return BadRequest(roleResult.Errors);
                    }
                } else {
                    return BadRequest(createdUser.Errors);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
