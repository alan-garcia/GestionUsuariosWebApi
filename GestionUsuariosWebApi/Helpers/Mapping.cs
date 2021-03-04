using GestionUsuariosWebApi.Models;
using System.Collections.Generic;

namespace GestionUsuariosWebApi.Mappings
{
    /// <summary>
    ///     Contiene el mapeo de las clases personalizadas
    /// </summary>
    public class Mapping
    {
        /// <summary>
        ///     Convierte un objeto UserEntity en otro de tipo User
        /// </summary>
        /// <param name="userEntity">Un objeto de tipo UserEntity</param>
        /// <returns>Un objeto de tipo User</returns>
        public static User FromUserEntityToUser(UserEntity userEntity)
        {
            return new User
            {
                id = userEntity.Id,
                balance = userEntity.Balance,
                date = userEntity.Date,
                username = userEntity.Username
            };
        }

        /// <summary>
        ///     Convierte un User en otro de tipo UserEntity
        /// </summary>
        /// <param name="user">Un objeto de tipo User</param>
        /// <returns>Un objeto de tipo UserEntity</returns>
        public static UserEntity FromUserToUserEntity(User user)
        {
            return new UserEntity
            {
                Id = user.id,
                Balance = user.balance,
                Date = user.date,
                Username = user.username
            };
        }

        /// <summary>
        ///     Convierte una lista de User en una lista de UserEntity
        /// </summary>
        /// <param name="users">Lista de usuarios</param>
        /// <returns>Listado de usuarios de tipo UserEntity</returns>
        public static List<UserEntity> FromListUserToListUserEntity(List<User> users)
        {
            List<UserEntity> usersEntity = new List<UserEntity>();
            users.ForEach(balance =>
            {
                usersEntity.Add(
                    new UserEntity
                    {
                        Id = balance.id,
                        Balance = balance.balance,
                        Date = balance.date,
                        Username = balance.username
                    }
                );
            });

            return usersEntity;
        }

        /// <summary>
        ///     Convierte una lista de UserEntity en una lista de User
        /// </summary>
        /// <param name="usersEntity">Lista de usuarios de tipo UserEntity</param>
        /// <returns>Listado de usuarios de tipo User</returns>
        public static List<User> FromListUserEntityToListUser(List<UserEntity> usersEntity)
        {
            List<User> users = new List<User>();
            usersEntity.ForEach(balance =>
            {
                users.Add(
                    new User
                    {
                        id = balance.Id,
                        balance = balance.Balance,
                        date = balance.Date,
                        username = balance.Username
                    }
                );
            });

            return users;
        }
    }
}