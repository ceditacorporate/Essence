using System;
using Cedita.Essense.Mobile.Xamarin.CustomUI;
using Cedita.Essense.Mobile.Xamarin.UWP.CustomRenderers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportEffect(typeof(UWPIconViewRenderer), nameof(IconView))]
namespace Cedita.Essense.Mobile.Xamarin.UWP.CustomRenderers
{
    public class UWPIconViewRenderer : ViewRenderer<IconView, BitmapIcon>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<IconView> e)
        {
            if (Control != null)
            {
                var brush = new ImageBrush();
                if (e?.NewElement != null)
                    brush.ImageSource = new BitmapImage(new Uri(e.NewElement.Source, UriKind.Relative));

                Control.Foreground = brush;
            }
            base.OnElementChanged(e);
        }
    }
}
