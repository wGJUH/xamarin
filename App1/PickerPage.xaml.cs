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
    public partial class PickerPage : ContentPage
    {
        public PickerPage()
        {
            InitializeComponent();
            initPicker();
        }


        private void initPicker()
        {
            picker.Items.Add("first");
            picker.Items.Add("second");
            picker.Items.Add("third");
            picker.Items.Add("fourth");
            picker.SelectedIndexChanged += onSelectedChanged;
        }

        private void onSelectedChanged(object sender, EventArgs e)
        {
            labelPickerResult.Text = picker.Items[picker.SelectedIndex];
        }
    }
}