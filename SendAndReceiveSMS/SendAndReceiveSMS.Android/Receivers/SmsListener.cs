using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Telephony;
using SendAndReceiveSMS.Events;

namespace SendAndReceiveSMS.Droid.Receivers
{
    [BroadcastReceiver]
    [IntentFilter(new[] { "android.provider.Telephony.SMS_RECEIVED" }, Priority = (int)IntentFilterPriority.HighPriority)]
    public class SmsListener : BroadcastReceiver
    {
        protected string message, address = string.Empty;

        public override void OnReceive(Context context, Intent intent)
        {
            if (intent.Action.Equals("android.provider.Telephony.SMS_RECEIVED"))
            {
                Bundle bundle = intent.Extras;
                if (bundle != null)
                {
                    try
                    {
                        var smsArray = (Java.Lang.Object[])bundle.Get("pdus");

                        foreach (var item in smsArray)
                        {
                            #pragma warning disable CS0618
                            var sms = SmsMessage.CreateFromPdu((byte[])item);
                            #pragma warning restore CS0618
                            address = sms.OriginatingAddress;
                            message = sms.MessageBody;

                            GlobalEvents.OnSMSReceived_Event(this, new SMSEventArgs() { PhoneNumber = address, Message = message });
                        }
                    }
                    catch (Exception)
                    {
                        //Something went wrong.
                    }
                }
            }
        }
    }
}