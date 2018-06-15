using Autofac.Core;
using MvvmCross.Platform.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInfo.Uwp.Common.IoC
{
    /// <summary>
    /// Autofac property injection options.
    /// </summary>
    /// <seealso cref="Autofac.Extras.MvvmCross.IAutofacPropertyInjectorOptions" />
    public class AutofacPropertyInjectorOptions : MvxPropertyInjectorOptions, IAutofacPropertyInjectorOptions
    {
        /// <summary>
        /// Gets or sets the mechanism that determines properties to inject.
        /// </summary>
        /// <value>
        /// An <see cref="IPropertySelector" /> that allows for custom determination of
        /// which properties to inject when property injection is enabled.
        /// </value>
        public IPropertySelector PropertyInjectionSelector { get; set; }
    }

}
