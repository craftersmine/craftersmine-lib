//Copyright craftersmine (c) 2015

//Documentation translated Google Translate

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.Configuration.Exceptions
{
    /// <summary>
    /// Throws if the specified key can not be obtained in this type of
    /// </summary>
    [Serializable]
    public class IncorrectKeyValueTypeException : Exception
    {
        /// <summary>
        /// Throws if the specified key can not be obtained in this type of
        /// </summary>
        public IncorrectKeyValueTypeException() { }
        /// <summary>
        /// Throws if the specified key can not be obtained in this type of
        /// </summary>
        /// <param name="message">Exception message</param>
        public IncorrectKeyValueTypeException(string message) : base(message) { }
        /// <summary>
        /// Throws if the specified key can not be obtained in this type of
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="inner">Inner exception</param>
        public IncorrectKeyValueTypeException(string message, Exception inner) : base(message, inner) { }
    }
}
