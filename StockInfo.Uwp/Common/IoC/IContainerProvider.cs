using MvvmCross.Platform.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInfo.Uwp.Common.IoC
{
    public interface IContainerProvider : IMvxIoCProvider
    {
        /// <summary>
        /// Build the container and store it for later use. 
        /// </summary>
        void Build();
    }
}
