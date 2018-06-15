using StockInfo.Uwp.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace StockInfo.Uwp.Services
{
    public class NavigationService : INavigationService
    {
        private Frame _frame;
        private Frame Frame
        {
            get
            {
                if(_frame == null)
                    _frame = ControlHelper.FindFirstChildren<Frame>(Window.Current.Content);
                return _frame;
            }
        }

        public NavigationService()
        {            
        }

        public void Navigate(Type sourcePage)
        {
            Frame.Navigate(sourcePage);
        }

        public void Navigate(Type sourcePage, object parameter)
        {
            Frame.Navigate(sourcePage, parameter);
        }

        public void GoBack()
        {
            Frame.GoBack();
        }
    }
}
