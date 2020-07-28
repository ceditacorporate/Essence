using Cedita.Essense.Mobile.Xamarin.CustomUI;
using Cedita.Essense.Mobile.Xamarin.iOS.CustomRenderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(iOSCustomEntryRenderer))]
namespace Cedita.Essense.Mobile.Xamarin.iOS.CustomRenderers
{
    public class iOSCustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.SpellCheckingType = UITextSpellCheckingType.No;
                Control.AutocapitalizationType = UITextAutocapitalizationType.None;
                Control.AutocorrectionType = UITextAutocorrectionType.No;
            }                
        }
    }
}
