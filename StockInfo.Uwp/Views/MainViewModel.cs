using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInfo.Uwp.Views
{
    public class MainViewModel : MvxViewModel
    {
        private string _hello = "Hello MvvmCross";
        public string Hello
        {
            get
            {
                return _hello;
            }
            set
            {
                SetProperty(ref _hello, value);
            }
        }

    }
}
