// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using library.src.Application.Dtos.User;
// using library.src.Domain.Models;

// namespace library.src.Domain.Interfaces{
//     public interface IUserService{
//         Task<User?> CreateAsync(CreateUserDto createUser);
//         Task<bool> DeleteAsync(int id);
//         Task<IEnumerable<UserDto>?> GetAllAsync();
//         Task<User?> GetByIdAsync(int id);
//         Task<User?> UpdateAsync(int id, UpdateUserDto updateUser);
//         Task<IEnumerable<UserDto>?> FindUsersByNameAsync(string pattern);
//     }
// }