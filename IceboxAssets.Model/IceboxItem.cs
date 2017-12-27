using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
//using SQLiteNetExtensions.Attributes;

namespace IceboxAssets.Model
{
    [Table("IceboxItems")]
    public class IceboxItem
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        /// <summary>
        /// 条目名称
        /// </summary>
        //[Indexed]
        [MaxLength(100)]
        public string ItemName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(500)]
        public string ItemRemark { get; set; }
        /// <summary>
        /// 放入日期
        /// </summary>
        public DateTime PutInTime { get; set; }
        /// <summary>
        /// 保鲜期
        /// </summary>
        public DateTime FreshTime { get; set; }

        //[ManyToMany(typeof(CookingIceboxItemMapping))]
        //public List<Cooking> CookingList { get; set; }
    }
}
