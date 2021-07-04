using System;
using System.ComponentModel;

namespace Samples.Finder.Application.Controls.Base
{
    internal class ConcreteClassProvider : TypeDescriptionProvider
    {
        public ConcreteClassProvider()
            : base(TypeDescriptor.GetProvider(typeof (FormBase)))
        {
        }

        public override Type GetReflectionType(Type objectType, object instance)
        {
            if (objectType == typeof(FormBase))
            {
                return typeof(ConcreteForm);
            }
            if (objectType == typeof(UserControlBase))
            {
                return typeof(ConcreteUserControl);
            }
            return base.GetReflectionType(objectType, instance);
        }

        public override object CreateInstance(IServiceProvider provider, Type objectType, Type[] argTypes, object[] args)
        {
            if (objectType == typeof(FormBase))
            {
                objectType = typeof (ConcreteForm);
            }
            if (objectType == typeof(UserControlBase))
            {
                objectType = typeof (ConcreteUserControl);
            }
            return base.CreateInstance(provider, objectType, argTypes, args);
        }
    }
}