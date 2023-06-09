﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace Contool
{
    public static class ServiceExtensions
    {
        public static void AddServicesFromAssembly(this IServiceCollection services, Assembly assembly)
        {
            var implementationTypes = assembly
                .GetTypes()
                .Where(x => x.IsClass && !x.IsAbstract && x.IsDefined(typeof(ServiceBaseAttribute), false))
                .ToList();

            foreach (var implementationType in implementationTypes)
            {
                if (services.Any(x => x.ImplementationType == implementationType))
                {
                    continue;
                }

                var serviceBaseAttributeCount = implementationType.CustomAttributes
                    .Count(x => x.AttributeType.BaseType == typeof(ServiceBaseAttribute));

                if (serviceBaseAttributeCount > 1)
                {
                    throw new MultipleServiceAttributeException(implementationType);
                }

                ServiceLifetime serviceLifetime;

                if (implementationType.IsDefined(typeof(SingletonServiceAttribute), false))
                {
                    serviceLifetime = ServiceLifetime.Singleton;
                }
                else if (implementationType.IsDefined(typeof(ScopedServiceAttribute), false))
                {
                    serviceLifetime = ServiceLifetime.Scoped;
                }
                else
                {
                    serviceLifetime = ServiceLifetime.Transient;
                }

                var serviceType = implementationType.GetInterface($"I{implementationType.Name}") ?? implementationType;

                var serviceDescriptor = new ServiceDescriptor(serviceType, implementationType, serviceLifetime);
                
                services.Add(serviceDescriptor);
            }
        }

        public static void AddServicesFromAssembly(this IServiceCollection services, Assembly assembly, string classNameEndsWith, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        {
            var implementationTypes = assembly
                .GetTypes()
                .Where(x => x.IsClass && !x.IsAbstract && x.Name.EndsWith(classNameEndsWith))
                .ToList();

            foreach (var implementationType in implementationTypes)
            {
                if (services.Any(x => x.ImplementationType == implementationType))
                {
                    continue;
                }

                var serviceType = implementationType.GetInterface($"I{implementationType.Name}") ?? implementationType;

                var serviceDescriptor = new ServiceDescriptor(serviceType, implementationType, serviceLifetime);

                services.Add(serviceDescriptor);
            }
        }

        public static void AddServicesFromAssembly(this IServiceCollection services, Assembly assembly, Func<string, bool> classNameCriteria, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        {
            var implementationTypes = assembly
                .GetTypes()
                .Where(x => x.IsClass && !x.IsAbstract && classNameCriteria(x.Name))
                .ToList();

            foreach (var implementationType in implementationTypes)
            {
                if (services.Any(x => x.ImplementationType == implementationType))
                {
                    continue;
                }

                var serviceType = implementationType.GetInterface($"I{implementationType.Name}") ?? implementationType;

                var serviceDescriptor = new ServiceDescriptor(serviceType, implementationType, serviceLifetime);

                services.Add(serviceDescriptor);
            }
        }

        public static void AddServicesFromAssemblies(this IServiceCollection services, Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                AddServicesFromAssembly(services, assembly);
            }
        }

        public static void AddServicesFromAssemblies(this IServiceCollection services, Assembly[] assemblies, string classNameEndsWith, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        {
            foreach (var assembly in assemblies)
            {
                AddServicesFromAssembly(services, assembly, classNameEndsWith, serviceLifetime);
            }
        }

        public static void AddServicesFromAssemblies(this IServiceCollection services, Assembly[] assemblies, Func<string, bool> classNameCriteria, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        {
            foreach (var assembly in assemblies)
            {
                AddServicesFromAssembly(services, assembly, classNameCriteria, serviceLifetime);
            }
        }
    }
}
