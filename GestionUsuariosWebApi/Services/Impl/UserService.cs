using GestionUsuariosWebApi.Models;
using GestionUsuariosWebApi.Repositories.Contracts;
using GestionUsuariosWebApi.Repositories.Impl;
using GestionUsuariosWebApi.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionUsuariosWebApi.Services.Impl
{
    /// <summary>
    ///     Implementación de la capa de servicio para la interfaz IUserService
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        ///     Instancia un nuevo repositorio
        /// </summary>
        public UserService()
        {
            _userRepository = new UserRepository();
        }

        /// <summary>
        ///     Obtiene todos los usuarios
        /// </summary>
        /// <returns>Listado de usuarios</returns>
        public async Task<IEnumerable<UserEntity>> GetAllUsers()
        {
            return await _userRepository.GetAll();
        }

        /// <summary>
        ///     Obtiene una lista de usuarios que haya sido especificado en dicha lista
        /// </summary>
        /// <param name="usersEntity">Lista de usuarios especificados</param>
        /// <returns>Listado de usuarios</returns>
        public IEnumerable<UserEntity> GetUsersListInclude(List<UserEntity> usersEntity)
        {
            return _userRepository.GetListInclude(usersEntity);
        }

        /// <summary>
        ///     Obtiene un usuario por su id
        /// </summary>
        /// <param name="id">Id del usuario especificado</param>
        /// <returns>Usuario que cumpla con el id especificado</returns>
        public async Task<UserEntity> GetUsersById(int? id)
        {
            return await _userRepository.GetById(id);
        }

        /// <summary>
        ///     Crea nuevos usuarios
        /// </summary>
        /// <param name="usersEntity">Lista de usuarios a crear</param>
        public async Task AddUser(List<UserEntity> usersEntity)
        {
            await _userRepository.Add(usersEntity);
        }

        /// <summary>
        ///     Elimina a un usuario por su id
        /// </summary>
        /// <param name="id">Id del usuario</param>
        public async Task RemoveUser(int? id)
        {
            await _userRepository.Remove(id);
        }

        /// <summary>
        ///     Modifica a un usuario
        /// </summary>
        /// <param name="userEntity">Lista de usuarios a modificar</param>
        public async Task UpdateUser(List<UserEntity> userEntity)
        {
            await _userRepository.Update(userEntity);
        }

        /// <summary>
        ///     Guarda un usuario en la base de datos
        /// </summary>
        /// <returns>Número de registros afectados</returns>
        public async Task<int> SaveUser()
        {
            return await _userRepository.Save();
        }
    }
}