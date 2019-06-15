using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Resources;

namespace App1
{

    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        bool NEED_POPULATE = false;
        public MainPage()
        {
            InitializeComponent();
            Title = "MAIN PAGE";
            this.FindByName<StackLayout>("stack").BackgroundColor = Color.Aquamarine;
            if (NEED_POPULATE) populateItems();
            btn_first.Clicked += datePickerPageOpen;
            btn_second.Clicked += onNextPageClicked;
            btn_third.Clicked += onStepperPageOpenClicked;
            addPicker();
        }

        private async void onStepperPageOpenClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StepperPage());
        }

        private async void onNextPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DatePickerPage());
        }

        private void addPicker()
        {
            Picker picker = new Picker
            {
                Title = "Random Picker"
            };

            picker.Items.Add("first");
            picker.Items.Add("second");
            picker.Items.Add("third");
            picker.Items.Add("fourth");
            picker.SelectedIndexChanged += onSelectedChanged;
            addView(picker);
        }

        private void onSelectedChanged(object sender, EventArgs e)
        {
            Picker picker = (sender as Picker);
            this.FindByName<Label>("welcome").Text = picker.Items[picker.SelectedIndex];
        }

        private void onSecondClicked(object sender, EventArgs e)
        {
            showTimePicker();
        }

        private void showTimePicker()
        {
            TimePicker timePicker = new TimePicker
            {
                Time = new TimeSpan(17, 0, 0)
            };
            addView(timePicker);
        }

        private void addView(View item)
        {
            this.FindByName<StackLayout>("stack").Children.Add(item);
        }

        private void populateItems()
        {
            for (int i = 1; i <= 5; i++)
            {
                stack.Children.Add(
                   new Label
                   {
                       Text = "position: " + i,
                       FontSize = 14 * i,
                       HorizontalOptions = LayoutOptions.StartAndExpand,
                       HorizontalTextAlignment = TextAlignment.Start,
                       TextColor = Color.Blue
                   });
            }
        }

        private async void datePickerPageOpen(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DatePickerPage());
        }




        private void onButtonClicked(object sender, EventArgs e)
        {
            if ((sender as Button).Id == btn_first.Id)
            {
                btn_first.Text = "second";
                btn_second.Text = "first";
            }
            else
            {
                btn_first.Text = "first";
                btn_second.Text = "second";
            }
        }
    }
}
