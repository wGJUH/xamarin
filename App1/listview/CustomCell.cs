using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1.listview
{
    class CustomCell : ViewCell
    {
        public Label TitleLabel { get; set; }
        public Label CompanyLabel { get; set; } = new Label();
        public Label PriceLabel { get; set; } = new Label();

        public Image ImageCell {get; set;}

        public int ImageHeight { get; set; }

        public int ImageWidth { get; set; }

        public CustomCell()
        {

            TitleLabel = new Label
            {
                TextColor = Color.Red,
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start
            };

            ImageCell = new Image
            {
                Source = new UriImageSource()
                {
                    Uri = new Uri("https://dl2.macupdate.com/images/icons256/49739.png?d=1557916398")
                }
            };


            Binding binding = new Binding
            {
                Source = ImageCell,
                Path = "IsLoading"
            };

            ActivityIndicator activityIndicator = new ActivityIndicator();
            activityIndicator.SetBinding(ActivityIndicator.IsRunningProperty, binding);

            Grid grid = new Grid
            {
                Children = { ImageCell, activityIndicator },
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center

            };

            StackLayout descStack = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { CompanyLabel, PriceLabel }
            };

            StackLayout imageDescStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { grid, descStack }
            };

            StackLayout stackLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { TitleLabel, imageDescStack }
            };

            View = stackLayout;
        }


        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(string), typeof(CustomCell), "");

        public static readonly BindableProperty CompanyProperty =
            BindableProperty.Create("Company", typeof(string), typeof(CustomCell), "");

        public static readonly BindableProperty PriceProperty =
            BindableProperty.Create("Price", typeof(string), typeof(CustomCell), "");

        public static readonly BindableProperty ImageProperty =
            BindableProperty.Create("ImagePath", typeof(ImageSource), typeof(CustomCell), null);

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public string Company
        {
            get { return (string)GetValue(CompanyProperty); }
            set { SetValue(CompanyProperty, value); }
        }

        public string Price
        {
            get { return (string)GetValue(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }

        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                Console.WriteLine("begin Binding");
                TitleLabel.Text = Title;
                PriceLabel.Text = Price;
                CompanyLabel.Text = Company;
                ImageCell.Source = Image;
                ImageCell.WidthRequest = ImageWidth;
                ImageCell.HeightRequest = ImageHeight;
                Console.WriteLine("End Binding");
            }
        }

    }
}
