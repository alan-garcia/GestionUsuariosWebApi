using GestionUsuariosWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionUsuariosWebApi.Repositories.Contracts
{
    /// <summary>
    ///     Interfaz del repositorio del usuario
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        ///     Obtiene todos los usuarios
        /// </summary>
        /// <returns>Listado de usuarios</returns>
        Task<IEnumerable<UserEntity>> GetAll();

        /// <summary>
        ///     Obtiene una lista de usuarios que haya sido especificado en dicha lista
        /// </summary>
        /// <param name="usersEntity">Lista de usuarios especificados</param>
        /// <returns>Listado de usuarios</returns>
        IEnumerable<UserEntity> GetListInclude(List<UserEntity> usersEntity);

        /// <summary>
        ///     Obtiene un usuario por su id
        /// </summary>
        /// <param name="idUsuario">Id del usuario especificado</param>
        /// <returns>Usuario que cumpla con el id especificado</returns>
        Task<UserEntity> GetById(int? idUsuario);

        /// <summary>
        ///     Crea nuevos usuarios
        /// </summary>
        /// <param name="usersEntity">Lista de usuarios a crear</param>
        Task Add(List<UserEntity> usersEntity);

        /// <summary>
        ///     Elimina a un usuario por su id
        /// </summary>
        /// <param name="idUsuario">Id del usuario</param>
        Task Remove(int? idUsuario);

        /// <summary>
        ///     Modifica a un usuario
        /// </summary>
        /// <param name="userEntity">Lista de usuarios a modificar</param>
        Task Update(List<UserEntity> userEntity);

        /// <summary>
        ///     Guarda un usuario en la base de datos
        /// </summary>
        /// <returns>Número de registros afectados</returns>
        Task<int> Save();
    }
}