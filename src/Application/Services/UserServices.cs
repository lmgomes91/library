// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using library.src.Application.Dtos.User;
// using library.src.Application.Mappers;
// using library.src.Domain.Interfaces;
// using library.src.Domain.Models;

// namespace library.src.Application.Services{
//     class UserServices: IUserService{
//         private readonly IUserRepository _userRepository;
        
//         public UserServices(IUserRepository userRepository)
//         {
//             _userRepository = userRepository;
//         }

//         public async Task<User?> CreateAsync(CreateUserDto createUser){
//             try
//             {
//                 var userModel = createUser.ToUserFromCreateDto();

//                 return await _userRepository.CreateAsync(userModel);

//             }
//             catch (Exception)
//             {
//                 throw new Exception();
//             }
//         }

//         public async Task<bool> DeleteAsync(int id){
//             try
//             {
//                 var user = await _userRepository.GetByIdAsync(id);

//                 if (user == null)
//                 {
//                     return false;
//                 }

//                 var userModel = await _userRepository.DeleteAsync(user);

//                 if(userModel == null){
//                     return false;
//                 }

//                 return true;  
//             }
//             catch (Exception)
//             {
//                 throw new Exception();
//             }
//         }

//         public async Task<IEnumerable<UserDto>?> GetAllAsync()
//         {
//             try
//             {
//                 var users = await _userRepository.GetAllAsync();
            
//                 var usersDto = users.Select(b => b.ToUserDto());

//                 return usersDto;
//             }
//             catch (Exception)
//             {
//                 throw new Exception();
//             }
//         }

//         public async Task<User?> GetByIdAsync(int id)
//         {
//             try
//             {
//                 return await _userRepository.GetByIdAsync(id);
//             }
//             catch (Exception)
//             {
//                 throw new Exception();
//             }
//         }

//         public async Task<User?> UpdateAsync(int id, UpdateUserDto updateUser)
//         {
//             try
//             {
//                 var user = await _userRepository.GetByIdAsync(id);

//                 if (user == null)
//                 {
//                     return null;
//                 }

//                 return await _userRepository.UpdateAsync(user, updateUser);
//             }
//             catch (Exception)
//             {
                
//                 throw;
//             }
//         }

//         public async Task<IEnumerable<UserDto>?> FindUsersByNameAsync(string pattern){
//             try
//             {
//                 var users =  await _userRepository.FindUsersByNamePatternAsync($"%{pattern}%");

//                 var usersDto = users.Select(b => b.ToUserDto());

//                 return usersDto;
//             }
//             catch (Exception)
//             {
                
//                 throw;
//             }
//         }

//     }
// }