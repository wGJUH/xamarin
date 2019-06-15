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
    public partial class DatePickerPage : ContentPage
    {
        public DatePickerPage()
        {
            InitializeComponent();
            Title = "DatePickerPage";
            initDatePicker();
        }

        private void initDatePicker()
        {
            var datePicker = this.FindByName<DatePicker>("datePicker");
            datePicker.MaximumDate = DateTime.Now.AddDays(5);
            datePicker.MaximumDate = DateTime.Now.AddDays(-5);
            datePicker.DateSelected += DateSelected;
        }

        private void DateSelected(object sender, DateChangedEventArgs e)
        {
            this.FindByName<Label>("pickerDate").Text = e.NewDate.ToString("dd/MM/yyyy");
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}