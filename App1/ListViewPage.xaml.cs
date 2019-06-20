using System;
using System.Collections.Generic;
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
        public ListViewPage()
        {
            InitializeComponent();
            Title = "List View Page";

            randomListView.ItemsSource = PopulateListItems();
        }

        private List<String> PopulateListItems()
        {
            var strings = new List<String>();

            for (int i = 0; i < 50000; i++)
            {
                strings.Add("item number " + i);
            }

            return strings;
        }
    }
}