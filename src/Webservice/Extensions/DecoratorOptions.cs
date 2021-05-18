using System;
using System.Collections.Generic;

namespace Webservice.Extensions
{
    public class DecoratorOptions<TInterface>
    {
        internal Queue<Type> Order { get; set; }

        internal DecoratorOptions()
        {
            Order = new Queue<Type>();
        }

        public DecoratorOptions<TInterface> DecorateWith<TImplementation>()
            where TImplementation : TInterface
        {
            Order.Enqueue(typeof(TImplementation));
            return this;
        }
    }
}
