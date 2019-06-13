using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App1
{
    public class Stepper
    {
        public Stepper(StackLayout rootView)
        {
            RootView = rootView;
        }

        Frame frame = new Frame
        {
            BorderColor = Color.Red,
            HorizontalOptions = LayoutOptions.CenterAndExpand,
            VerticalOptions = LayoutOptions.Start

        };

        StackLayout stack = new StackLayout
        {
            HorizontalOptions = LayoutOptions.Fill,
            VerticalOptions = LayoutOptions.Fill
        };

        Label stepperLab = new Label
        {
            Text = "Stepper",
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Start

        };

        Xamarin.Forms.Stepper stepper = new Xamarin.Forms.Stepper
        {
            Maximum = 10,
            Minimum = -10,
            Increment = 2
        };
        public void addViews()
        {
            addView(frame);
            frame.Content = stack;
            stack.Children.Add(stepperLab);
            stack.Children.Add(stepper);
            stepper.ValueChanged += onValueChanged;
        }

        private void onValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (sender is Xamarin.Forms.Stepper)
            {
                stepperLab.Text = stepperLab.Text + e.NewValue;
            }
        }

        public StackLayout RootView { get; }

        private void addView(View view)
        {
            RootView.Children.Add(view);
        }
    }
}