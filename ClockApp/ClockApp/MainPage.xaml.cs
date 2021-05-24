using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

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
            DateTime date = new DateTime();
            date = DateTime.Now;

            string sdate = date.ToString();

            Numbers = new ObservableCollection<char>();

            Numbers.Add(sdate[11]);
            Numbers.Add(sdate[12]);
            Numbers.Add(sdate[13]);
            Numbers.Add(sdate[14]);
            Numbers.Add(sdate[15]);
            Numbers.Add(sdate[16]);
            Numbers.Add(sdate[17]);
            Numbers.Add(sdate[18]);
        }

        public ObservableCollection<char> Numbers { get; }

    }
}
