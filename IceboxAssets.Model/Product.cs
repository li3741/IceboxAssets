using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
//using SQLiteNetExtensions.Attributes;

namespace IceboxAssets.Model
{
    /***
     * 所有的东西都是产品
     * 所以应该有
     * 条码
     * 名称
     * 价格
     * */
     [Table("Products")]
    public class Product
    {
        [PrimaryKey]
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public double? Price { get; set; }
       
    }
}
