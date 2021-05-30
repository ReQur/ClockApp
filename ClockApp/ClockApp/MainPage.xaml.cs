using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
using Xamarin.Forms;
using System.Timers;

namespace ClockApp
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ViewModel();
        }

    }

    

    public class ViewModel : BindableObject
    {

        public ViewModel()
        {
            Numbers = new ObservableCollection<char>();

            CurrentTime = DateTime.Now;


            addHourCommand = new Command(() =>
            {
                CDModification += 1;
                CurrentTime = DateTime.Now;
            }, () => true);

            suptHourCommand = new Command(() =>
            {
                CDModification -= 1;
                CurrentTime = DateTime.Now;
            }, () => true);

            Uptimer Timer = new Uptimer(this);
        }

        private DateTime _currenttime;
        public DateTime CurrentTime
        {
            get => _currenttime;

            set
            {
                if (value == _currenttime) return;
                _currenttime = value;
                OnPropertyChanged(nameof(CurrentTime));
                DateTime modifTime = _currenttime.AddHours(CDModification);
                var DateString = modifTime.ToString("HH:mm:ss").ToCharArray();
                for (var i = 0; i < DateString.Length; i++)
                {
                    if (Numbers.Count > i)
                    {
                        if (Numbers[i] != DateString[i])
                        {
                            Numbers[i] = DateString[i];
                        }
                    }
                    else
                    {
                        Numbers.Add(DateString[i]);
                    }
                }
            }
        }


        private int _cdmodification;

        public int CDModification
        {
            get => _cdmodification;

            set
            {
                if (_cdmodification == value) return;
                _cdmodification = value;
                OnPropertyChanged(nameof(CDModification));
            }
        }

        //public double FrameWidth
        //{
        //    get => _pagewidth * 0.8 / 8;
        //}
        //WidthRequest="{Binding Source={RelativeSource AncestorType={x:Type ClockApp:ViewModel}}, Path=FrameWidth}"
        //HeightRequest="{Binding Source={RelativeSource AncestorType={x:Type ClockApp:ViewModel}}, Path=FrameHeight}"
        //public double FrameHeight
        //{
        //    get => _pagewidth * 0.8 / 8 * 16 / 9;

        //}

        //public double MainFrameWidth
        //{
        //    get => _pagewidth * 0.8 + 7;

        //}

        //public double MainFrameHeight
        //{
        //    get => _pagewidth * 0.8 / 8 * 16 / 9;

        //}

        //private double _pagewidth;
        //public double PageWidth
        //{
        //    get => _pagewidth;


        //    set
        //    {
        //        if (_pagewidth == value) return;
        //        _pagewidth = value;
        //        OnPropertyChanged(nameof(PageWidth));
        //        OnPropertyChanged(nameof(FrameWidth));
        //        OnPropertyChanged(nameof(FrameHeight));
        //    }
        //}
        public double PageWidth { get; set; }


        public ObservableCollection<char> Numbers { get; }


        public ICommand
            addHourCommand
        {
            get; 
        }

        public ICommand
            suptHourCommand
        {
            get;
        }
        public class Uptimer
        {
            public Uptimer(ViewModel bindingModel)
            {
                Timer timer = new Timer(1000);
                timer.Elapsed += async (sender, e) =>
                {
                    bindingModel.CurrentTime = DateTime.Now;
                };
                timer.Start();
            }
        }

    }
}
