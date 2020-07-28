using Android.Content;
using Android.Content.Res;
using Cedita.Essense.Mobile.Xamarin.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(DroidCustomEntryRenderer))]
namespace Cedita.Essense.Mobile.Xamarin.Droid.CustomRenderers
{
    public class DroidCustomEntryRenderer : EntryRenderer
    {
        public DroidCustomEntryRenderer(Context context)
            : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
                return;

            Control.BackgroundTintList = ColorStateList.ValueOf(Android.Graphics.Color.ParseColor("#EBEBEB"));
        }
    }
}
