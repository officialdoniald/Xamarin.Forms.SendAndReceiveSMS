using SendAndReceiveSMS.CustomRenderer;
using SendAndReceiveSMS.iOS.CustomRenderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(OTPAutoFillControl), typeof(OTPAutoFillControlRenderer))]
namespace SendAndReceiveSMS.iOS.CustomRenderer
{
    public class OTPAutoFillControlRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                Control.TextContentType = UITextContentType.OneTimeCode;
            }
        }
    }
}