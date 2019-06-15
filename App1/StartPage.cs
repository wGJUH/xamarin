using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1
{
    class StartPage : ContentPage
    {
        public StartPage()
        {
            Title = "SECOND PAGE";
            var label = new Label()
            {
                Text = "AnothePage"
            };

            var buttonBack = new Button
            {
                Text = "BACK"
            };

            buttonBack.Clicked += onBackClicked;

            var stack = new StackLayout
            {

                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            stack.Children.Add(label);
            stack.Children.Add(buttonBack);
            this.Content = stack;
        }

        private async void onBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }

}
