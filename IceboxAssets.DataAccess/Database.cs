using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
//using SQLiteNetExtensions;

namespace IceboxAssets.DataAccess
{
    /// <summary>
    /// 该类提供统一的静态的数据库实例
    /// </summary>
    public class Database
    {
        private static object locker;
        static Database()
        {
            locker = new object();
        }
        //该地方使用到的是单例模式
        private static SQLiteConnection sqliteDataBase;
        public static SQLiteConnection SqLiteDB
        {
            get
            {

                if (sqliteDataBase == null)
                {
                    lock (locker)
                    {
                        if (sqliteDataBase == null)
                        {
                            //通过接口，调用了平台特性的函数，对于的函数要实现在对应的平台代码里面
                            string localDbFilePath = Xamarin.Forms.DependencyService.Get<DependencyService.IFileHelper>().GetLocalFilePath("IceBoxAssetsSQLite.db3");
                            sqliteDataBase = new SQLite.SQLiteConnection(localDbFilePath);//这里真实的sqlite是需要提供路径的
                            InitDatabase();
                        }
                    }
                }
                return sqliteDataBase;
            }
        }

        public static void InitDatabase()
        {
            //第一次初始化整个数据库
            //Database.SqLiteDB//检查该数据是否存在表，如果不存在，则建立表
            if (CheckIsHasTables())
                return;
            CreateTables();
            InitData();
        }

        protected static bool CheckIsHasTables()
        {
            var tableInfo = Database.SqLiteDB.GetTableInfo("AppConfig");
            return tableInfo.Count > 0;
            var query = Database.SqLiteDB.Table<IceboxAssets.Model.MyColor>().Where(p => p.B > 3);
            List<Model.MyColor> colorList = query.ToList();
            int isdone = Database.SqLiteDB.Delete<Model.MyColor>(1);
            var color1 = Database.SqLiteDB.Find<Model.MyColor>(p => p.ID == 1);
            color1.B = 3;
            Database.SqLiteDB.Update(color1);
        }

        protected static void CreateTables()
        {
            //建立独立的无依赖的
            SqLiteDB.CreateTable<Model.AppConfig>();

            SqLiteDB.CreateTable<Model.Member>();
            SqLiteDB.CreateTable<Model.IceboxItem>();
            SqLiteDB.CreateTable<Model.Recipe>();

            SqLiteDB.CreateTable<Model.Product>();
            SqLiteDB.CreateTable<Model.ItemRecord>();
            SqLiteDB.CreateTable<Model.ItemRecordMemberMapping>();
            SqLiteDB.CreateTable<Model.ItemRecordProductMapping>();

            //建立对别的类有依赖的表
            SqLiteDB.CreateTable<Model.Cooking>();
            SqLiteDB.CreateTable<Model.CookingIceboxItemMapping>();
            SqLiteDB.CreateTable<Model.CookingRecipeMapping>();

            SqLiteDB.CreateTable<Model.MealItem>();
            SqLiteDB.CreateTable<Model.MealItemCookingMapping>();
            SqLiteDB.CreateTable<Model.MealItemMemberMapping>();




        }

        protected static void InitData()
        {
            //冰箱内的物品
            SqLiteDB.Insert(new Model.IceboxItem() { ItemName = "可乐", ItemRemark = "别喝我的", PutInTime = DateTime.Now, FreshTime = DateTime.Now.AddDays(30) });
            SqLiteDB.Insert(new Model.IceboxItem() { ItemName = "可乐1", ItemRemark = "别喝我的", PutInTime = DateTime.Now, FreshTime = DateTime.Now.AddDays(30) });
            SqLiteDB.Insert(new Model.IceboxItem() { ItemName = "可乐2", ItemRemark = "别喝我的", PutInTime = DateTime.Now, FreshTime = DateTime.Now.AddDays(30) });
            SqLiteDB.Insert(new Model.IceboxItem() { ItemName = "可乐3", ItemRemark = "别喝我的", PutInTime = DateTime.Now, FreshTime = DateTime.Now.AddDays(30) });
            SqLiteDB.Insert(new Model.IceboxItem() { ItemName = "可乐4", ItemRemark = "别喝我的", PutInTime = DateTime.Now, FreshTime = DateTime.Now.AddDays(30) });
            SqLiteDB.Insert(new Model.IceboxItem() { ItemName = "可乐5", ItemRemark = "别喝我的", PutInTime = DateTime.Now, FreshTime = DateTime.Now.AddDays(30) });
            SqLiteDB.Insert(new Model.IceboxItem() { ItemName = "可乐6", ItemRemark = "别喝我的", PutInTime = DateTime.Now, FreshTime = DateTime.Now.AddDays(30) });
            SqLiteDB.Insert(new Model.IceboxItem() { ItemName = "可乐7", ItemRemark = "别喝我的", PutInTime = DateTime.Now, FreshTime = DateTime.Now.AddDays(30) });
            SqLiteDB.Insert(new Model.IceboxItem() { ItemName = "可乐8", ItemRemark = "别喝我的", PutInTime = DateTime.Now, FreshTime = DateTime.Now.AddDays(30) });
            SqLiteDB.Insert(new Model.IceboxItem() { ItemName = "可乐9", ItemRemark = "别喝我的", PutInTime = DateTime.Now, FreshTime = DateTime.Now.AddDays(30) });
            SqLiteDB.Insert(new Model.IceboxItem() { ItemName = "可乐10", ItemRemark = "别喝我的", PutInTime = DateTime.Now, FreshTime = DateTime.Now.AddDays(30) });
            SqLiteDB.Insert(new Model.IceboxItem() { ItemName = "青瓜", ItemRemark = "敷脸的，别吃", PutInTime = DateTime.Now, FreshTime = DateTime.Now.AddDays(3) });
            SqLiteDB.Insert(new Model.IceboxItem() { ItemName = "雪糕", ItemRemark = "别吃我的", PutInTime = DateTime.Now, FreshTime = DateTime.Now.AddDays(90) });
            SqLiteDB.Insert(new Model.IceboxItem() { ItemName = "猪肉", ItemRemark = "记得过水炒", PutInTime = DateTime.Now, FreshTime = DateTime.Now.AddDays(1) });
            SqLiteDB.Insert(new Model.IceboxItem() { ItemName = "上海青", ItemRemark = "泡水", PutInTime = DateTime.Now, FreshTime = DateTime.Now.AddDays(1) });
            SqLiteDB.Insert(new Model.IceboxItem() { ItemName = "苹果", ItemRemark = "一人一个", PutInTime = DateTime.Now, FreshTime = DateTime.Now.AddDays(10) });
            SqLiteDB.Insert(new Model.IceboxItem() { ItemName = "可乐", ItemRemark = "别喝我的", PutInTime = DateTime.Now, FreshTime = DateTime.Now.AddDays(120) });
            SqLiteDB.Insert(new Model.IceboxItem() { ItemName = "可乐", ItemRemark = "别喝我的", PutInTime = DateTime.Now, FreshTime = DateTime.Now.AddDays(120) });
            //用户
            SqLiteDB.Insert(new Model.Member { MemberId = Guid.NewGuid(), MemberName = "老妈子" });
            SqLiteDB.Insert(new Model.Member { MemberId = Guid.NewGuid(), MemberName = "老爸" });
            SqLiteDB.Insert(new Model.Member { MemberId = Guid.NewGuid(), MemberName = "丈夫" });
            SqLiteDB.Insert(new Model.Member { MemberId = Guid.NewGuid(), MemberName = "妻子" });
            SqLiteDB.Insert(new Model.Member { MemberId = Guid.NewGuid(), MemberName = "长子" });

            SqLiteDB.Insert(new Model.Product { SKU = "8-717644-19055", ProductName = "多芬香皂5" });
            SqLiteDB.Insert(new Model.Product { SKU = "8-717644-19054", ProductName = "多芬香皂4" });
            SqLiteDB.Insert(new Model.Product { SKU = "8-717644-19053", ProductName = "多芬香皂3" });
            SqLiteDB.Insert(new Model.Product { SKU = "8-717644-19052", ProductName = "多芬香皂2" });
            SqLiteDB.Insert(new Model.Product { SKU = "8-717644-19051", ProductName = "多芬香皂1" });
            //购买记录
            var product = SqLiteDB.Table<Model.Product>().FirstOrDefault();
            SqLiteDB.Insert(new Model.ItemRecord { ProductItem = product, Owner = sqliteDataBase.Table<Model.Member>().FirstOrDefault(), ItemStatus = Model.ItemRecordStatus.InMyItem, WantTakeTime = DateTime.Now, CanSeeMembers = SqLiteDB.Table<Model.Member>().ToList() });
            SqLiteDB.Insert(new Model.ItemRecord { ProductItem = product, Owner = sqliteDataBase.Table<Model.Member>().FirstOrDefault(), ItemStatus = Model.ItemRecordStatus.InMyItem, WantTakeTime = DateTime.Now, CanSeeMembers = SqLiteDB.Table<Model.Member>().ToList() });
            SqLiteDB.Insert(new Model.ItemRecord { ProductItem = product, Owner = sqliteDataBase.Table<Model.Member>().FirstOrDefault(), ItemStatus = Model.ItemRecordStatus.InMyItem, WantTakeTime = DateTime.Now, CanSeeMembers = SqLiteDB.Table<Model.Member>().ToList() });
            SqLiteDB.Insert(new Model.ItemRecord { ProductItem = product, Owner = sqliteDataBase.Table<Model.Member>().FirstOrDefault(), ItemStatus = Model.ItemRecordStatus.InMyItem, WantTakeTime = DateTime.Now, CanSeeMembers = SqLiteDB.Table<Model.Member>().ToList() });
            SqLiteDB.Insert(new Model.ItemRecord { ProductItem = product, Owner = sqliteDataBase.Table<Model.Member>().FirstOrDefault(), ItemStatus = Model.ItemRecordStatus.InMyItem, WantTakeTime = DateTime.Now, CanSeeMembers = SqLiteDB.Table<Model.Member>().ToList() });
            SqLiteDB.Insert(new Model.ItemRecord { ProductItem = product, Owner = sqliteDataBase.Table<Model.Member>().FirstOrDefault(), ItemStatus = Model.ItemRecordStatus.InMyItem, WantTakeTime = DateTime.Now, CanSeeMembers = SqLiteDB.Table<Model.Member>().ToList() });
            product = SqLiteDB.Table<Model.Product>().Skip(1).Take(1).FirstOrDefault();
            SqLiteDB.Insert(new Model.ItemRecord { ProductItem = product, Owner = sqliteDataBase.Table<Model.Member>().FirstOrDefault(), ItemStatus = Model.ItemRecordStatus.InShopping, WantTakeTime = DateTime.Now, CanSeeMembers = SqLiteDB.Table<Model.Member>().ToList() });
            SqLiteDB.Insert(new Model.ItemRecord { ProductItem = product, Owner = sqliteDataBase.Table<Model.Member>().FirstOrDefault(), ItemStatus = Model.ItemRecordStatus.InShopping, WantTakeTime = DateTime.Now, CanSeeMembers = SqLiteDB.Table<Model.Member>().ToList(), Alias = "测试", RecordTime = DateTime.Now, Remark = "记得哇！！！！必须记得，不然打你哟" });

            SqLiteDB.Insert(new Model.Recipe { Sequeue = 1, Content = "准备好材料，姜切片，肉过水。", PayTime = new DateTime(60 * 1000) });
            SqLiteDB.Insert(new Model.Recipe { Sequeue = 2, Content = "大火下油，烧热后，别虾肉", PayTime = new DateTime(60 * 1000) });
            SqLiteDB.Insert(new Model.Recipe { Sequeue = 3, Content = "放盐", PayTime = new DateTime(60 * 1000) });
            SqLiteDB.Insert(new Model.Recipe { Sequeue = 4, Content = "放肉", PayTime = new DateTime(60 * 1000) });
            SqLiteDB.Insert(new Model.Recipe { Sequeue = 5, Content = "起锅", PayTime = new DateTime(60 * 1000) });
            var c_recipe = SqLiteDB.Table<Model.Recipe>().ToList();
            var i_items = SqLiteDB.Table<Model.IceboxItem>().ToList();
            SqLiteDB.Insert(new Model.Cooking { CoookRecipe = c_recipe, CookName = "炒肉", Items = i_items, Remark = "这个有点多肉", TotalCalorie = 2000 });
            SqLiteDB.Insert(new Model.Cooking { CoookRecipe = c_recipe, CookName = "炒肉2号", Items = i_items, Remark = "这个有点多肉", TotalCalorie = 2000 });
            SqLiteDB.Insert(new Model.Cooking { CoookRecipe = c_recipe, CookName = "炒肉3号", Items = i_items, Remark = "这个有点多肉", TotalCalorie = 2000 });
            var c_cooklist = SqLiteDB.Table<Model.Cooking>().ToList();
            var m_mem = SqLiteDB.Table<Model.Member>().ToList();
            SqLiteDB.Insert(new Model.MealItem { CookList = c_cooklist, Cooker = "老妈子", MealName = "中午饭", MealTime = DateTime.Now, PresentUsers = m_mem, TotalCalorie = c_cooklist.Sum(p => p.TotalCalorie) });
            var m_item = SqLiteDB.Table<Model.MealItem>().FirstOrDefault();
            m_item.PresentUsers = m_mem;
            m_item.CookList = c_cooklist;
            SqLiteDB.Insert(new Model.MealItemGroup(m_item));
        }
    }
}
