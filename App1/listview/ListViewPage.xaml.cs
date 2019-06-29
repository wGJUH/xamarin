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

        private int count = 0;
        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
                OnPropertyChanged("Count");
            }
        }

        public TextCell textCell = new TextCell { };
        //this field should be public to work with Binding via xaml
        public ObservableCollection<GroupingCollection<string, Phone>> PhoneGroups { get; set; } = new ObservableCollection<GroupingCollection<string, Phone>>();

        public List<Phone> Phones2 { get; set; } = new List<Phone>()
        {
            new Phone("first", "apple", 100)
        };

        public ListViewPage()
        {
            InitializeComponent();
            Title = "List View Page";

            //DataTamplate explain how should be show element in the list
            // randomListView.ItemTemplate = new DataTemplate(DataTemplateCustomCell);
            //BindingContext of the element require not exact property, but class that is owner of needed property
            randomListView.BindingContext = this;
            titleName.BindingContext = this;
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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            PopulateListItems();
            // DeleteListItems();
        }

        private async void DeleteListItems()
        {
            while (RunTimer)
            {
                var randomVal = new Random().Next(PhoneGroups.Count);
                Console.WriteLine(String.Format("delete line {0}", randomVal));
                PhoneGroups.RemoveAt(randomVal);
                await Task.Delay(3000);
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            RunTimer = false;
        }

        String[] companys = new String[] { "apple", "samsung", "huawei" };
        private async void PopulateListItems()
        {
            while (RunTimer)
            {
                InsertPhone(new Phone(String.Format("first {0}", Count++), companys[new Random().Next(companys.Length)], 100 * Math.Abs(new Random().Next())));
                await Task.Delay(1000);
            }
        }


        private void InsertPhone(Phone phone)
        {
            int index = PhoneGroups.IndexOf(PhoneGroups.Where(g => g.Name.Equals(phone.Company)).FirstOrDefault());

            if (index == -1)
            {
                PhoneGroups.Add(new GroupingCollection<string, Phone>(phone.Company, new List<Phone> { phone }));
            }
            else
            {
                PhoneGroups.ElementAt(index).Add(phone);
            }
        }
    }
}