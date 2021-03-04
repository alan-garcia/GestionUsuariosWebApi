using GestionUsuariosWebApi.Mappings;
using GestionUsuariosWebApi.Models;
using GestionUsuariosWebApi.Repositories.Contracts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace GestionUsuariosWebApi.Repositories.Impl
{
    /// <summary>
    ///     Implementación de la capa de repositorio para la interfaz IUserRepository
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly GestionUsuariosWebApiEntities _gestionUsuariosEntities;

        /// <summary>
        ///     Instancia un nuevo DbContext
        /// </summary>
        public UserRepository()
        {
            _gestionUsuariosEntities = new GestionUsuariosWebApiEntities();
        }

        /// <summary>
        ///     Obtiene todos los usuarios
        /// </summary>
        /// <returns>Listado de usuarios</returns>
        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            List<User> users = await _gestionUsuariosEntities.User.ToListAsync();
            return Mapping.FromListUserToListUserEntity(users);
        }

        /// <summary>
        ///     Obtiene un usuario por su id
        /// </summary>
        /// <param name="idUsuario">Id del usuario especificado</param>
        /// <returns>Usuario que cumpla con el id especificado</returns>
        public async Task<UserEntity> GetById(int? idUsuario)
        {
            UserEntity userEntity = null;
            User user = await _gestionUsuariosEntities.User
                                .AsNoTracking()
                                .SingleOrDefaultAsync(b => b.id == idUsuario);
            if (user != null)
            {
                userEntity = Mapping.FromUserToUserEntity(user);
            }

            return userEntity;
        }

        /// <summary>
        ///     Obtiene una lista de usuarios que haya sido especificado en dicha lista
        /// </summary>
        /// <param name="usersEntity">Lista de usuarios especificados</param>
        /// <returns>Listado de usuarios</returns>
        public IEnumerable<UserEntity> GetListInclude(List<UserEntity> usersEntity)
        {
            List<UserEntity> usersListEntity = null;
            if (usersEntity.Any())
            {
                usersListEntity = usersEntity;
            }

            return usersListEntity;
        }

        /// <summary>
        ///     Crea nuevos usuarios
        /// </summary>
        /// <param name="usersEntity">Lista de usuarios a crear</param>
        public async Task Add(List<UserEntity> usersEntity)
        {
            List<User> users = Mapping.FromListUserEntityToListUser(usersEntity);
            _gestionUsuariosEntities.User.AddRange(users);
        }

        /// <summary>
        ///     Elimina a un usuario por su id
        /// </summary>
        /// <param name="id">Id del usuario</param>
        public async Task Remove(int? id)
        {
            UserEntity userEntity = await GetById(id);
            User user = Mapping.FromUserEntityToUser(userEntity);
            _gestionUsuariosEntities.User.Attach(user);
            _gestionUsuariosEntities.User.Remove(user);
        }

        /// <summary>
        ///     Modifica a un usuario
        /// </summary>
        /// <param name="usersEntity">Lista de usuarios a modificar</param>
        public async Task Update(List<UserEntity> usersEntity)
        {
            List<User> users = Mapping.FromListUserEntityToListUser(usersEntity);
            users.ForEach(user =>
                _gestionUsuariosEntities.Entry(user).State = EntityState.Modified
            );
        }

        /// <summary>
        ///     Guarda un usuario en la base de datos
        /// </summary>
        /// <returns>Número de registros afectados</returns>
        public async Task<int> Save()
        {
            return await _gestionUsuariosEntities.SaveChangesAsync();
        }
    }
}