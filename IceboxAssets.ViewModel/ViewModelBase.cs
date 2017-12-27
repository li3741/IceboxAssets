using System;
using System.Collections.Generic;
using System.ComponentModel;//该命名空间主要提供观察者模式接口
using System.Linq;
using System.Runtime.CompilerServices;//该命名空间提供自动提取属性名
using System.Text;
using System.Threading.Tasks;

namespace IceboxAssets.ViewModel
{
    /// <summary>
    /// ViewModel,看不到view（user interface）层,本身使用大量的观察者模式，主要操作引用的model层，
    /// 通过回调使用view层，但是无论如何也不能直接使用view层的函数或者属性
    /// 该类定义了基本的用法，可以简化观察者模式的实现，当然，抄袭别人的
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected bool SetProperty<T>(ref T storage/*旧有的存储属性值*/,T value/*新的对象属性值*/,[CallerMemberName]string propertyName=null)
        {
            if(Object.Equals(storage,value))
            {
                return false;//如果两者一样，则不需更新
            }
            storage = value;//否则直接赋值
            OnPropertyChanged(propertyName);//通知观察者改变
            return true;//回传成功
        }
        protected void OnPropertyChanged([CallerMemberName]string propertyName=null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler!=null)//当有观察者注册，则进行通知
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
