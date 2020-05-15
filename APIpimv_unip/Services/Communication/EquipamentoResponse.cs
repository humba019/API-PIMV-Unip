using APIpimv_unip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIpimv_unip.Services.Communication
{
    public class EquipamentoResponse : BaseResponse
    {      
        public Equipamento Equipamento { get; private set; }
        public EquipamentoResponse(bool success, string message, Equipamento equipamento) : base(success, message)
        {
            Equipamento = equipamento;
        }
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="equipamento">Saved equipamento.</param>
        /// <returns>Response.</returns>
        public EquipamentoResponse(Equipamento equipamento) : this(true, string.Empty, equipamento)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public EquipamentoResponse(string message) : this(false, message, null)
        { }

    }
}
