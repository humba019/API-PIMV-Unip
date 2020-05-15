using APIpimv_unip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Services.Communication
{
    public class PeriodoResponse : BaseResponse
    {
        public Periodo Periodo { get; private set; }
        public PeriodoResponse(bool success, string message, Periodo periodo) : base(success, message)
        {
            Periodo = periodo;
        }
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="periodo">Saved periodo.</param>
        /// <returns>Response.</returns>
        public PeriodoResponse(Periodo periodo) : this(true, string.Empty, periodo)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public PeriodoResponse(string message) : this(false, message, null)
        { }
    }
}
