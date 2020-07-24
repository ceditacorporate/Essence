using System;
using Cedita.Essense.Mobile.CustomUI;
using Cedita.Essense.Mobile.UWP.CustomRenderers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportEffect(typeof(IconViewRenderer), nameof(IconView))]
namespace Cedita.Essense.Mobile.UWP.CustomRenderers
{
    public class IconViewRenderer : ViewRenderer<IconView, BitmapIcon>
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
