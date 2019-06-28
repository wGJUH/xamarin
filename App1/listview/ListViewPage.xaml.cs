using App1.listview;
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
        //this field should be public to work with Binding via xaml
        public ObservableCollection<Phone> Phones { get; set; } = new ObservableCollection<Phone>();

        public List<Phone> Phones2 { get; set; } = new List<Phone>()
        {
            new Phone("first", "apple", 100)
        };

        public ListViewPage()
        {
            InitializeComponent();
            Title = "List View Page";

            //DataTamplate explain how should be show element in the list
            randomListView.ItemTemplate = new DataTemplate(DataTemplateCustomCell);
            //BindingContext of the element require not exact property, but class that is owner of needed property
            randomListView.BindingContext = this;
            PopulateListItems();
        }



        private CustomCell DataTemplateCustomCell()
        {
            CustomCell customCell = new CustomCell()
            {
                ImageWidth = 45,
                ImageHeight = 60
            };
            customCell.SetBinding(CustomCell.TitleProperty, "Title");
            customCell.SetBinding(CustomCell.PriceProperty, "Price");
            customCell.SetBinding(CustomCell.CompanyProperty, "Company");
            customCell.SetBinding(CustomCell.ImageProperty, "ImagePath");
            return customCell;
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
                Console.WriteLine(String.Format("add line {0}", Phones.Count));
                Phones.Add(new Phone(String.Format("first {0}", Phones.Count), "apple", 100 * Phones.Count));

                await Task.Delay(1000);
            }
        }
    }
}