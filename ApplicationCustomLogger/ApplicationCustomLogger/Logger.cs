using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace craftersmine.Logger
{
    /// <summary>
    /// Initializes a new instance of the logger. This class can not be inherited
    /// </summary>
    public sealed class Logger
    {
        private string _loadTime;
        private string _file;

        /// <summary>
        /// Prefix
        /// </summary>
        public enum Prefix
        {
            /// <summary>
            /// Information
            /// </summary>
            INFO,
            /// <summary>
            /// Completed operation
            /// </summary>
            FINE,
            /// <summary>
            /// Successful completed operaton
            /// </summary>
            FINEST,
            /// <summary>
            /// Warning
            /// </summary>
            WARNING,
            /// <summary>
            /// Error
            /// </summary>
            SEVERE,
            /// <summary>
            /// Critical Error
            /// </summary>
            ERROR
        }

        /// <summary>
        /// Initializes a new instance of the logger
        /// </summary>
        /// <param name="directory">Directory for logs</param>
        /// <param name="name">Log name</param>
        public Logger(string directory, string name)
        {
            if (DateTime.Now.Hour.ToString().Length < 2)
                 _loadTime = DateTime.Now.ToShortDateString() + "_0" + DateTime.Now.ToShortTimeString();
            else _loadTime = DateTime.Now.ToShortDateString() + "_" + DateTime.Now.ToShortTimeString();
            _file = Path.Combine(directory, name + "-" + _loadTime + ".log");
            File.WriteAllText(_file, "");
        }

        /// <summary>
        /// Writes the specified string to a file
        /// </summary>
        /// <param name="contents">What to write to a file</param>
        /// <param name="prefix">Prefix of the record</param>
        public void Record(string contents, string prefix)
        {
            string _date;
            if (DateTime.Now.Hour.ToString().Length < 2)
                _date = DateTime.Now.ToShortDateString() + " 0" + DateTime.Now.ToShortTimeString();
            else _date = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            File.AppendAllText(_file, _date + "[" + prefix + "]" + " " + contents);
        }

        /// <summary>
        /// Writes the specified string to a file
        /// </summary>
        /// <param name="contents">What to write to a file</param>
        /// <param name="prefix">Prefix of the record</param>
        public void Record(string contents, Prefix prefix)
        {
            Record(contents, prefix.ToString());
        }
    }
}
