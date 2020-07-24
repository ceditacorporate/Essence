using System;
using Android.Views;
using Cedita.Essense.Mobile.CustomUI;
using Cedita.Essense.Mobile.Droid.CustomRenderers;
using Cedita.Essense.Mobile.Enums;
using Com.Tomergoldst.Tooltips;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using static Com.Tomergoldst.Tooltips.ToolTipsManager;

[assembly: ResolutionGroupName("Cedita.Essense.Mobile")]
[assembly: ExportEffect(typeof(DroidTooltipEffect), nameof(TooltipEffect))]
namespace Cedita.Essense.Mobile.Droid.CustomRenderers
{
    public class DroidTooltipEffect : PlatformEffect
    {
        ToolTip toolTipView;
        ToolTipsManager toolTipsManager;
        ITipListener listener;

        public DroidTooltipEffect()
        {
            listener = new TipListener();
            toolTipsManager = new ToolTipsManager(listener);
        }

        void OnTap(object sender, EventArgs e)
        {
            var control = Control ?? Container;

            var text = TooltipEffect.GetText(Element);

            if (!string.IsNullOrEmpty(text))
            {
                ToolTip.Builder builder;
                var parentContent = control.RootView;

                var position = TooltipEffect.GetPosition(Element);
                switch (position)
                {
                    case TooltipPosition.Top:
                        builder = new ToolTip.Builder(control.Context, control, parentContent as ViewGroup, text.PadRight(80, ' '), ToolTip.PositionAbove);
                        break;
                    case TooltipPosition.Left:
                        builder = new ToolTip.Builder(control.Context, control, parentContent as ViewGroup, text.PadRight(80, ' '), ToolTip.PositionLeftTo);
                        break;
                    case TooltipPosition.Right:
                        builder = new ToolTip.Builder(control.Context, control, parentContent as ViewGroup, text.PadRight(80, ' '), ToolTip.PositionRightTo);
                        break;
                    default:
                        builder = new ToolTip.Builder(control.Context, control, parentContent as ViewGroup, text.PadRight(80, ' '), ToolTip.PositionBelow);
                        break;
                }

                builder.SetAlign(ToolTip.AlignLeft);
                builder.SetBackgroundColor(TooltipEffect.GetBackgroundColor(Element).ToAndroid());
                builder.SetTextColor(TooltipEffect.GetTextColor(Element).ToAndroid());

                toolTipView = builder.Build();

                toolTipsManager?.Show(toolTipView);
            }

        }

        protected override void OnAttached()
        {
            var control = Control ?? Container;
            control.Click += OnTap;
        }

        protected override void OnDetached()
        {
            var control = Control ?? Container;
            control.Click -= OnTap;
            toolTipsManager.FindAndDismiss(control);
        }

        class TipListener : Java.Lang.Object, ITipListener
        {
            public void OnTipDismissed(Android.Views.View p0, int p1, bool p2)
            {

            }
        }
    }
}
