using APIpimv_unip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Services.Communication
{
    public class UsuarioResponse : BaseResponse
    {
        public Usuario Usuario { get; private set; }
        public UsuarioResponse(bool success, string message, Usuario usuario) : base(success, message)
        {
            Usuario = usuario;
        }
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="usuario">Saved usuario.</param>
        /// <returns>Response.</returns>
        public UsuarioResponse(Usuario usuario) : this(true, string.Empty, usuario)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public UsuarioResponse(string message) : this(false, message, null)
        { }
    }
}
