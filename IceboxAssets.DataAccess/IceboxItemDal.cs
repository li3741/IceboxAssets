using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceboxAssets.DataAccess
{
    public class IceboxItemDal : Repository<Model.IceboxItem>
    {
        public List<Model.IceboxItem> List()
        {
            var list = new List<Model.IceboxItem>();
            list.Add(new Model.IceboxItem { ItemName="物件1", FreshTime=DateTime.Now.AddYears(-1), Id=1, ItemRemark="备注", PutInTime=DateTime.Now });
            list.Add(new Model.IceboxItem { ItemName = "物件2", FreshTime = DateTime.Now, Id = 2, ItemRemark = "备注", PutInTime = DateTime.Now });
            list.Add(new Model.IceboxItem { ItemName = "物件3", FreshTime = DateTime.Now.AddDays(1), Id = 3, ItemRemark = "备注", PutInTime = DateTime.Now });
            list.Add(new Model.IceboxItem { ItemName = "物件4", FreshTime = DateTime.Now.AddDays(4), Id = 4, ItemRemark = "备注", PutInTime = DateTime.Now });
            list.Add(new Model.IceboxItem { ItemName = "物件5", FreshTime = DateTime.Now.AddDays(5), Id = 5, ItemRemark = "备注", PutInTime = DateTime.Now });
            list.Add(new Model.IceboxItem { ItemName = "物件6", FreshTime = DateTime.Now.AddDays(6), Id = 6, ItemRemark = "备注", PutInTime = DateTime.Now });
            list.Add(new Model.IceboxItem { ItemName = "物件7", FreshTime = DateTime.Now.AddDays(7), Id = 7, ItemRemark = "备注", PutInTime = DateTime.Now });
            return list;
        }
    }
}
