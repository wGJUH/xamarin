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
                var randomVal = new Random().Next(Phones.Count);
                Console.WriteLine(String.Format("delete line {0}", randomVal));
                Phones.RemoveAt(randomVal);
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
            Phones.CollectionChanged += Phones_CollectionChanged;
            while (RunTimer)
            {
                Phones.Add(new Phone(String.Format("first {0}", Phones.Count), companys[new Random().Next(companys.Length)], 100 * Phones.Count));
                Console.WriteLine(String.Format("add line {0}", Phones.Count));
                await Task.Delay(1000);
            }
        }

        private void Phones_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            InsertPhone((sender as ObservableCollection<Phone>).LastOrDefault());
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