using Android.App;
using Android.OS;

namespace Cedita.Essense.Mobile.Xamarin.Droid
{
    [Activity]
    public class MainActivity : Activity
    {
        public static Activity Activity { get; private set; }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Activity = this;
        }
    }
}
