using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceboxAssets.Model
{
    /// <summary>
    /// 作为一个model类，
    /// 有贫血模型类，只有属性，没有函数，只是用来传递数据用
    /// 有富类，有属性和对于的操作，但是应该尽量避免引用该命名空间之外的函数，除非引用工具类
    /// </summary>
    public class MyColor
    {
        [PrimaryKey,AutoIncrement]//主键，自增加
        public int ID { get; set; }
        [Indexed]//索引
        public int R { get; set; }
        public int B { get; set; }
        public int G { get; set; }
    }
}
