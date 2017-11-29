
using Microsoft.Extensions.DependencyInjection;
using SayWa.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Role.Core
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AddCoreList(this IServiceCollection services)
        {
            services.AddScoped(typeof(ConnectionFactory));
            var servicetypes = ReflectionEx.GetServiceList("Role.Service", "Service", new List<string>() { "BaseService" });
            foreach (var item in servicetypes)
            {
                services.AddScoped(item);
            }

            var types = ReflectionEx.GetServiceList("Role.Business","Bll",new List<string>() { "BaseBll", "BaseBllExtend"});
            foreach (var item in types)
            {
                services.AddScoped(item);
            }
            return services;
        }
    }

    public class ReflectionEx
    {
        public static List<Type> GetServiceList(string assemName,string endStr,List<string> filter=null)
        {
            Assembly assembly = Assembly.Load(new AssemblyName(assemName));
            var lst = assembly.GetTypes().ToList();
            if (lst == null || lst.Count <= 0) return new List<Type>();
            for (int i = lst.Count - 1; i >= 0; i--)
            {
                var item = lst[i];
                var name = item.Name;
                if (!name.EndsWith(endStr))
                {
                    lst.Remove(item);
                    continue;
                }             
                if (filter != null)
                {
                    if (filter.Contains(name))
                    {
                        lst.Remove(item);
                        continue;
                    }
                }              
            }
            return lst;
        }
    }
}
