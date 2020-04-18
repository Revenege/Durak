using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teseter
{
    /// <summary>
    /// Thrown when there are no players inside the Players collection.
    /// </summary>
    class InvalidPlayerCount : Exception
    {
        /// <summary>
        /// Default exception
        /// </summary>
        public InvalidPlayerCount()
        {

        }

        /// <summary>
        /// Exception with custom exception message
        /// </summary>
        /// <param name="message"></param>
        public InvalidPlayerCount(string message) : base(message) { }
    }
}
