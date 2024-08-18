// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using library.src.Application.Dtos.User;
// using library.src.Domain.Models;

// namespace library.src.Domain.Interfaces{
//     public interface IUserRepository{
//         Task<List<User>> GetAllAsync();
//         Task<User?> GetByIdAsync(int id);
//         Task<User?> CreateAsync(User userModel);
//         Task<User?> UpdateAsync(User user, UpdateUserDto userModel);
//         Task<User?> DeleteAsync(User userModel);
//         Task<List<User>> FindUsersByNamePatternAsync(string pattern);
//     }
// }