// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using library.src.Application.Dtos.User;
// using library.src.Domain.Models;


// namespace library.src.Application.Mappers
// {
//     public static class UserMappers{
//         public static UserDto ToUserDto(this User user){
//             return new UserDto{
//                 Email = user.Email,
//                 Id = user.Id,
//                 Name = user.Name
//             };
//         }

//         public static User ToUserFromCreateDto(this CreateUserDto createUser){
//             return new User{
//                 Email = createUser.Email,
//                 Name = createUser.Name,
//                 Password = createUser.Password
//             };
//         }
//     }
// }