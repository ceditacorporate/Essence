﻿using Cedita.Essense.Mobile.Xamarin.CustomUI;
using Cedita.Essense.Mobile.Xamarin.iOS.CustomRenderers;
using CoreGraphics;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRendererAttribute(typeof(IconView), typeof(iOSIconViewRenderer))]
namespace Cedita.Essense.Mobile.Xamarin.iOS.CustomRenderers
{
    public class iOSIconViewRenderer : ViewRenderer<IconView, UIImageView>
    {
        private bool _isDisposed;

        protected override void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }

            if (disposing && Control != null)
            {
                var image = Control.Image;
                var uIImage = image;
                if (image != null)
                {
                    uIImage.Dispose();
                    uIImage = null;
                }
            }

            _isDisposed = true;
            base.Dispose(disposing);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<IconView> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                var uIImageView = new UIImageView(CGRect.Empty)
                {
                    ContentMode = UIViewContentMode.ScaleAspectFit,
                    ClipsToBounds = true
                };
                SetNativeControl(uIImageView);
            }
            if (e.NewElement != null)
            {
                SetImage(e.OldElement);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == IconView.SourceProperty.PropertyName)
            {
                SetImage(null);
            }
            else if (e.PropertyName == IconView.ForegroundProperty.PropertyName)
            {
                SetImage(null);
            }
        }

        private void SetImage(IconView previous = null)
        {
            if (previous == null && !string.IsNullOrWhiteSpace(Element.Source))
            {
                var uiImage = new UIImage(Element.Source);
                uiImage = uiImage.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
                Control.TintColor = Element.Foreground.ToUIColor();
                Control.Image = uiImage;
                if (!_isDisposed)
                {
                    ((IVisualElementController)Element).NativeSizeChanged();
                }
            }
        }
    }
}
