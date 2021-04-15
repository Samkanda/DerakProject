///---------------------------------------------------------------------------------
///   Namespace:        Derak_Project
///   Class:            InvalidPlayException
///   Description:      Custom exception class for when the play is not valid
///   Authors:          Shoaib Ali, Luke Richards, Navpreet Kanda, Mubashir Malik
///   Date:             April 14, 2021
///---------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derak_Project
{
    /// <summary>
    /// InvalidPlayException extends exception class (custom exception class)
    /// </summary>
    public class InvalidPlayException : Exception
    {
        /// <summary>
        /// Parameterized constructor inherits base constructor
        /// </summary>
        /// <param name="message">Custom error message</param>
        public InvalidPlayException(string message) : base(message)
        {

        }
    }
}
