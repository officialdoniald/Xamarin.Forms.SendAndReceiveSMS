using SendAndReceiveSMS.Events;
using SendAndReceiveSMS.Interfaces;
using System;
using Xamarin.Forms;

namespace SendAndReceiveSMS
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            GlobalEvents.OnSMSReceived += GlobalEvents_OnSMSReceived;
        }

        private void GlobalEvents_OnSMSReceived(object sender, SMSEventArgs e)
        {
            EntryMessage.Text = e.Message;
        }

        /// <summary>
        /// SMS Send.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<ISendSms>().Send(EntryNumber.Text, EntryMessage.Text);
        }
    }
}