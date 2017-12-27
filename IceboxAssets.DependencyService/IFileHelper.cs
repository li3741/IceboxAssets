using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceboxAssets.DependencyService
{
    /*
     * 因为平台的不同的存储文件方式，
     * 所以，在存储文件的时候，需要各自平台特性实现
     * 把这类接口放在一个类库里面，可以统一实现
     **/
   public interface IFileHelper
    {
        /// <summary>
        /// 获取本地文件路径
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns></returns>
        string GetLocalFilePath(string filename);

       
    }
}
