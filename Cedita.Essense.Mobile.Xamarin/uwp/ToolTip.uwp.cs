using Cedita.Essense.Mobile.Xamarin.CustomUI;
using Cedita.Essense.Mobile.Xamarin.Enums;
using Cedita.Essense.Mobile.Xamarin.UWP.CustomRenderers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ResolutionGroupName("Cedita.Essense.Mobile.Xamarin")]
[assembly: ExportEffect(typeof(UWPToolTipEffect), nameof(TooltipEffect))]
namespace Cedita.Essense.Mobile.Xamarin.UWP.CustomRenderers
{
    public class UWPToolTipEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var control = Control ?? Container;

            if (control is DependencyObject)
            {
                ToolTip toolTip = new ToolTip();
                toolTip.Content = TooltipEffect.GetText(Element);
                switch (TooltipEffect.GetPosition(Element))
                {
                    case TooltipPosition.Bottom:
                        toolTip.Placement = Windows.UI.Xaml.Controls.Primitives.PlacementMode.Bottom;
                        break;
                    case TooltipPosition.Top:
                        toolTip.Placement = Windows.UI.Xaml.Controls.Primitives.PlacementMode.Top;
                        break;
                    case TooltipPosition.Left:
                        toolTip.Placement = Windows.UI.Xaml.Controls.Primitives.PlacementMode.Left;
                        break;
                    case TooltipPosition.Right:
                        toolTip.Placement = Windows.UI.Xaml.Controls.Primitives.PlacementMode.Right;
                        break;
                    default:
                        return;
                }
                ToolTipService.SetToolTip(control, toolTip);
            }

        }

        protected override void OnDetached()
        {

        }
    }
}
