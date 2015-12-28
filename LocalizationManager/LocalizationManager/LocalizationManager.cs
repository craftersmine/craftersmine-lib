//Copyright craftersmine (c) 2015

//Documentation translated Google Translate

using System.Collections.Generic;
using System.IO;
using craftersmine.Configuration;

namespace craftersmine.Localization
{
    public sealed class LocalizationManager
    {
        public string[] LoadableLocalizations { get; }

        private List<string> _loadableLocals = new List<string>();
        private Dictionary<string, string> _allLocalizaions = new Dictionary<string, string>();

        public LocalizationManager(string localsDirectory)
        {
            if (!Directory.Exists(localsDirectory))
            {
                if (!localsDirectory.EndsWith(@"\") || !localsDirectory.EndsWith("\\"))
                    localsDirectory += "\\";
                try
                {
                    foreach (var _localInDir in new DirectoryInfo(localsDirectory).GetFiles("*.lang", SearchOption.TopDirectoryOnly))
                    {
                        _loadableLocals.Add(_localInDir.Name);
                    }
                    foreach (var _local in _loadableLocals)
                    {
                        _allLocalizaions.Add(_local, new Configuration.Configuration(localsDirectory + _local + ".lang").GetString("local.name"));
                    }
                }
                catch
                {

                }
            }
        }

        public string[] GetLocals()
        {
            return _loadableLocals.ToArray();
        }
    }
}