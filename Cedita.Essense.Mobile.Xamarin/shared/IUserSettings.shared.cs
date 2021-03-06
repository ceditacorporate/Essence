﻿using System.Collections.Generic;
using Cedita.Essense.Mobile.Xamarin.Enums;

namespace Cedita.Essense.Mobile.Xamarin.Interfaces
{
    public interface IUserSettings
    {
        void SetPrefName(string name);

        void SaveSetting<T>(string name, T value, SettingType setting);

        void SaveSetting(string name, List<string> values);

        T LoadSetting<T>(string name, SettingType setting);

        void RemoveSetting(string name);

        void RemoveSettings(List<string> names);
    }
}
