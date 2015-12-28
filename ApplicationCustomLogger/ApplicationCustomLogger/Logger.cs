using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace craftersmine.Logger
{
    public class Logger
    {
        private string _loadTime;
        public Logger(string directory, string name)
        {
            if (DateTime.Now.Hour < 10)
                 _loadTime = DateTime.Now.ToShortDateString() + "_" + DateTime.Now.ToShortTimeString();
            else _loadTime = DateTime.Now.ToShortDateString() + "_0" + DateTime.Now.ToShortTimeString();
            try
            {
                File.WriteAllText(Path.Combine(directory, name + "-" + _loadTime + ".log"), "");
            }
            catch
            {

            }
        }

        public void Record(string contents, string prefix)
        {

        }
    }
}
