using IceboxAssets.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceboxAssets.DataAccess
{
    public class ItemRecordDal : Repository<Model.ItemRecord>
    {
        public List<ItemRecord> List()
        {
            var list = new List<ItemRecord>();
            list.Add(new ItemRecord()
            {
                //ProductItem = new Product()
                //{
                //    Price = 200,
                //    ProductName = "可乐",
                //    SKU = "9-88-677777"
                //},
                ItemStatus = ItemRecordStatus.InMyItem,
                RecordTime = DateTime.Now,
                WantTakeTime = DateTime.Now.AddDays(1),
                Remark = "要可口可乐",

            });
            list.Add(new ItemRecord()
            {
                //ProductItem = new Product()
                //{
                //    Price = 200,
                //    ProductName = "可乐",
                //    SKU = "9-88-677577"
                //},
                ItemStatus = ItemRecordStatus.InMyItem,
                RecordTime = DateTime.Now,
                WantTakeTime = DateTime.Now.AddDays(1),
                Remark = "要可口可乐",
            });
            list.Add(new ItemRecord()
            {
                //ProductItem = new Product()
                //{
                //    Price = 200,
                //    ProductName = "可乐",
                //    SKU = "9-88-677777"
                //},
                ItemStatus = ItemRecordStatus.InMyItem,
                RecordTime = DateTime.Now,
                WantTakeTime = DateTime.Now.AddDays(1),
                Remark = "要可口可乐",

            });
            list.Add(new ItemRecord()
            {
                //ProductItem = new Product()
                //{
                //    Price = 200,
                //    ProductName = "可乐",
                //    SKU = "9-88-677777"
                //},
                ItemStatus = ItemRecordStatus.InMyItem,
                RecordTime = DateTime.Now,
                WantTakeTime = DateTime.Now.AddDays(1),
                Remark = "要可口可乐",

            });
            list.Add(new ItemRecord()
            {
                //ProductItem = new Product()
                //{
                //    Price = 200,
                //    ProductName = "可乐",
                //    SKU = "9-88-677777"
                //},
                ItemStatus = ItemRecordStatus.InMyItem,
                RecordTime = DateTime.Now,
                WantTakeTime = DateTime.Now.AddDays(1),
                Remark = "要可口可乐",

            });
            list.Add(new ItemRecord()
            {
                //ProductItem = new Product()
                //{
                //    Price = 200,
                //    ProductName = "可乐",
                //    SKU = "9-88-677777"
                //},
                ItemStatus = ItemRecordStatus.InMyItem,
                RecordTime = DateTime.Now,
                WantTakeTime = DateTime.Now.AddDays(1),
                Remark = "要可口可乐",

            });
            list.Add(new ItemRecord()
            {
                //ProductItem = new Product()
                //{
                //    Price = 200,
                //    ProductName = "可乐",
                //    SKU = "9-88-677777"
                //},
                ItemStatus = ItemRecordStatus.InMyItem,
                RecordTime = DateTime.Now,
                WantTakeTime = DateTime.Now.AddDays(1),
                Remark = "要可口可乐",

            });
            list.Add(new ItemRecord()
            {
                //ProductItem = new Product()
                //{
                //    Price = 200,
                //    ProductName = "可乐",
                //    SKU = "9-88-677777"
                //},
                ItemStatus = ItemRecordStatus.InMyItem,
                RecordTime = DateTime.Now,
                WantTakeTime = DateTime.Now.AddDays(1),
                Remark = "要可口可乐",

            });

            list.Add(new ItemRecord()
            {
                //ProductItem = new Product()
                //{
                //    Price = 200,
                //    ProductName = "可乐",
                //    SKU = "9-88-677777"
                //},
                ItemStatus = ItemRecordStatus.InMyItem,
                RecordTime = DateTime.Now,
                WantTakeTime = DateTime.Now.AddDays(1),
                Remark = "要可口可乐",

            });
            list.Add(new ItemRecord()
            {
                //ProductItem = new Product()
                //{
                //    Price = 200,
                //    ProductName = "可乐",
                //    SKU = "9-88-677577"
                //},
                ItemStatus = ItemRecordStatus.InMyItem,
                RecordTime = DateTime.Now,
                WantTakeTime = DateTime.Now.AddDays(1),
                Remark = "要可口可乐",
            });
            list.Add(new ItemRecord()
            {
                //ProductItem = new Product()
                //{
                //    Price = 200,
                //    ProductName = "可乐",
                //    SKU = "9-88-677777"
                //},
                ItemStatus = ItemRecordStatus.InMyItem,
                RecordTime = DateTime.Now,
                WantTakeTime = DateTime.Now.AddDays(1),
                Remark = "要可口可乐",

            });
            list.Add(new ItemRecord()
            {
                //ProductItem = new Product()
                //{
                //    Price = 200,
                //    ProductName = "可乐",
                //    SKU = "9-88-677777"
                //},
                ItemStatus = ItemRecordStatus.InMyItem,
                RecordTime = DateTime.Now,
                WantTakeTime = DateTime.Now.AddDays(1),
                Remark = "要可口可乐",

            });
            list.Add(new ItemRecord()
            {
                //ProductItem = new Product()
                //{
                //    Price = 200,
                //    ProductName = "可乐",
                //    SKU = "9-88-677777"
                //},
                ItemStatus = ItemRecordStatus.InMyItem,
                RecordTime = DateTime.Now,
                WantTakeTime = DateTime.Now.AddDays(1),
                Remark = "要可口可乐",

            });
            list.Add(new ItemRecord()
            {
                //ProductItem = new Product()
                //{
                //    Price = 200,
                //    ProductName = "可乐",
                //    SKU = "9-88-677777"
                //},
                ItemStatus = ItemRecordStatus.InShopping,
                RecordTime = DateTime.Now,
                WantTakeTime = DateTime.Now.AddDays(1),
                Remark = "要可口可乐",

            });
            list.Add(new ItemRecord()
            {
                //ProductItem = new Product()
                //{
                //    Price = 200,
                //    ProductName = "可乐",
                //    SKU = "9-88-677777"
                //},
                ItemStatus = ItemRecordStatus.InShopping,
                RecordTime = DateTime.Now,
                WantTakeTime = DateTime.Now.AddDays(1),
                Remark = "要可口可乐",

            });
            list.Add(new ItemRecord()
            {
                //ProductItem = new Product()
                //{
                //    Price = 200,
                //    ProductName = "可乐",
                //    SKU = "9-88-677777"
                //},
                ItemStatus = ItemRecordStatus.InShopping,
                RecordTime = DateTime.Now,
                WantTakeTime = DateTime.Now.AddDays(1),
                Remark = "要可口可乐",

            });
            return list;
        }
    }
}
