using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(IceboxAssets.Droid.ScannerHelper))]//该处要依赖注入的是本类
namespace IceboxAssets.Droid
{
    public class ScannerHelper : IceboxAssets.DependencyService.IScannerHelper
    {
        public void InitScanner()
        {
            ZXing.Net.Mobile.Forms.WindowsUniversal.ZXingScannerViewRenderer.Init();
        }
    }
}
