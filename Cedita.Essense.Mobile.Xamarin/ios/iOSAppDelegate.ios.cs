
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Material;

namespace Cedita.Essense.Mobile.Xamarin.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {

        public static AppDelegate Self { get; private set; }
        public NSUserDefaults UserDefaults { get; set; }
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            AppDelegate.Self = this;

            Forms.Init();
            FormsMaterial.Init();

            LoadApplication(new Essense());

            return base.FinishedLaunching(app, options);
        }
    }
}
