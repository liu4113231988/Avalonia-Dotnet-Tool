using Avalonia.Input;
using Avalonia.Interactivity;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace DotNetTool.ViewModels
{
    public partial class TimestampViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string timestamp;

        [ObservableProperty]
        private string date;

        [ObservableProperty]
        private string time;



        public ICommand KeyDownCommand { get; set; }




        public TimestampViewModel()
        {
            SetNow();
            KeyDownCommand = new RelayCommand<KeyEventArgs>(KeyDown);
        }

        [RelayCommand]
        public void DateChange()
        {
            if (!string.IsNullOrWhiteSpace(Date))
            {
                string temp = Date.Split(' ')[0];
                DateTimeOffset dateTimeOffset = DateTimeOffset.Parse(temp + " " + Time);
                Timestamp = dateTimeOffset.ToUnixTimeMilliseconds().ToString();
            }
        }

        [RelayCommand]
        public void TimestampChange()
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(Timestamp));
            Date = dateTimeOffset.ToLocalTime().ToString("yyyy-MM-dd");
            Time = dateTimeOffset.ToLocalTime().ToString("HH:mm:ss");
        }

        [RelayCommand]
        public void SetNow()
        {
            Timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();
            Date = DateTimeOffset.Now.ToLocalTime().ToString("yyyy-MM-dd");
            Time = DateTimeOffset.Now.ToLocalTime().ToString("HH:mm:ss");
        }

        void KeyDown(KeyEventArgs e)
        {
            if (!(e.Key == Key.D0 || e.Key == Key.D1 || e.Key == Key.D2
            || e.Key == Key.D3 || e.Key == Key.D4 || e.Key == Key.D5 || e.Key == Key.D6
            || e.Key == Key.D7 || e.Key == Key.D8 || e.Key == Key.D9 || e.Key == Key.NumPad0
            || e.Key == Key.NumPad1 || e.Key == Key.NumPad2 || e.Key == Key.NumPad3
            || e.Key == Key.NumPad4 || e.Key == Key.NumPad5 || e.Key == Key.NumPad6
            || e.Key == Key.NumPad7 || e.Key == Key.NumPad8 || e.Key == Key.NumPad9)) e.Handled = true;
        }
    }
}
