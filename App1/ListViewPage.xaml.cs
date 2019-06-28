using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage : ContentPage
    {

        public TextCell textCell = new TextCell { };
        private ObservableCollection<Phone> phones = new ObservableCollection<Phone>();


        public ListViewPage()
        {
            InitializeComponent();
            Title = "List View Page";
            
            randomListView.HasUnevenRows = true;
            randomListView.ItemTemplate = new DataTemplate(DataTemplateViewCell);
            randomListView.ItemsSource = phones;
            PopulateListItems();
        }


        private ViewCell DataTemplateViewCell()
        {
            // привязка к свойству Name
            Label titleLabel = new Label { FontSize = 18 };
            titleLabel.SetBinding(Label.TextProperty, "Title");

            // привязка к свойству Company
            Label companyLabel = new Label();
            companyLabel.SetBinding(Label.TextProperty, "Company");

            // привязка к свойству Price
            Label priceLabel = new Label();
            priceLabel.SetBinding(Label.TextProperty, "Price");

            // создаем объект ViewCell.
            return new ViewCell
            {
                View = new StackLayout
                {
                    Padding = new Thickness(0, 5),
                    Orientation = StackOrientation.Vertical,
                    Children = { titleLabel, companyLabel, priceLabel }
                }
            };
        }

        private bool RunTimer = true;

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            RunTimer = false;

        }
        private async void PopulateListItems()
        {
            while (RunTimer)
            {
                Console.WriteLine(String.Format("add line {0}", phones.Count));
                phones.Add(new Phone(String.Format("first {0}", phones.Count), "apple", 100 * phones.Count));
                await Task.Delay(1000);
            }
        }
    }
}