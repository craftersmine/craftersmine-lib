//Copyright craftersmine (c) 2015

using System;
using System.Collections.Generic;
using System.IO;

using craftersmine.Configuration.Exceptions;

namespace craftersmine.Configuration
{
    /// <summary>
    /// Реализует класс управлением конфигурацией. Данный класс не может быть унаследован
    /// </summary>
    public sealed class Configuration
    {
        #region Поля
        private string[] _configFileContents;
        private Dictionary<string, string> _configContentsDict = new Dictionary<string, string>();
        private string _file;
        private bool _valKey = false;
        #endregion

        #region Конструкторы
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="craftersmine.Configuration.Configuration(string, bool)"/> и загружает файл
        /// </summary>
        /// <param name="file">Файл конфигурации</param>
        /// <param name="validateConfig">Проверить на существование ключа "config"</param>
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
        /// Инициализирует новый экземпляр <see cref="craftersmine.Configuration.Configuration(string, bool)"/> с проверкой на ключ "config" и загружает файл
        /// </summary>
        /// <param name="file">Файл конфигурации</param>
        public Configuration(string file)
        {
            _file = file;
            new Configuration(file, true);
        }
        #endregion

        #region Методы
        /// <summary>
        /// Получает строковое значение указанного ключа
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <returns>Строка указанного ключа</returns>
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
        /// Получает числовое значение указанного ключа
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <returns>Число указанного ключа</returns>
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
        /// Получает логическое значение указанного ключа
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <returns>true\false указанного ключа</returns>
        public bool GetBoolean(string key)
        {
            if (GetString(key) == "true")
                return true;
            else if (GetString(key) == "false")
                return false;
            else throw new IncorrectKeyValueTypeException("Ключ \"" + key + "\" не может быть преобразовать в тип Boolean");
        }
        /// <summary>
        /// Задает значение <see cref="System.String"/> указанного ключа
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="value">Задаваемое значение <see cref="System.String"/></param>
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
        /// Задает значение <see cref="System.Int32"/> указанного ключа
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="value">Задаваемое значение <see cref="System.Int32"/></param>
        public void SetInteger(string key, int value)
        {
            SetString(key, value.ToString());
        }
        /// <summary>
        /// Задает значение <see cref="System.Boolean"/> указанного ключа
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="value">Задаваемое значение <see cref="System.Boolean"/></param>
        public void SetBoolean(string key, bool value)
        {
            if (value)
                SetString(key, "true");
            else
                SetString(key, "false");
        }
        /// <summary>
        /// Сохраняет конфигурацию в файл
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
