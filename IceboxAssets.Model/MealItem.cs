using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace IceboxAssets.Model
{
    [Table("MealItems")]
    /// <summary>
    /// 餐  
    /// </summary>
    public class MealItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        /// <summary>
        /// 餐名称，早餐，中餐，晚餐
        /// </summary>
        public string MealName { get; set; }
        /// <summary>
        /// 预计开始用餐时间
        /// </summary>
        public DateTime MealTime { get; set; }
        /// <summary>
        /// 本餐总卡路里
        /// </summary>
        public int TotalCalorie { get; set; }

        //本餐含有的菜列表
        [ManyToMany(typeof(MealItemCookingMapping), CascadeOperations = CascadeOperation.All)]
        public List<Cooking> CookList { get; set; }
        //本餐吃饭的人员列表,先用字符串,列表
        [ManyToMany(typeof(MealItemMemberMapping), CascadeOperations = CascadeOperation.All)]
        public List<Member> PresentUsers { get; set; }
        /// <summary>
        /// 煮饭作者
        /// </summary>
        public string Cooker { get; set; }

    }

    public class MealItemCookingMapping
    {
        [ForeignKey(typeof(MealItem))]
        public int MealItemId { get; set; }
        [ForeignKey(typeof(Cooking))]
        public int CookingId { get; set; }
    }

    public class MealItemMemberMapping
    {
        [ForeignKey(typeof(MealItem))]
        public int MealItemId { get; set; }
        [ForeignKey(typeof(Member))]
        public Guid MemberId { get; set; }
    }

    public class MealItemGroup : List<Cooking>
    {
        public MealItemGroup(MealItem item)
        {
            this.Id = item.Id;
            this.GroupName = string.Concat(item.MealName, ">", item.MealTime.ToString("HH:mm"), ">", (item.PresentUsers == null ? 1 : item.PresentUsers.Count));
            this.ShortName = item.MealName.Substring(0, 1);
            this.MealTime = item.MealTime;
            this.TotalCalorie = item.TotalCalorie;
            if (item.CookList != null)
                this.AddRange(item.CookList);
        }
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string GroupName { get; set; }
        public DateTime MealTime { get; set; }
        public int TotalCalorie { get; set; }

    }
}
