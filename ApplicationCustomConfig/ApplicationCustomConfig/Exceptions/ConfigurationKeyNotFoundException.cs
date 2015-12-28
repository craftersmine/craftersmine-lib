using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.Configuration.Exceptions
{
    /// <summary>
    /// Выкидывается если указанный ключ не найден
    /// </summary>
    [System.Serializable]
    public class ConfigurationKeyNotFoundException : Exception
    {
        /// <summary>
        /// Выкидывается если указанный ключ не найден
        /// </summary>
        public ConfigurationKeyNotFoundException() { }
        /// <summary>
        /// Выкидывается если указанный ключ не найден
        /// </summary>
        /// <param name="message">Сообщение исключения</param>
        public ConfigurationKeyNotFoundException(string message) : base(message) { }
        /// <summary>
        /// Выкидывается если указанный ключ не найден
        /// </summary>
        /// <param name="message">Сообщение исключения</param>
        /// <param name="inner">Входящее исключение</param>
        public ConfigurationKeyNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
