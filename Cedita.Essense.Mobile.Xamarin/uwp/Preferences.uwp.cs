using System.Collections.Generic;
using Cedita.Essense.Mobile.Xamarin.Enums;
using Cedita.Essense.Mobile.Xamarin.Interfaces;
using Cedita.Essense.Mobile.Xamarin.UWP.Injected;
using Newtonsoft.Json;
using Windows.Storage;

[assembly: Xamarin.Forms.Dependency(typeof(UserSettings))]
namespace Cedita.Essense.Mobile.Xamarin.UWP.Injected
{
    public class UserSettings : IUserSettings
    {
        public void SaveSetting<T>(string name, T value, SettingType type)
        {
            var localSettings = ApplicationData.Current.LocalSettings;
            localSettings.Values[name] = value;
        }

        public void SaveSetting(string name, List<string> values)
        {
            var localSettings = ApplicationData.Current.LocalSettings;
            var serialised = JsonConvert.SerializeObject(values);
            localSettings.Values[name] = serialised;
        }

        public T LoadSetting<T>(string name, SettingType type)
        {
                return (T)ApplicationData.Current.LocalSettings.Values[name];
        }

        public List<string> LoadSetting(string name)
        {
            var rv = new List<string>();
            var serialisedVars = LoadSetting<string>(name, SettingType.String);
            if (!string.IsNullOrEmpty(serialisedVars))
                rv.AddRange(JsonConvert.DeserializeObject<List<string>>(serialisedVars));
            return rv;
        }

        public void SetPrefName(string name)
        {
            // do nothing
        }

        public void RemoveSetting(string name)
        {
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey(name))
            {
                ApplicationData.Current.LocalSettings.Values[name]=string.Empty;
            }
        }

        public void RemoveSettings(List<string> names)
        {
            var name = names[0];
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey(name))
            {
                ApplicationData.Current.LocalSettings.Values[name] = string.Empty;
            }
        }
    }
}
