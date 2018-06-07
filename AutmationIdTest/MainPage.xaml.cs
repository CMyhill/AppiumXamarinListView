using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppiumFormListView
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MyViewModel();
            Title = "Blah";
        }
    }

    public class MyViewModel : INotifyPropertyChanged
    {
        List<MyObject> _allTheData = new List<MyObject>();

        public event PropertyChangedEventHandler PropertyChanged;

        public MyViewModel()
        {
            Task.Delay(TimeSpan.FromSeconds(3)).ContinueWith((arg) =>
            {
                _allTheData = new List<MyObject>{
                new MyObject { AValue = "sdklsdkjfh"},
                new MyObject { AValue = "sdkfh"},
                new MyObject { AValue = "sdkfxdfsdfjkhh"},
            };
                Device.BeginInvokeOnMainThread(() =>
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AllTheData)));
                });
            });
        }

        public List<MyObject> AllTheData => _allTheData;
    }

    public class MyObject
    {
        public string AValue
        {
            get;
            set;
        }
    }
}
