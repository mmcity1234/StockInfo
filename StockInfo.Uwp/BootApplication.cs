using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MvvmCross.Platform.IoC;
using StockInfo.Uwp.ViewModels;
using System.Reflection;
using MvvmCross.Platform;
using StockInfo.Uwp.Common.IoC;

namespace StockInfo.Uwp
{
    public class BootApplication : MvvmCross.Core.ViewModels.MvxApplication
    {
        
        public override void Initialize()
        {
            RegisterNavigationServiceAppStart<MainViewModel>();

            // Mvx DI

            IocProvider.Instance.Container.Build();
        }
    }
}