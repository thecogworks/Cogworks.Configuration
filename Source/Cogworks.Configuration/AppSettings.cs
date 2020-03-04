using System.ComponentModel;
using System.Configuration;
using Umbraco.Core;

namespace Cogworks.Configuration
{
    public static class AppSettings
    {
        public static T Get<T>(string key, bool tryConvertTo = false)
        {
            var value = default(T);
            var setting = ConfigurationManager.AppSettings[key];

            if (string.IsNullOrWhiteSpace(setting)) return value;

            if (tryConvertTo)
            {
                var attemptConvert = setting.TryConvertTo<T>();
                if (attemptConvert.Success)
                {
                    value = attemptConvert.Result;
                }
            }
            else
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                value = (T)converter.ConvertFromInvariantString(setting);
            }

            return value;
        }
    }
}
