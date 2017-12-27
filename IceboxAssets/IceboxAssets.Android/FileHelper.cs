using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(IceboxAssets.Droid.FileHelper))]//必须有这个全局特性标识,否则,无法做注入?
namespace IceboxAssets.Droid
{
    public class FileHelper : IceboxAssets.DependencyService.IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            //使用安卓平台特性实现该功能
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}