using APIpimv_unip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Services.Communication
{
    public class AulaResponse : BaseResponse
    {
        public Aula Aula { get; private set; }
        public AulaResponse(bool success, string message, Aula aula) : base(success, message)
        {
            Aula = aula;
        }
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="aula">Saved aula.</param>
        /// <returns>Response.</returns>
        public AulaResponse(Aula aula) : this(true, string.Empty, aula)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public AulaResponse(string message) : this(false, message, null)
        { }
    }
}
