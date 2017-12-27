using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IceboxAssets.Model;
using System.Collections.ObjectModel;

namespace IceboxAssets.ViewModel
{
    public class MealItemsViewModel : ViewModelBase
    {
        ObservableCollection<MealItemGroup> items;
        public MealItemsViewModel()
        {
            items = new ObservableCollection<MealItemGroup>();
            Reflesh();
        }

        public ObservableCollection<MealItemGroup> MealItems
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }

        public void Reflesh()
        {
            items.Clear();
            int skipCount = 0;
            int takeCount = 10;
            Xamarin.Forms.Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                int skip = 0;
                IceboxAssets.DataAccess.MealItemDal dal = new DataAccess.MealItemDal();
                var tempList = dal.Table().OrderBy(p => p.MealTime).Skip(skipCount).Take(takeCount).ToList();
                foreach (var item in tempList)
                {
                    items.Add(new MealItemGroup(item));
                    skip++;
                }
                if (tempList.Count == 0)
                    return false;//返回假，中断timer
                skipCount += skip;
                return true;//返回真，则继续计时执行
            });
        }
    }
}
