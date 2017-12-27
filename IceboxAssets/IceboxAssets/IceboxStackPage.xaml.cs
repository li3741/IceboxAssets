using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using IceboxAssets.ViewModel;

namespace IceboxAssets
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IceboxStackPage : ContentPage
    {

        public IceboxStackPage()
        {
            InitializeComponent();
        }
        
        private void Take_Button_Clicked(object sender, EventArgs e)
        {
            //把物品取出来，做记录，同时更新空间里面的
            list_items.Remove();

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PutInIceBoxPage());
        }
    }
}