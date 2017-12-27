using IceboxAssets.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IceboxAssets.ViewModel
{
    public class ShoppingItemViewModel : ViewModelBase
    {
        ObservableCollection<ItemRecord> items;
        public ShoppingItemViewModel()
        {
            items = new ObservableCollection<ItemRecord>();
            Reflesh();
        }
        public ObservableCollection<ItemRecord> Shopping_Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }

        public void Reflesh()
        {
            items.Clear();
            int skipCount = 0;
            int takeCount = 10;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                int skip = 0;
                IceboxAssets.DataAccess.ItemRecordDal dal = new DataAccess.ItemRecordDal();
                var tempList = dal.Table().Where(p=>p.ItemStatus!= ItemRecordStatus.InBox&&p.ItemStatus!= ItemRecordStatus.InMyItem).OrderBy(p => p.RecordTime).Skip(skipCount).Take(takeCount).ToList();
                foreach (var item in tempList)
                {
                    items.Add(item);
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
