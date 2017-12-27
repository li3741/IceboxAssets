using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceboxAssets.ViewModel
{
    //该类会把color看成是model层的一个类，而
    public class ColorViewModel : ViewModelBase
    {
        IceboxAssets.Model.MyColor myColor;
        public ColorViewModel(int r, int g, int b)
        {
            myColor = new Model.MyColor() { R = r, G = g, B = b };
        }
        public int R
        {
            get { return myColor.R; }
            set
            {
                int _R = myColor.R;
                SetProperty(ref _R, value);
            }
        }
        public int G
        {
            get { return myColor.G; }
            set
            {
                int _G = myColor.G;
                SetProperty(ref _G, value);
            }
        }
        public int B
        {
            get { return myColor.B; }
            set
            {
                int _B = myColor.B;
                SetProperty(ref _B, value);
            }
        }

        public IceboxAssets.Model.MyColor MyColor
        {
            get { return myColor; }
            set
            {
                IceboxAssets.Model.MyColor oldColor = myColor;
                SetProperty(ref oldColor, value);
                //当然，还可以做点别的操作
            }
        }
    }

}
