/**
 * The following exception is thrown when an illegal move is made
 *Author: Scott Jenkins
 * Date: 2020-02-10
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameProject
{
    /// <summary>
    /// The exception thrown when an invalid play is preformed 
    /// </summary>
    [Serializable]
    class InvalidPlayException : Exception
    {
        /// <summary>
        /// Default Exception
        /// </summary>
        public InvalidPlayException() { }

        /// <summary>
        /// Error with custom error message
        /// </summary>
        /// <param name="message">Error message</param>
        public InvalidPlayException(string message) : base(message) { }
    }
}
