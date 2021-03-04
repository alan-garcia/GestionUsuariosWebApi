using GestionUsuariosWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionUsuariosWebApi.Services.Contracts
{
    /// <summary>
    ///     Interfaz para la capa de servicio del usuario
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        ///     Obtiene todos los usuarios
        /// </summary>
        /// <returns>Listado de usuarios</returns>
        Task<IEnumerable<UserEntity>> GetAllUsers();

        /// <summary>
        ///     Obtiene una lista de usuarios que haya sido especificado en dicha lista
        /// </summary>
        /// <param name="usersEntity">Lista de usuarios especificados</param>
        /// <returns>Listado de usuarios</returns>
        IEnumerable<UserEntity> GetUsersListInclude(List<UserEntity> usersEntity);

        /// <summary>
        ///     Obtiene un usuario por su id
        /// </summary>
        /// <param name="id">Id del usuario especificado</param>
        /// <returns>Usuario que cumpla con el id especificado</returns>
        Task<UserEntity> GetUsersById(int? id);

        /// <summary>
        ///     Crea nuevos usuarios
        /// </summary>
        /// <param name="usersEntity">Lista de usuarios a crear</param>
        Task AddUser(List<UserEntity> usersEntity);

        /// <summary>
        ///     Elimina a un usuario por su id
        /// </summary>
        /// <param name="id">Id del usuario</param>
        Task RemoveUser(int? id);

        /// <summary>
        ///     Modifica a un usuario
        /// </summary>
        /// <param name="userEntity">Lista de usuarios a modificar</param>
        Task UpdateUser(List<UserEntity> userEntity);

        /// <summary>
        ///     Guarda un usuario en la base de datos
        /// </summary>
        /// <returns>Número de registros afectados</returns>
        Task<int> SaveUser();
    }
}
