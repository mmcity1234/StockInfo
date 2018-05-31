using MvvmCross.Core.ViewModels;
using StockInfo.Uwp.Common;
using StockInfo.Uwp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace StockInfo.Uwp.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private string _hello = "Hello MvvmCross";

        public IStockQueryService StockService { get; set; }
        
        public DelegateCommand<string> AutoSuggestSearchCommand { get; }

        public DelegateCommand<AutoSuggestBoxTextChangedEventArgs> AutoSuggestTextChangeCommand { get; set; }
     

        public MainViewModel()
        {
            AutoSuggestSearchCommand = new DelegateCommand<string>(AutoSuggestSearchEvent);
            AutoSuggestTextChangeCommand = new DelegateCommand<AutoSuggestBoxTextChangedEventArgs>(AutoSuggestTextChangeEvent);
        }

        private void AutoSuggestSearchEvent(string o)
        {
            // CODE HERE
        }

        private void AutoSuggestTextChangeEvent(AutoSuggestBoxTextChangedEventArgs args)
        {
            
            //args.Reason
        }
    }
}
