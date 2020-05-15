using APIpimv_unip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Services.Communication
{
    public class ProfessorResponse : BaseResponse
    {
        public Professor Professor { get; private set; }
        public ProfessorResponse(bool success, string message, Professor professor) : base(success, message)
        {
            Professor = professor;
        }
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="professor">Saved professor.</param>
        /// <returns>Response.</returns>
        public ProfessorResponse(Professor professor) : this(true, string.Empty, professor)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public ProfessorResponse(string message) : this(false, message, null)
        { }
    }
}
