using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace IceboxAssets.Model
{
    [Table("Recipes")]
    /// <summary>
    /// 烹饪方法
    /// </summary>
   public class Recipe
    {
        [PrimaryKey, AutoIncrement]
        public int RecipeID { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int Sequeue { get; set; }
        /// <summary>
        /// 本次的内容，看看是否能把图片和文字混合在一起呈现
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 耗时约
        /// </summary>
        public DateTime PayTime { get; set; }
    }
}
