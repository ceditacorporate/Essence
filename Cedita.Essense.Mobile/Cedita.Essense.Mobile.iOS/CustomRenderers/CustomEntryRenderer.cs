using Cedita.Essense.Mobile.CustomUI;
using Cedita.Essense.Mobile.iOS.CustomRenderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace Cedita.Essense.Mobile.iOS.CustomRenderers
{
    public class CustomEntryRenderer : EntryRenderer
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
