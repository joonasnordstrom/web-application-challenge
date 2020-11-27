using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VincitWebApplication.Domain.Services.Communication
{
    /// <summary>
    /// Clinet-side response for api/diff GET endpoint
    /// </summary>
    public class DiffResponse : BaseResponse
    {
        public double Difference { get; set; }

        private DiffResponse(bool success, string message, in double diff) : base(success, message)
        {
            Difference = diff;
        }

        /// <summary>
        /// Creates an success response.
        /// </summary>
        /// <param name="message">Success message.</param>
        /// <returns>Response</returns>
        public DiffResponse(string message, in double diff) : this(true, message, diff)
        { }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response</returns>
        public DiffResponse(string id) : this(false, $"Sensor not found. Id: {id}.", 0)
        { }
    }
}
