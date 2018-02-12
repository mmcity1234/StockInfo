using MvvmCross.Core.ViewModels;
using MvvmCross.Uwp.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using MvvmCross.Platform.Logging;

namespace StockInfo.Uwp
{
    public class Setup : MvxWindowsSetup
    {
      

        public Setup(Frame rootFrame) : base(rootFrame)
        {

        }
       

        protected override MvxLogProviderType GetDefaultLogProviderType() => MvxLogProviderType.None;
      

        protected override IMvxApplication CreateApp()
        {
            return new BootApplication();
        }
    }

}
