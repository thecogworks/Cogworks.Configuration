using System.ComponentModel;
using System.Configuration;

namespace Cogworks.Configuration
{
    public static class AppSettings
    {
        public static T Get<T>(string key)
        {
            var value = default(T);
            var setting = ConfigurationManager.AppSettings[key];

            if (string.IsNullOrWhiteSpace(setting))
            {
                return value;
            }

            var converter = TypeDescriptor.GetConverter(typeof(T));
            value = (T)converter.ConvertFromInvariantString(setting);

            return value;
        }
    }
}
