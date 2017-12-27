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
    public partial class PutInIceBoxPage : ContentPage
    {
        public PutInIceBoxPage()
        {
            InitializeComponent();
        }

        private async void btn_Scanner_Clicked(object sender, EventArgs e)
        {
            var scanner = new ZXing.Mobile.MobileBarcodeScanner();
            var result = await scanner.Scan();
            System.Diagnostics.Debug.WriteLine(result.Text);

        }
    }
}