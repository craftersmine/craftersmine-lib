//Copyright craftersmine (c) 2015

//Documentation translated Google Translate

using System;
using System.Collections.Generic;
using System.IO;

using craftersmine.Config.Exceptions;

namespace craftersmine.Config
{
    /// <summary>
    /// Implements class configuration management. This class can not be inherited
    /// </summary>
    public sealed class Configuration
    {
        #region Fields
        private string[] _configFileContents;
        private Dictionary<string, string> _configContentsDict = new Dictionary<string, string>();
        private string _file;
        private bool _valKey = false;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="craftersmine.Config.Configuration(string, bool)"/> and loads the specified file
        /// </summary>
        /// <param name="file">Configuration File</param>
        /// <param name="validateConfig">Check the existence of the key "config"</param>
        public Configuration(string file, bool validateConfig)
        {
            _file = file;
            _valKey = validateConfig;
            _CheckFile(validateConfig);
            if (!validateConfig)
            {
                try
                {
                    _configFileContents = File.ReadAllLines(file);
                    foreach (var _currentLine in _configFileContents)
                    {
                        _configContentsDict.Add(_currentLine.Split(new char[] { '=' })[0], _currentLine.Split(new char[] { '=' })[1]);
                    }
                    if (_configContentsDict.Count == 0) throw new ConfigurationCorruptedException("Файл поврежден или не содержит ключей!");
                }
                catch (ConfigurationCorruptedException)
                {
                    throw new ConfigurationCorruptedException("Файл поврежден или не содержит ключей!");
                }
                catch { }
            }
            else
            {
                if (File.ReadAllLines(file)[0] == "config=true")
                {
                    try
                    {
                        _configFileContents = File.ReadAllLines(file);
                        foreach (var _currentLine in _configFileContents)
                        {
                            _configContentsDict.Add(_currentLine.Split(new char[] { '=' })[0], _currentLine.Split(new char[] { '=' })[1]);
                        }
                        if (_configContentsDict.Count <= 1) throw new ConfigurationCorruptedException("Файл не содержит ключей!");
                    }
                    catch (ConfigurationCorruptedException)
                    {
                        throw new ConfigurationCorruptedException("Файл не содержит ключей!");
                    }
                    catch { }
                }
                else throw new ConfigurationCorruptedException("Не найден ключ \"config\"");
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="craftersmine.Config.Configuration(string, bool)"/> with a check for the key "config", and loads the specified file
        /// </summary>
        /// <param name="file">Configuration File</param>
        public Configuration(string file)
        {
            _file = file;
            new Configuration(file, true);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Get string value of the specified key
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>The string specified key</returns>
        public string GetString(string key)
        {
            if (_configContentsDict.ContainsKey(key))
            {
                string value;
                if (_configContentsDict.TryGetValue(key, out value))
                    return value;
                else return string.Empty;
            }
            else throw new ConfigurationKeyNotFoundException("Ключ \"" + key + "\" не найден");
        }
        /// <summary>
        /// Gets the numerical value of the specified key
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>The number specified key</returns>
        public int GetInteger(string key)
        {
            try
            {
                return Convert.ToInt32(GetString(key));
            }
            catch
            { throw new IncorrectKeyValueTypeException("Ключ \"" + key + "\" не может быть преобразовать в тип Integer"); }
        }
        /// <summary>
        /// Gets a Boolean value of a specified key
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>true\false specified key</returns>
        public bool GetBoolean(string key)
        {
            if (GetString(key) == "true")
                return true;
            else if (GetString(key) == "false")
                return false;
            else throw new IncorrectKeyValueTypeException("Ключ \"" + key + "\" не может быть преобразовать в тип Boolean");
        }
        /// <summary>
        /// Sets the <see cref="System.String"/> specified key
        /// </summary>
        /// <param name="key">Ket</param>
        /// <param name="value">Setting value <see cref="System.String"/></param>
        public void SetString(string key, string value)
        {
            if (_configContentsDict.ContainsKey(key))
            {
                _configContentsDict.Remove(key);
                _configContentsDict.Add(key, value);
            }
            else
            {
                _configContentsDict.Add(key, value);
            }
        }
        /// <summary>
        /// Sets the <see cref="System.Int32"/> specified key
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Setting value <see cref="System.Int32"/></param>
        public void SetInteger(string key, int value)
        {
            SetString(key, value.ToString());
        }
        /// <summary>
        /// Sets the <see cref="System.Boolean"/> specified key
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Setting value <see cref="System.Boolean"/></param>
        public void SetBoolean(string key, bool value)
        {
            if (value)
                SetString(key, "true");
            else
                SetString(key, "false");
        }
        /// <summary>
        /// Saves the configuration file
        /// </summary>
        public void SaveConfig()
        {
            if (_valKey)
            {
                File.WriteAllText(_file, "");
                File.WriteAllText(_file, "config=true");
                using (StreamWriter sw = new StreamWriter(_file))
                {
                    foreach (var _currentPair in _configContentsDict)
                    {
                        sw.WriteLine(_currentPair.Key + "=" + _currentPair.Value);
                    }
                }
            }
            else
            {
                File.WriteAllText(_file, "");
                using (StreamWriter sw = new StreamWriter(_file))
                {
                    foreach (var _currentPair in _configContentsDict)
                    {
                        sw.WriteLine(_currentPair.Key + "=" + _currentPair.Value);
                    }
                }
            }
        }
        private void _CheckFile(bool valKey)
        {
            if (!File.Exists(_file))
                if (valKey)
                    File.WriteAllText(_file, "config=true");
        }
        #endregion
    }
}
