using GestionUsuariosWebApi.Helpers;
using GestionUsuariosWebApi.Models;
using GestionUsuariosWebApi.Services.Contracts;
using GestionUsuariosWebApi.Services.Impl;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace GestionUsuariosWebApi.Controllers
{
    /// <summary>
    ///     Web API para gestionar los usuarios
    /// </summary>
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        /// <summary>
        ///     Crea la instancia del servicio del usuario
        /// </summary>
        public UserController()
        {
            _userService = new UserService();
        }

        /// <summary>
        ///     Obtiene todos los usuarios
        /// </summary>
        /// <remarks>Obtiene todos los usuarios</remarks>
        /// <response code="200">OK. Devuelve todos los usuarios.</response>
        /// <response code="404">NotFound. No se ha encontrado ningún usuario.</response>
        /// <returns>Listado de todos los usuarios</returns>
        [HttpGet]
        [Route("get")]
        [ResponseType(typeof(IEnumerable<UserEntity>))]
        public async Task<IHttpActionResult> Get()
        {
            IEnumerable<UserEntity> users = await _userService.GetAllUsers();
            if (!users.Any())
            {
                return NotFound();
            }

            return Ok(users);
        }

        /// <summary>
        ///     Obtiene un usuario por su Id
        /// </summary>
        /// <remarks>Obtiene un usuario por su Id</remarks>
        /// <param name="id">Identificador del usuario</param>
        /// <response code="200">OK. Devuelve el usuario del identificador especificado.</response>
        /// <response code="404">NotFound. No se ha encontrado ningún usuario.</response>
        /// <returns>Un objeto usuario</returns>
        [HttpGet]
        [Route("get/{id:int}")]
        [ResponseType(typeof(UserEntity))]
        public async Task<IHttpActionResult> GetById(int? id)
        {
            UserEntity userEntity = await _userService.GetUsersById(id);
            if (userEntity == null)
            {
                HttpResponseMessage response = CustomHttpResponse.SetNotFoundMessage("User ID not found.");
                throw new HttpResponseException(response);
            }

            return Ok(userEntity);
        }

        /// <summary>
        ///     Crea un nuevo usuario
        /// </summary>
        /// <remarks>Crea un nuevo usuario</remarks>
        /// <param name="usersEntity">Lista de usuarios a crear</param>
        /// <response code="200">OK. Devuelve un mensaje de que el usuario ha sido creado correctamente.</response>
        /// <response code="400">BadRequest. La creación del usuario ha fallado.</response>
        /// <returns>Respuesta HTTP indicando si el usuario ha sido creado o no</returns>
        [HttpPost]
        [Route("create")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> Create([FromBody] List<UserEntity> usersEntity)
        {
            await _userService.AddUser(usersEntity);
            int totalEntriesAffected = await _userService.SaveUser();
            if (totalEntriesAffected > 0)
            {
                return Ok("User(s) added successfully.");
            }

            return BadRequest("User(s) creation has failed.");
        }

        /// <summary>
        ///     Modifica un usuario
        /// </summary>
        /// <remarks>Modifica un usuario</remarks>
        /// <param name="usersEntity"></param>
        /// <response code="200">OK. Devuelve un mensaje de que el usuario ha sido actualizado correctamente.</response>
        /// <response code="404">NotFound. El identificador del usuario no existe.</response>
        /// <returns>Respuesta HTTP indicando si el usuario ha sido modificado o no</returns>
        [HttpPut]
        [Route("update")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> Update([FromBody] List<UserEntity> usersEntity)
        {
            List<UserEntity> usersEntityFound = _userService.GetUsersListInclude(usersEntity).ToList();
            if (usersEntityFound == null)
            {
                HttpResponseMessage response = CustomHttpResponse.SetNotFoundMessage("User ID not found.");
                throw new HttpResponseException(response);
            }

            await _userService.UpdateUser(usersEntity);
            int totalEntriesAffected = await _userService.SaveUser();
            if (totalEntriesAffected > 0)
            {
                return Ok("User(s) updated successfully.");
            }

            return BadRequest("User(s) update has failed.");
        }

        /// <summary>
        ///     Elimina un usuario por su id
        /// </summary>
        /// <remarks>Elimina un usuario por su id</remarks>
        /// <param name="id">Identificador del usuario</param>
        /// <response code="200">OK. Devuelve un mensaje de que el usuario ha sido eliminado.</response>
        /// <response code="404">NotFound. No se ha encontrado ningún usuario.</response>
        /// <returns>Respuesta HTTP indicando si el usuario ha sido eliminado o no</returns>
        [HttpDelete]
        [Route("delete/{id:int}")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> Delete(int? id)
        {
            UserEntity userEntity = await _userService.GetUsersById(id);
            if (userEntity == null)
            {
                HttpResponseMessage response = CustomHttpResponse.SetNotFoundMessage("User ID not found.");
                throw new HttpResponseException(response);
            }

            await _userService.RemoveUser(id);
            int totalEntriesAffected = await _userService.SaveUser();
            if (totalEntriesAffected > 0)
            {
                return Ok("User deleted successfully.");
            }

            return BadRequest("User delete has failed.");
        }
    }
}