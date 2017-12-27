using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IceboxAssets.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace IceboxAssets.ViewModel
{
    public class IceboxItemViewModel : ViewModelBase
    {
        private IceboxAssets.Model.IceboxItem _item;
        public IceboxItemViewModel(IceboxItem item)
        {
            this._item = item;
        }

        private bool visableTakeButton;
        public bool VisableTakeButton
        {
            get { return visableTakeButton; }
            set { SetProperty(ref visableTakeButton, value); }
        }

        #region iceboxItem

        public int Id
        {
            get { return _item.Id; }
            set
            {
                var _id = _item.Id;
                SetProperty(ref _id, value);
                _item.Id = _id;
            }
        }

        public string ItemName
        {
            get { return _item.ItemName; }
            set
            {
                var _itemname = _item.ItemName;
                SetProperty(ref _itemname, value);
            }
        }

        public string ItemRemark
        {
            get { return _item.ItemRemark; }
            set
            {
                var _itemremark = _item.ItemRemark;
                SetProperty(ref _itemremark, value);
            }
        }

        public DateTime PutInTime
        {
            get { return _item.PutInTime; }
            set
            {
                var _putintime = _item.PutInTime;
                SetProperty(ref _putintime, value);
            }
        }

        public DateTime FreshTime
        {
            get { return _item.FreshTime; }
            set
            {
                var _freshtime = _item.FreshTime;
                SetProperty(ref _freshtime, value);
            }
        }
        #endregion

    }
    public class IceboxItemsViewModel : ViewModelBase
    {
        //只有单个类的属性被修改的时候，才能用观察者模式的？
        ObservableCollection<IceboxItemViewModel> items;
        public IceboxItemsViewModel()
        {
            items = new ObservableCollection<IceboxItemViewModel>();
            Reflesh();
        }

        public ObservableCollection<IceboxItemViewModel> IceboxItems
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }

        private IceboxItemViewModel _selectedItem;
        /// <summary>
        /// 选择项
        /// </summary>
        public IceboxItemViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != null)
                {
                    _selectedItem.VisableTakeButton = false;
                }
                SetProperty(ref _selectedItem, value);
                if (_selectedItem != null)//选中后，显示按钮
                {
                    _selectedItem.VisableTakeButton = true;
                }
            }
        }
        /// <summary>
        /// 刷新
        /// </summary>
        public void Reflesh()
        {
            items.Clear();
            int skipCount = 0;
            int takeCount = 10;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                int skip = 0;
                IceboxAssets.DataAccess.IceboxItemDal dal = new DataAccess.IceboxItemDal();
                var tempList = dal.Table().OrderBy(p => p.FreshTime).ThenBy(p => p.PutInTime).Skip(skipCount).Take(takeCount).ToList();
                foreach (var item in tempList)
                {
                    items.Add(new IceboxItemViewModel(item));
                    skip++;
                }
                if (tempList.Count == 0)
                    return false;//返回假，中断timer
                skipCount += skip;
                return true;//返回真，则继续计时执行
            });
        }
        /// <summary>
        /// 移除
        /// </summary>
        public void Remove()
        {
            if (_selectedItem == null)
            {
                return;
            }

            this.IceboxItems.Remove(SelectedItem);
            SelectedItem = null;
            //更新到取出记录里面
        }

    }
}
