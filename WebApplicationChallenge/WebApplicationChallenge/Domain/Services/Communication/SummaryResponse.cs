using System;
using System.Collections.Generic;
using VincitWebApplication.DTOs;

namespace VincitWebApplication.Domain.Services.Communication
{
    /// <summary>
    /// Clinet-side response for CubesensorsDatum 
    /// </summary>
    public class SummaryResponse : BaseResponse
    {
        public List<SummaryDTO> Sensors { get; set; }

        private SummaryResponse(bool success, string message, in List<SummaryDTO> sensors) : base(success, message)
        {
            Sensors = sensors;
        }

        /// <summary>
        /// Creates an success response.
        /// </summary>
        /// <param name="message">Success message.</param>
        /// <returns>Response</returns>
        public SummaryResponse(string message, in List<SummaryDTO> sensors) : this(false, message, sensors)
        { }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response</returns>
        public SummaryResponse(string message) : this(false, message, null)
        { }
    }
}
