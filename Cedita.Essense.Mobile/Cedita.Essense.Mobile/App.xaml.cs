using System;
using System.Globalization;
using Cedita.Essense.Mobile.Interfaces;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Cedita.Essense.Mobile
{
    public partial class App : Application
    {
        public Size ScreenSize { get; private set; }
        public static App Self { get; private set; }
        public static bool IPhoneX { get; private set; } = false;
        public static bool iPad { get; private set; } = false;

        public App()
        {
            App.Self = this;

            var netLanguage = DependencyService.Get<ILocalize>().GetCurrent();
            Languages.Langs.Culture = new CultureInfo(netLanguage);
            DependencyService.Get<ILocalize>().SetLocale();

            DependencyService.Register<IUserSettings>();
            DependencyService.Register<IFileservice>();

            InitializeComponent();

            ScreenSize = new Size(DeviceDisplay.MainDisplayInfo.Width, DeviceDisplay.MainDisplayInfo.Height);

            if (DeviceInfo.Manufacturer == "Apple")
            {
                if (DeviceInfo.DeviceType == DeviceType.Physical)
                {
                    var vsnNum = DeviceInfo.Model.Contains("iPhone") ? DeviceInfo.Model.Split(new string[] { "iPhone" }, StringSplitOptions.None)[1] :
                        DeviceInfo.Model.Split(new string[] { "iPad" }, StringSplitOptions.None)[1];
                    var minmaj = vsnNum.Split(',');
                    var min = int.Parse(minmaj[1]);
                    var maj = int.Parse(minmaj[0]);

                    if (maj > 10)
                        IPhoneX = true;
                    else
                    {
                        if (maj == 10 && (min == 3 || min == 6))
                            IPhoneX = true;
                    }
                }
                else
                {
                    if (DeviceInfo.DeviceType == DeviceType.Virtual)
                    {
                        var name = DeviceInfo.Name.Split(' ')[1];
                        if (name.Contains("X"))
                            IPhoneX = true;
                        else
                        {
                            if (name.Contains("iPad") || name.Contains("Pro"))
                                IPhoneX = false;
                            else
                        if (int.Parse(name) >= 11)
                                IPhoneX = true;
                        }
                    }
                }
            }

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
