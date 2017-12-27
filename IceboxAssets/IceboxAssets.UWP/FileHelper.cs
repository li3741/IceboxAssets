using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;

[assembly:Dependency(typeof(IceboxAssets.UWP.FileHelper))]//该处要依赖注入的是本类
namespace IceboxAssets.UWP
{
    public class FileHelper : IceboxAssets.DependencyService.IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            return System.IO.Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }

      
    }
}
