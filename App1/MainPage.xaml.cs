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
            btn_first.Clicked += datePickerPageOpen;
            btn_second.Clicked += onNextPageClicked;
            btn_third.Clicked += onStepperPageOpenClicked;
            btn_fourth.Clicked += onPickerOpenPageClicked;
            btn_fifth.Clicked += OnListViewBtnClicked;
        }

        private async void OnListViewBtnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListViewPage());
        }

        private async void onPickerOpenPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PickerPage());
        }

        private async void onStepperPageOpenClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StepperPage());
        }

        private async void onNextPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StartPage());
        }

        private async void datePickerPageOpen(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DatePickerPage());
        }
    }
}
