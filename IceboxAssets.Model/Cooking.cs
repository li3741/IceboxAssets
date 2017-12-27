using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace IceboxAssets.Model
{
    [Table("Cookings")]
    /// <summary>
    /// 菜 品
    /// </summary>
    public class Cooking
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        /// <summary>
        /// 菜品名称（宫保鸡丁）
        /// </summary>
        public string CookName { get; set; }
        /// <summary>
        /// 菜品的总卡路里
        /// </summary>
        public int TotalCalorie { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 菜品含有的物品
        /// </summary>
        [ManyToMany(typeof(CookingIceboxItemMapping))]
        public List<IceboxItem> Items { get; set; }
        /// <summary>
        /// 烹饪步骤
        /// </summary>
        [ManyToMany(typeof(CookingRecipeMapping))]
        public List<Recipe> CoookRecipe { get; set; }
    }

    public class CookingIceboxItemMapping
    {
        [ForeignKey(typeof(Cooking))]
        public int CookingId { get; set; }
        [ForeignKey(typeof(IceboxItem))]
        public int IceboxItemId { get; set; }
    }

    public class CookingRecipeMapping
    {
        [ForeignKey(typeof(Cooking))]
        public int CookingId { get; set; }
        [ForeignKey(typeof(Recipe))]
        public int RecipeId { get; set; }
    }
}
