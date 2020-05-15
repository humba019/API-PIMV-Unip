using APIpimv_unip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Services.Communication
{
    public class EmprestimoResponse : BaseResponse
    {
        public Emprestimo Emprestimo { get; private set; }
        public EmprestimoResponse(bool success, string message, Emprestimo emprestimo) : base(success, message)
        {
            Emprestimo = emprestimo;
        }
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="emprestimo">Saved emprestimo.</param>
        /// <returns>Response.</returns>
        public EmprestimoResponse(Emprestimo emprestimo) : this(true, string.Empty, emprestimo)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public EmprestimoResponse(string message) : this(false, message, null)
        { }
    }
}
