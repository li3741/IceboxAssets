using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace IceboxAssets.Model
{
    [Table("ItemRecords")]
    /// <summary>
    /// 物品记录
    /// 产品
    /// 状态(个人物品中，购物车中)
    /// </summary>
    public class ItemRecord
    {
        [PrimaryKey, AutoIncrement]
        public int ItemRecordId { get; set; }
        /// <summary>
        /// 产品物件
        /// </summary>
        [ManyToMany(typeof(ItemRecordProductMapping))]
        public Product ProductItem { get; set; }
        /// <summary>
        /// 别称，家里的人的叫法
        /// </summary>
        public string Alias
        {
            get
            {
                if (string.IsNullOrEmpty(str_alias) && ProductItem != null)
                    return ProductItem.ProductName;
                else
                    return str_alias;
            }

            set { str_alias = value; }
        }
        private string str_alias;
        public string Remark { get; set; }
        public ItemRecordStatus ItemStatus { get; set; }
        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime RecordTime { get; set; }
        /// <summary>
        /// 想购入时间
        /// </summary>
        public DateTime WantTakeTime { get; set; }
        /// <summary>
        /// 能看见的人
        /// </summary>
        [ManyToMany(typeof(ItemRecordMemberMapping))]
        public List<Member> CanSeeMembers { get; set; }
        ///// <summary>
        ///// 拥有者
        ///// </summary>
        [OneToOne]
        [ForeignKey(typeof(Member))]
        public Member Owner { get; set; }
    }

    public class ItemRecordProductMapping
    {
        [ForeignKey(typeof(ItemRecord))]
        public int ItemRecordId { get; set; }
        [ForeignKey(typeof(Product))]
        public string ProductId { get; set; }
    }

    public class ItemRecordMemberMapping
    {
        [ForeignKey(typeof(ItemRecord))]
        public int ItemRecordId { get; set; }

        [ForeignKey(typeof(Member))]
        public Guid MemberId { get; set; }

    }

    public enum ItemRecordStatus
    {
        /// <summary>
        /// 个人物品清单中
        /// </summary>
        InMyItem = 0,
        /// <summary>
        /// 待购买列表中
        /// </summary>
        InShopping = 1,
        /// <summary>
        /// 已经放入购物车了
        /// </summary>
        Shopped = 2,
        /// <summary>
        /// 已经购入
        /// </summary>
        Paied = 3,
        /// <summary>
        /// 在冰箱里面
        /// </summary>
        InBox = 4,

    }
}
