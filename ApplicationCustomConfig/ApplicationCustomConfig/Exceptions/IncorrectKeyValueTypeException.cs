using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.Configuration.Exceptions
{
    /// <summary>
    /// Выкидывается если указанный ключ не может быть получен в указанном типе
    /// </summary>
    [Serializable]
    public class IncorrectKeyValueTypeException : Exception
    {
        /// <summary>
        /// Выкидывается если указанный ключ не может быть получен в указанном типе
        /// </summary>
        public IncorrectKeyValueTypeException() { }
        /// <summary>
        /// Выкидывается если указанный ключ не может быть получен в указанном типе
        /// </summary>
        /// <param name="message">Сообщение исключения</param>
        public IncorrectKeyValueTypeException(string message) : base(message) { }
        /// <summary>
        /// Выкидывается если указанный ключ не может быть получен в указанном типе
        /// </summary>
        /// <param name="message">Сообщение исключения</param>
        /// <param name="inner">Входящее исключение</param>
        public IncorrectKeyValueTypeException(string message, Exception inner) : base(message, inner) { }
    }
}
