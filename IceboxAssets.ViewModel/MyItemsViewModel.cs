using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IceboxAssets.Model;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace IceboxAssets.ViewModel
{
    public class MyItemsViewModel : ViewModelBase
    {
        /***
         * MVVC的模式中，viewmodel是用来观察单个实体的话，则对该实体的每个对象进行监听，如果改变，则通知刷新，
         * 如果是对对象列表进行监听的话，则是监听列表的增加或者减少，发生改变，则通知刷新
         * 所以，在列表中，可以额外设置viewmodel自身的属性，
         * 例如：分组，选择项，等 
         * 上述概念  ✔吗？
         * */
        ObservableCollection<ItemRecord> items;
        public MyItemsViewModel()
        {
            items = new ObservableCollection<ItemRecord>();
            Reflesh();
        }
        public ObservableCollection<ItemRecord> My_Items
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
                var tempList = dal.Table().OrderBy(p => p.RecordTime).Skip(skipCount).Take(takeCount).ToList();
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
