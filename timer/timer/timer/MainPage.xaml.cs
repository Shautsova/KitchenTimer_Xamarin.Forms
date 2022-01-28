using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;

namespace timer
{
    public partial class MainPage : ContentPage
    {
        private int count;
        private double _ProgressValue;
        public double ProgressValue
        {
            get { return _ProgressValue; }
            set
            {
                _ProgressValue = value;
                OnPropertyChanged();
            }
        }

        private double _Minimum;
        public double Minimun
        {
            get { return _Minimum; }
            set
            {
                _Minimum = value;
                OnPropertyChanged();
            }
        }

        private double _Maximum;
        public double Maximum
        {
            get { return _ProgressValue; }
            set
            {
                _ProgressValue = value;
                OnPropertyChanged();
            }
        }

        private Timer time = new Timer();
        private bool timerRunning;
        public MainPage()
        {
            InitializeComponent();
           
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            BindingContext = this;
            Minimun = 0;
            Maximum = 900;
            ProgressValue = 900;
            count = 900;
            timerRunning = true;
            time.Start();
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                
                if (ProgressValue > Minimun )
                {
                    count--;
                    if(count==720)
                    {
                        Infor.Text = "Jajko już jest ugotowane na MIĘKO!";
                    }
                    else if(count == 600)
                    {
                        Infor.Text = "Jajko już jest ugotowane na PÓŁTWARDO!";
                    }
                    else if (count == 420)
                    {
                        Infor.Text = "Jajko już jest ugotowane na TWARDO!";
                    }
                    ProgressValue--;
                    return true;
                }
                else if (ProgressValue == Minimun)
                {
                    time.Stop();
                    timerRunning = false;
                    return false;
                }
                else
                {
                    return true;
                }
            });
        }
    }
}
