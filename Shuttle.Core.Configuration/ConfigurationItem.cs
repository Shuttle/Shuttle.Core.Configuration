using System;
using System.Configuration;

namespace Shuttle.Core.Configuration
{
    public class ConfigurationItem<T>
    {
        private readonly T _item;

        public ConfigurationItem(T item)
        {
            _item = item;
        }

        public T GetValue()
        {
            return _item;
        }

        public static ConfigurationItem<T> ReadSetting(string key)
        {
            return ReadSetting(key, true, default(T));
        }

        public static ConfigurationItem<T> ReadSetting(string key, T @default)
        {
            return ReadSetting(key, false, @default);
        }

        private static ConfigurationItem<T> ReadSetting(string key, bool required, T @default)
        {
            var setting = ConfigurationManager.AppSettings[key];

            if (string.IsNullOrEmpty(setting))
            {
                if (required)
                {
                    throw new ApplicationException(string.Format(Resources.ConfigurationItemMissing, key));
                }

                return new ConfigurationItem<T>(@default);
            }

            if (string.IsNullOrEmpty(setting))
            {
                return new ConfigurationItem<T>(@default);
            }

            return new ConfigurationItem<T>(
                (T)Convert.ChangeType(setting, Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T)));
        }

        private static object ProtectedValue(string key, string value)
        {
            var keysValue = ConfigurationManager.AppSettings["ConfigurationItemSensitiveKeys"];
            var useContains = false;

            if (string.IsNullOrEmpty(keysValue))
            {
                useContains = true;

                keysValue = "password;pwd";
            }

            var keys = keysValue.Split(new[] {";", ","}, StringSplitOptions.RemoveEmptyEntries);

            foreach (var sensitiveKey in keys)
            {
                if (useContains)
                {
                    if (key.ToLower().Contains(sensitiveKey))
                    {
                        return "(sensitive data)";
                    }
                }
                else
                {
                    if (key.Equals(sensitiveKey, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return "(sensitive data)";
                    }
                }
            }

            return value;
        }
    }
}