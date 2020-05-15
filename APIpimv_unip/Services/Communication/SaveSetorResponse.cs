using APIpimv_unip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Services.Communication
{
    public class SaveSetorResponse : BaseResponse
    {
        public Setor Setor { get; private set; }
        public SaveSetorResponse(bool success, string message, Setor setor) : base(success, message)
        {
            Setor =  setor;
        }
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="setor">Saved setor.</param>
        /// <returns>Response.</returns>
        public SaveSetorResponse(Setor setor) : this(true, string.Empty, setor)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveSetorResponse(string message) : this(false, message, null)
        { }
    }
}
