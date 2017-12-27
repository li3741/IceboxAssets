using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IceboxAssets.Model;

namespace IceboxAssets.DataAccess
{
    public class MealItemDal : Repository<MealItem>
    {
        public List<Model.MealItemGroup> List()
        {
            var list = new List<Model.MealItemGroup>();
            var cookList1 = new List<Cooking>();
            cookList1.Add(new Cooking { Id = 1, CookName = "白粥", TotalCalorie = 10 });
            cookList1.Add(new Cooking { Id = 2, CookName = "咸菜", TotalCalorie = 12 });
            cookList1.Add(new Cooking { Id = 3, CookName = "包子", TotalCalorie = 13,Remark="有很多肉的,大家少吃点,留点给我!" });
            list.Add(new MealItemGroup(new MealItem
            {
                Id = 1,
                MealName = "早餐",
                MealTime = DateTime.Now,
                TotalCalorie = cookList1.Sum(p => p.TotalCalorie),
                //CookList = cookList1,
                //PresentUsers = new List<Member>(),
            }));

            var cookList2 = new List<Cooking>();
            cookList2.Add(new Cooking { Id = 1, CookName = "宫保鸡丁", TotalCalorie = 100 });
            cookList2.Add(new Cooking { Id = 2, CookName = "清蒸花胶", TotalCalorie = 120 });
            cookList2.Add(new Cooking { Id = 3, CookName = "白切鹅", TotalCalorie = 130 });
            list.Add(new MealItemGroup(new MealItem
            {
                Id = 1,
                MealName = "中餐",
                MealTime = DateTime.Now,
                TotalCalorie = cookList2.Sum(p => p.TotalCalorie),
                //CookList = cookList2,
                //PresentUsers = new List<Member>(),
            }));
            var cookList3 = new List<Cooking>();
            cookList3.Add(new Cooking { Id = 1, CookName = "宫保鸡丁", TotalCalorie = 100 });
            cookList3.Add(new Cooking { Id = 2, CookName = "清蒸花胶", TotalCalorie = 120 });
            cookList3.Add(new Cooking { Id = 3, CookName = "白切鹅", TotalCalorie = 130 });
            list.Add(new MealItemGroup(new MealItem
            {
                Id = 1,
                MealName = "晚餐",
                MealTime = DateTime.Now,
                TotalCalorie = cookList2.Sum(p => p.TotalCalorie),
                //CookList = cookList3,
                //PresentUsers = new List<Member>(),
            }));
            var cookList4 = new List<Cooking>();
            cookList4.Add(new Cooking { Id = 1, CookName = "宫保鸡丁", TotalCalorie = 100 });
            cookList4.Add(new Cooking { Id = 2, CookName = "清蒸花胶", TotalCalorie = 120 });
            cookList4.Add(new Cooking { Id = 3, CookName = "白切鹅", TotalCalorie = 130 });
            list.Add(new MealItemGroup(new MealItem
            {
                Id = 1,
                MealName = "宵夜",
                MealTime = DateTime.Now,
                TotalCalorie = cookList2.Sum(p => p.TotalCalorie),
                //CookList = cookList4,
                //PresentUsers = new List<Member>(),
            }));
            return list;
        }
    }
}
