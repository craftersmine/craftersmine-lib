using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.Configuration.Exceptions
{
    /// <summary>
    /// Выкидывается если конфигурационный файл поврежден или ключ "config" не найден
    /// </summary>
    [System.Serializable]
    public class ConfigurationCorruptedException : Exception
    {
        /// <summary>
        /// Выкидывается если конфигурационный файл поврежден или ключ "config" не найден
        /// </summary>
        public ConfigurationCorruptedException() { }
        /// <summary>
        /// Выкидывается если конфигурационный файл поврежден или ключ "config" не найден
        /// </summary>
        /// <param name="message">Сообщение исключения</param>
        public ConfigurationCorruptedException(string message) : base(message) { }
        /// <summary>
        /// Выкидывается если конфигурационный файл поврежден или ключ "config" не найден
        /// </summary>
        /// <param name="message">Сообщение исключения</param>
        /// <param name="inner">Входящее исключение</param>
        public ConfigurationCorruptedException(string message, Exception inner) : base(message, inner) { }
    }
}
