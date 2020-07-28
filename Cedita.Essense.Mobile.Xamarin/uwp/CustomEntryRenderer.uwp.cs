using Cedita.Essense.Mobile.Xamarin.UWP.CustomRenderers;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(Entry), typeof(UWPCustomEntryRenderer))]
namespace Cedita.Essense.Mobile.Xamarin.UWP.CustomRenderers
{
    public class UWPCustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.CharacterCasing = CharacterCasing.Lower;
            }
        }
    }
}
