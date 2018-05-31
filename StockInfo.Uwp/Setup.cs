using MvvmCross.Core.ViewModels;
using MvvmCross.Uwp.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using MvvmCross.Platform.Logging;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform.IoC;
using Autofac;
using System.Reflection;
using StockInfo.Uwp.Common.IoC;

namespace StockInfo.Uwp
{
    public class Setup : MvxWindowsSetup
    {


        public Setup(Frame rootFrame) : base(rootFrame)
        {

        }


        protected override MvxLogProviderType GetDefaultLogProviderType() => MvxLogProviderType.None;

        protected override IMvxTrace CreateDebugTrace() => new DebugTrace();

        protected override IMvxIoCProvider CreateIocProvider()
        {
            var builder = new ContainerBuilder();

            // This is an important step that ensures all the ViewModel's are loaded into the container.
            // Without this, it was observed that MvvmCross wouldn't register them by itself; needs more investigation.

            Assembly assembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(assembly)
                .AssignableTo<MvxViewModel>()
                .As<IMvxViewModel, MvxViewModel>()
                .AsSelf();

            IContainerProvider container = new AutofacMvxIocProvider(builder);
            IocProvider.Instance.InitializeContainer(container);

            return container;
        }

        protected override IMvxIocOptions CreateIocOptions()
        {
            return new MvxIocOptions()
            {
                PropertyInjectorOptions = MvxPropertyInjectorOptions.All
            };
        }

        protected override IMvxApplication CreateApp()
        {
            return new BootApplication();


        }
    }

}
