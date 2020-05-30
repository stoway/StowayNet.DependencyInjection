using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StowayNet
{
    internal class InternalServiceRegister
    {
        public static void Register(IServiceCollection services, List<Type> types, IConfiguration configuration)
        {
            var serviceType = typeof(IStowayDependency);
            var stTypes = types.Where(t => !t.IsAbstract && !t.IsInterface).ToList();

            var transients = stTypes.Where(t =>
                (t.GetCustomAttributes(typeof(StowayDependencyAttribute), false).Length == 0 && serviceType.IsAssignableFrom(t))
                || t.GetCustomAttributes(typeof(StowayDependencyAttribute), false).Count(p => (p as StowayDependencyAttribute).Type == StowayDependencyType.Transient) > 0).ToArray();

            services.RegisterTypes(transients, ServiceLifetime.Transient, true, true);

            stTypes = stTypes.Where(t => !transients.Contains(t) && t.GetCustomAttributes(typeof(StowayDependencyAttribute), false).Length > 0).ToList();

            var singletons = stTypes.Where(t => t.GetCustomAttributes(typeof(StowayDependencyAttribute), false).Count(p => (p as StowayDependencyAttribute).Type == StowayDependencyType.Singleton) > 0).ToArray();

            services.RegisterTypes(singletons, ServiceLifetime.Singleton, true, true);

            var scopes = stTypes.Where(t => t.GetCustomAttributes(typeof(StowayDependencyAttribute), false).Count(p => (p as StowayDependencyAttribute).Type == StowayDependencyType.Scoped) > 0).ToArray();

            services.RegisterTypes(scopes, ServiceLifetime.Scoped, true, true);


        }
    }
}
