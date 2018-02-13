﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MvvmCross.Platform.IoC;
using StockInfo.Uwp.Views;

namespace StockInfo.Uwp
{
    public class BootApplication : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")           
                .AsInterfaces()
                .RegisterAsLazySingleton();


            RegisterNavigationServiceAppStart<MainViewModel>();
        }
    }
}