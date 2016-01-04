//Copyright craftersmine (c) 2015

//Documentation translated Google Translate

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.Config.Exceptions
{
    /// <summary>
    /// Throws if the specified key is not found
    /// </summary>
    [System.Serializable]
    public class ConfigurationKeyNotFoundException : Exception
    {
        /// <summary>
        /// Throws if the specified key is not found
        /// </summary>
        public ConfigurationKeyNotFoundException() { }
        /// <summary>
        /// Throws if the specified key is not found
        /// </summary>
        /// <param name="message">Exception message</param>
        public ConfigurationKeyNotFoundException(string message) : base(message) { }
        /// <summary>
        /// Throws if the specified key is not found
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="inner">Inner exception</param>
        public ConfigurationKeyNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
