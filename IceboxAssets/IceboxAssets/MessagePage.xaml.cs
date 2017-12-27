using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IceboxAssets
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessagePage : ContentPage
    {
        public MessagePage(string msg)
        {
            InitializeComponent();
            this.lblMsg.Text = msg;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
           await Navigation.PopModalAsync();
        }
    }
}