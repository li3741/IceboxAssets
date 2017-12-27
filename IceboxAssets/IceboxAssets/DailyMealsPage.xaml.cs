using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IceboxAssets
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DailyMealsPage : ContentPage
    {
        public DailyMealsPage()
        {
            InitializeComponent();
            InitInsertDays(DateTime.Now);
        }
        /// <summary>
        /// 当前显示的月份
        /// </summary>
        protected DateTime CurDisplayDate;
        /// <summary>
        /// 选中的按钮
        /// </summary>
        protected Button selectedButton;
        protected void InitInsertDays(DateTime today, DateTime? selected = null)
        {
            CurDisplayDate = today;
            stack_Calendar.Children.Clear();
            StackLayout lyweeks = new StackLayout();
            lyweeks.Orientation = StackOrientation.Horizontal;
            lyweeks.HorizontalOptions = new LayoutOptions(LayoutAlignment.Center, false);
            Button btn1 = new Button();
            btn1.Text = "一"; btn1.WidthRequest = 40; btn1.HeightRequest = 40;
            Button btn2 = new Button();
            btn2.Text = "二"; btn2.WidthRequest = 40; btn2.HeightRequest = 40;
            Button btn3 = new Button();
            btn3.Text = "三"; btn3.WidthRequest = 40; btn3.HeightRequest = 40;
            Button btn4 = new Button();
            btn4.Text = "四"; btn4.WidthRequest = 40; btn4.HeightRequest = 40;
            Button btn5 = new Button();
            btn5.Text = "五"; btn5.WidthRequest = 40; btn5.HeightRequest = 40;
            Button btn6 = new Button();
            btn6.Text = "六"; btn6.WidthRequest = 40; btn6.HeightRequest = 40;
            Button btn7 = new Button();
            btn7.Text = "日"; btn7.WidthRequest = 40; btn7.HeightRequest = 40;
            lyweeks.Children.Add(btn1);
            lyweeks.Children.Add(btn2);
            lyweeks.Children.Add(btn3);
            lyweeks.Children.Add(btn4);
            lyweeks.Children.Add(btn5);
            lyweeks.Children.Add(btn6);
            lyweeks.Children.Add(btn7);
            stack_Calendar.Children.Add(lyweeks);

            //int totalCount = 42;//6*7就是6行7列的总数
            lblMonth.Text = today.ToString("yyyy-MM");//今天的年月
            var preMonth = today.AddMonths(-1);//上一个月的年月
            var nextMonth = today.AddMonths(1);//下一个月的年月
            btnPreMonth.Text = preMonth.ToString("yy-MM");
            btnNextMonth.Text = nextMonth.ToString("yy-MM");
            //把日历需要的日期放入表格中
            int dayOfWeek = Convert.ToInt32(today.DayOfWeek);//今日是一周中的哪一天
            dayOfWeek = dayOfWeek == 0 ? 7 : dayOfWeek;//因为上面的枚举里面星期日是0！
            DateTime firstDayInMonth = new DateTime(today.Year, today.Month, 1);//本月的第一天的日期
            int firstDayOfWeek = Convert.ToInt32(firstDayInMonth.DayOfWeek);//第一日是一周中的哪一天
            firstDayOfWeek = firstDayOfWeek == 0 ? 7 : firstDayOfWeek;
            int totalDays = DateTime.DaysInMonth(today.Year, today.Month);//本月有的总天数
            int totalPreDays = DateTime.DaysInMonth(preMonth.Year, preMonth.Month);//上一个月的总天数
            int startDays = firstDayOfWeek - 1;//日历开始的第一天
            int todayNum = today.Day;//今天几号
            if (today.ToString("yyyy-MM-dd") != DateTime.Now.ToString("yyyy-MM-dd"))
            {
                todayNum = 0;
            }
            int dayToDisplay = 1;//本月开始的显示
            int lastToDisplay = 1;//下个月开始显示的日期
            for (int r = 1; r < 7; r++)
            {
                StackLayout layout = new StackLayout();
                layout.Orientation = StackOrientation.Horizontal;
                layout.HorizontalOptions = new LayoutOptions(LayoutAlignment.Center, false);
                for (int col = 0; col < 7; col++)
                {
                    Button btnDay = new Button();
                    btnDay.HeightRequest = 40;
                    btnDay.WidthRequest = 40;
                    btnDay.BackgroundColor = Color.Blue;
                    btnDay.Clicked += BtnDay_Clicked;
                    layout.Children.Add(btnDay);

                    if (startDays > 0)
                    {
                        btnDay.Text = (totalPreDays - startDays).ToString();
                        btnDay.BackgroundColor = Color.WhiteSmoke;
                        btnDay.AutomationId = new DateTime(preMonth.Year, preMonth.Month, (totalPreDays - startDays)).ToString("yyyy-MM-dd");
                        startDays--;
                    }
                    else
                    {
                        if (totalDays > 0)
                        {
                            btnDay.Text = dayToDisplay.ToString();
                            if (dayToDisplay == todayNum)
                            {
                                btnDay.BackgroundColor = Color.LightPink;
                            }
                            else
                            {
                                btnDay.BackgroundColor = Color.LightBlue;
                            }
                            if (selected.HasValue && selected.Value.Day == dayToDisplay)
                            {
                                btnDay.BackgroundColor = Color.LightGreen;
                                selectedButton = btnDay;
                                LoadDayMenu(selected.HasValue ? selected.Value : today);
                            }
                            btnDay.AutomationId = new DateTime(today.Year, today.Month, dayToDisplay).ToString("yyyy-MM-dd");
                            totalDays--;
                            dayToDisplay++;

                        }
                        else
                        {
                            btnDay.Text = lastToDisplay.ToString();
                            btnDay.BackgroundColor = Color.WhiteSmoke;
                            btnDay.AutomationId = new DateTime(nextMonth.Year, nextMonth.Month, lastToDisplay).ToString("yyyy-MM-dd");
                            lastToDisplay++;
                        }
                    }
                }
                stack_Calendar.Children.Add(layout);
            }
            //  LoadDayMenu(selected.HasValue ? selected.Value : today);
        }

        private void BtnDay_Clicked(object sender, EventArgs e)
        {
            Button btnSender = sender as Button;
            DateTime otherTime;
            DateTime.TryParse(btnSender.AutomationId, out otherTime);//点击的日期
            if (!btnSender.AutomationId.StartsWith(CurDisplayDate.ToString("yyyy-MM")))
            {
                InitInsertDays(otherTime, otherTime);//如果按下的不是当前月份的日期，则重新加载日历
            }
            else
            {//如果是本月的日期，则变化颜色
                btnSender.BackgroundColor = Color.LightGreen;
                if (selectedButton != null)
                {
                    bool isToday = false;
                    DateTime selectedTime2;
                    if (DateTime.TryParse(selectedButton.AutomationId, out selectedTime2))
                    {
                        isToday = (selectedTime2.Year == DateTime.Today.Year && selectedTime2.Month == DateTime.Today.Month && selectedTime2.Day == DateTime.Today.Day);
                    }
                    selectedButton.BackgroundColor = isToday ? Color.LightPink : Color.LightBlue;
                }

                selectedButton = btnSender;
                LoadDayMenu(otherTime);
            }
        }

        private void btnPreMonth_Clicked(object sender, EventArgs e)
        {
            InitInsertDays(CurDisplayDate.AddMonths(-1));
        }

        private void btnNextMonth_Clicked(object sender, EventArgs e)
        {
            InitInsertDays(CurDisplayDate.AddMonths(1));
        }


        private void LoadDayMenu(DateTime selectedDay)
        {
            list_meal.Reflesh();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            int id = 0;//煮餐的id
            Navigation.PushAsync(new CookingPage(id));
        }
    }
}