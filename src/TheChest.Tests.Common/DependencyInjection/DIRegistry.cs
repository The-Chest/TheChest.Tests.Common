using System;
using System.Collections.Generic;
using System.Linq;

namespace TheChest.Tests.Common.DependencyInjection
{
    public sealed class DIRegistry
    {
        private readonly Dictionary<Type, Registration> registrations;
        private readonly List<Registration> openGenericRegistrations;

        public DIRegistry()
        {
            this.registrations = new Dictionary<Type, Registration>();
            this.openGenericRegistrations = new List<Registration>();
        }

        public void Register<TService, TImpl>() where TImpl : TService
        {
            this.Register(typeof(TService), typeof(TImpl));
        }

        public void Register(Type serviceType, Type implementationType)
        {
            var registration = new Registration(serviceType, implementationType);

            if (serviceType.IsGenericTypeDefinition || implementationType.IsGenericTypeDefinition)
            {
                this.openGenericRegistrations.Add(registration);
            }
            else 
            {
                this.registrations[serviceType] = registration;
            }
        }

        public void Register<TService>(Func<DIContainer, object> factory)
        {
            this.registrations[typeof(TService)] = new Registration(typeof(TService), factory);
        }

        public void Register<TService>(TService instance)
        {
            if (instance is null)
                throw new ArgumentNullException(nameof(instance));

            var serviceType = typeof(TService);
            this.registrations[serviceType] = new Registration(serviceType, c => instance);
        }

        public bool IsRegistered<TService>()
        {
            return this.TryGetRegistration(typeof(TService), out var _);
        }

        public bool TryGetRegistration(Type serviceType, out Registration registration)
        {
            if (registrations.TryGetValue(serviceType, out registration))
                return true;

            if (serviceType.IsGenericType)
            {
                var genDef = serviceType.GetGenericTypeDefinition();
                var match = this.openGenericRegistrations.FirstOrDefault(r => r.ServiceType == genDef);
                if (match != null)
                {
                    if (match.ImplementationType == null)
                        throw new InvalidOperationException("Open generic registration has no implementation type");

                    var implType = match.ImplementationType.MakeGenericType(serviceType.GetGenericArguments());
                    registration = new Registration(serviceType, implType);
                    return true;
                }
            }

            registration = null;
            return false;
        }
    }
}
