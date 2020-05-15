using APIpimv_unip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Services.Communication
{
    public class DisciplinaResponse : BaseResponse
    {
        public Disciplina Disciplina { get; private set; }
        public DisciplinaResponse(bool success, string message, Disciplina disciplina) : base(success, message)
        {
            Disciplina = disciplina;
        }
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="disciplina">Saved disciplina.</param>
        /// <returns>Response.</returns>
        public DisciplinaResponse(Disciplina disciplina) : this(true, string.Empty, disciplina)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public DisciplinaResponse(string message) : this(false, message, null)
        { }
    }
}
