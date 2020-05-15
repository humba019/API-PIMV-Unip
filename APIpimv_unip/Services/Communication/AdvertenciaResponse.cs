using APIpimv_unip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Services.Communication
{
    public class AdvertenciaResponse : BaseResponse
    {
        public Advertencia Advertencia { get; private set; }
        public AdvertenciaResponse(bool success, string message, Advertencia advertencia) : base(success, message)
        {
            Advertencia = advertencia;
        }
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="advertencia">Saved advertencia.</param>
        /// <returns>Response.</returns>
        public AdvertenciaResponse(Advertencia advertencia) : this(true, string.Empty, advertencia)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public AdvertenciaResponse(string message) : this(false, message, null)
        { }
    }
}
