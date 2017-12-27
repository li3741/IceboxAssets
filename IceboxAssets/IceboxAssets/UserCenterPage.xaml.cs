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
    public partial class UserCenterPage : ContentPage
    {
        public UserCenterPage()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //NavigationPage page = new NavigationPage(this.Parent as TabbedPage);
            await Navigation.PushModalAsync(new MessagePage("消息提示"));
        }
    }
}