using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
[assembly:Dependency(typeof(IceboxAssets.iOS.FileHelper))]
namespace IceboxAssets.iOS
{
    public class FileHelper : IceboxAssets.DependencyService.IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = System.IO.Path.Combine(docFolder, "..", "Library","Databases");
            if(!System.IO.Directory.Exists(libFolder))
            {
                System.IO.Directory.CreateDirectory(libFolder);
            }
            return System.IO.Path.Combine(libFolder, filename);
        }
    }
}