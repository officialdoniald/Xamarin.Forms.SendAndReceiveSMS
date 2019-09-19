using System;
using MessageUI;
using SendAndReceiveSMS.Interfaces;
using UIKit;

namespace SendAndReceiveSMS.iOS.Receivers
{
    public class SendSms : ISendSms
    {
        public void Send(string body, string phoneNumber)
        {
            if (!MFMailComposeViewController.CanSendMail)
                return;

            MFMessageComposeViewController smsController = new MFMessageComposeViewController();

            smsController.Recipients = new[] { phoneNumber };
            smsController.Body = body;

            EventHandler<MFMessageComposeResultEventArgs> handler = null;
            handler = (sender, args) =>
            {
                smsController.Finished -= handler;

                var uiViewController = sender as UIViewController;
                if (uiViewController == null)
                {
                    throw new ArgumentException("sender");
                }

                uiViewController.DismissViewControllerAsync(true);
            };

            smsController.Finished += handler;

            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewControllerAsync(smsController, true);
        }
    }
}