/*
 * Exception handler for if an invalid decksize is passed
 *Author: Scott Jenkins 
 *Date: 2020-02-06
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameProject
{
    /// <summary>
    /// The exception thrown when a decksize invalid to Durak is input
    /// </summary>
    [Serializable]
    class InvalidDeckSizeException : Exception
    {
        /// <summary>
        /// Default Error.
        /// </summary>
        public InvalidDeckSizeException() {}

        /// <summary>
        /// Error with custom error message
        /// </summary>
        /// <param name="message">Error message</param>
        public InvalidDeckSizeException(string message) : base(message){}
    }
}
