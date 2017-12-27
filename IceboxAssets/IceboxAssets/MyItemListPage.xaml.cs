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
    public partial class MyItemListPage : ContentPage
    {
        public MyItemListPage()
        {
            InitializeComponent();
        
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //导航页面
            await Navigation.PushAsync(new AddMyItemPage());
        }
    }
}