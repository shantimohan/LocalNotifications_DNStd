using Plugin.LocalNotifications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LocalNotifications_DNStd
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        const int _SAMPLE_ID = 1;
        int _secondsToDelivery;

        public MainPage()
        {
            InitializeComponent();
        }

        void ScheduledSwitchToggled(object sender, ToggledEventArgs e)
        {
            ScheduleSecondsPicker.IsVisible = ScheduleSwitch.IsToggled;

            if (!ScheduleSwitch.IsToggled)
            {
                _secondsToDelivery = 0;
            }
        }

        void Handle_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            _secondsToDelivery = int.Parse(ScheduleSecondsPicker.Items[ScheduleSecondsPicker.SelectedIndex]);
        }

        void SendButtonClicked(object sender, EventArgs e)
        {
            if (_secondsToDelivery > 0)
            {
                CrossLocalNotifications.Current.Show(TitleEntry.Text, BodyEntry.Text, _SAMPLE_ID, DateTime.Now.AddSeconds(_secondsToDelivery));
            }
            else
            {
                CrossLocalNotifications.Current.Show(TitleEntry.Text, BodyEntry.Text, _SAMPLE_ID);
            }
        }

        private void CancelButtonClicked(object sender, EventArgs e)
        {

        }
    }
}
