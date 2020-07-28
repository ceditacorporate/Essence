using System.Collections.Generic;
using Android.Content;
using Cedita.Essense.Mobile.Xamarin.Droid.Injected;
using Cedita.Essense.Mobile.Xamarin.Enums;
using Cedita.Essense.Mobile.Xamarin.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(UserSettings))]
namespace Cedita.Essense.Mobile.Xamarin.Droid.Injected
{
    public class UserSettings : Java.Lang.Object, IUserSettings
    {
        ISharedPreferences Prefs { get; set; }
        public void SaveSetting<T>(string name, T value, SettingType type)
        {
            var editor = Prefs.Edit();
            editor.Remove(name);
            switch ((int)type)
            {
                case 0:
                    editor.PutBoolean(name, (bool)(object)value);
                    break;
                case 1:
                    editor.PutFloat(name, (float)(object)value);
                    break;
                case 2:
                    editor.PutInt(name, (int)(object)value);
                    break;
                case 3:
                    editor.PutLong(name, (long)(object)value);
                    break;
                case 4:
                    editor.PutString(name, (string)(object)value);
                    break;
            }
            editor.Commit();
        }

        public void SaveSetting(string name, List<string> values)
        {
            var editor = Prefs.Edit();
            editor.Remove(name);
            editor.PutStringSet(name, values);
            editor.Commit();
        }

        public T LoadSetting<T>(string name, SettingType type)
        {
            var nv = new object();
            switch ((int)type)
            {
                case 0:
                    nv = Prefs.GetBoolean(name, false);
                    break;
                case 1:
                    nv = Prefs.GetFloat(name, 0);
                    break;
                case 2:
                    nv = Prefs.GetInt(name, 0);
                    break;
                case 3:
                    nv = Prefs.GetLong(name, 0);
                    break;
                case 4:
                    nv = Prefs.GetString(name, "");
                    break;
            }
            return (T)nv;
        }

        public List<string> LoadSetting(string name)
        {
            var strList = Prefs.GetStringSet(name, null);
            var list = new List<string>();
            if (strList == null)
                return list;
            if (strList.Count == 0)
                return list;
            foreach (var i in strList)
                list.Add(i);

            return list;
        }

        public void SetPrefName(string name)
        {
            Prefs = MainActivity.Activity.GetSharedPreferences(name, FileCreationMode.Private);
        }

        public void RemoveSetting(string name)
        {
            var editor = Prefs.Edit();
            editor.Remove(name);
            editor.Commit();
        }

        public void RemoveSettings(List<string> names)
        {
            var editor = Prefs.Edit();
            foreach (var n in names)
                editor.Remove(n);
            editor.Commit();
        }
    }
}
