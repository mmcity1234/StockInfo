using Autofac;
using Autofac.Core;
using MvvmCross.Platform.Core;
using MvvmCross.Platform.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInfo.Uwp.Common.IoC
{
    public class AutofacMvxIocProvider : MvxSingleton<IMvxIoCProvider>, IContainerProvider
    {
        private IContainer container;

        private ContainerBuilder builder;


        public AutofacMvxIocProvider(ContainerBuilder builder)
        {
            this.builder = builder ?? throw new ArgumentNullException("builder");
        }

        public bool CanResolve<T>() where T : class
        {
            return container.IsRegistered<T>();
        }

        public bool CanResolve(Type type)
        {
            
            return container.IsRegistered(type);
        }

        public T Resolve<T>() where T : class
        {
            return container.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return container.Resolve(type);
        }

        public T Create<T>() where T : class
        {
            return Resolve<T>();
        }

        public object Create(Type type)
        {
            return Resolve(type);
        }

        public T GetSingleton<T>() where T : class
        {
            return Resolve<T>();
        }

        public object GetSingleton(Type type)
        {
            return Resolve(type);
        }

        public bool TryResolve<T>(out T resolved) where T : class
        {
            return container.TryResolve(out resolved);
        }

        public bool TryResolve(Type type, out object resolved)
        {
            return container.TryResolve(type, out resolved);
        }

        public void RegisterType<TFrom, TTo>()
            where TFrom : class
            where TTo : class, TFrom
        {
            builder.RegisterType<TTo>().As<TFrom>().AsSelf();
        }

        public void RegisterType(Type tFrom, Type tTo)
        {            
            builder.RegisterType(tTo).As(tFrom).AsSelf();
        }

        public void RegisterSingleton<TInterface>(TInterface theObject) where TInterface : class
        {

            builder.RegisterInstance(theObject).As<TInterface>().AsSelf().SingleInstance();
        }

        public void RegisterSingleton(Type tInterface, object theObject)
        {
            builder.RegisterInstance(theObject).As(tInterface).AsSelf().SingleInstance();
        }

        public void RegisterSingleton<TInterface>(Func<TInterface> theConstructor) where TInterface : class
        {
            builder.Register(cc => theConstructor()).As<TInterface>().AsSelf().SingleInstance();
        }

        public void RegisterSingleton(Type tInterface, Func<object> theConstructor)
        {
            builder.Register(cc => theConstructor()).As(tInterface).AsSelf().SingleInstance();
        }

        public T IoCConstruct<T>() where T : class
        {
            return (T)IoCConstruct(typeof(T));
        }

        public object IoCConstruct(Type type)
        {
            return Resolve(type);
        }

        public void CallbackWhenRegistered<T>(Action action)
        {
            CallbackWhenRegistered(typeof(T), action);
        }

        public void CallbackWhenRegistered(Type type, Action action)
        {
            container.ComponentRegistry.Registered += (sender, args) => {
                if (args.ComponentRegistration.Services.OfType<TypedService>().Any(x => x.ServiceType == type))
                {
                    action();
                }
            };
        }

        public void RegisterType<TInterface>(Func<TInterface> constructor) where TInterface : class
        {
            builder.Register(context => constructor()).As<TInterface>();
        }

        public void RegisterType(Type t, Func<object> constructor)
        {
            builder.Register(context => constructor()).As(t);
        }

        public void Build()
        {
            container = builder.Build();
        }
    }

}
