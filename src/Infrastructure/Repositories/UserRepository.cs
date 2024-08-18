// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using library.src.Application.Dtos.User;
// using library.src.Domain.Interfaces;
// using library.src.Domain.Models;
// using library.src.Infrastructure.Data;
// using Microsoft.AspNetCore.OutputCaching;
// using Microsoft.EntityFrameworkCore;

// namespace library.Repositories{
//     public class UserRepository : IUserRepository
//     {
//         private readonly ApplicationDBContext _context;
//         public UserRepository(ApplicationDBContext context)
//         {
//             _context = context;
//         }
//         public async Task<User?> CreateAsync(User userModel)
//         {
//             await _context.User.AddAsync(userModel);
//             await _context.SaveChangesAsync();
//             return userModel;
//         }

//         public async Task<User?> DeleteAsync(User userModel)
//         {
//             _context.User.Remove(userModel);
//             await _context.SaveChangesAsync();

//             return userModel;
//         }

//         public async Task<List<User>> FindUsersByNamePatternAsync(string pattern)
//         {
//             return await _context.User
//             .Where(u => EF.Functions.Like(u.Name, pattern))
//             .ToListAsync();
//         }

//         public async Task<List<User>> GetAllAsync()
//         {
//             return await _context.User.ToListAsync();
//         }

//         public async Task<User?> GetByIdAsync(int id)
//         {
//             return await _context.User.FindAsync(id);
//         }

//         public async Task<User?> UpdateAsync(User user, UpdateUserDto updateUser)
//         {
//             user.Email = updateUser.Email;
//             user.Name = updateUser.Name;
//             user.Password = updateUser.Password;

//             await _context.SaveChangesAsync();

//             return user;
//         }
//     }
// }