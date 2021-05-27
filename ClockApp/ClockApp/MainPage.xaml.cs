using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

    static class Uptimer
    {
        static Uptimer()
        {
            Timer timer = new Timer(1000);
            timer.Elapsed += async (sender, e) => await HandleTimer();
            timer.Start();
        }

        private static Task HandleTimer()
        {
            Console.WriteLine("\nHandler not implemented...");
            throw new NotImplementedException();

        }
    }

    public class ViewModel : BindableObject
    {

        public ViewModel()
        {
            Numbers = new ObservableCollection<char>();

            CurrentTime = DateTime.Now;


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
                var DateString = _currenttime.ToString("HH:mm:ss").ToCharArray();
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

        public double FrameWidth
        {
            get => _pagewidth * 0.8 / 8;

        }

        public double FrameHeight
        {
            get => _pagewidth * 0.8 / 8 * 16 / 9;

        }

        public double MainFrameWidth
        {
            get => _pagewidth * 0.8;

        }

        public double MainFrameHeight
        {
            get => _pagewidth * 0.8 / 8 * 16 / 9;

        }

        private double _pagewidth;
        public double PageWidth
        {
            get => _pagewidth;


            set
            {
                if (_pagewidth == value) return;
                _pagewidth = value;
                OnPropertyChanged(nameof(PageWidth));
                OnPropertyChanged(nameof(FrameWidth));
                OnPropertyChanged(nameof(FrameHeight));
            }
        }

        public ObservableCollection<char> Numbers { get; }
    }
}
