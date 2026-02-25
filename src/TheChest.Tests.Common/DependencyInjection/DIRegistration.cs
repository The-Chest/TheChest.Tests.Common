using System;

namespace TheChest.Tests.Common.DependencyInjection
{
    public sealed class Registration
    {
        public Type ServiceType { get; }
        public Type ImplementationType { get; }
        public Func<DIContainer, object> Factory { get; }

        public Registration(Type serviceType, Type implType)
        {
            ServiceType = serviceType;
            ImplementationType = implType;
        }

        public Registration(Type serviceType, Func<DIContainer, object> factory)
        {
            ServiceType = serviceType;
            Factory = factory;
        }
    }
}
