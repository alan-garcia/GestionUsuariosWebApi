using System;

namespace GestionUsuariosWebApi.Models
{
    /// <summary>
    ///     Representa al modelo User de la base de datos
    /// </summary>
    public class UserEntity
    {
        /// <summary>
        ///     Id del usuario
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Balance del usuario en Euros
        /// </summary>
        public decimal? Balance { get; set; }

        /// <summary>
        ///     Fecha de la realización del balance
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        ///     Nombre del usuario
        /// </summary>
        public string Username { get; set; }
    }
}