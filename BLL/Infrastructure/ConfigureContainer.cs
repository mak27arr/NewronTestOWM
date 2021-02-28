using Autofac;
using NewronTestOWM.BLL.Interface;
using NewronTestOWM.BLL.Module;
using NewronTestOWM.BLL.Module.WetherAPI;
using System;
using System.IO;

namespace DriverClientLib.BLL.Infrastructure
{
    public static class ConfigureContainer
    {
        public static IContainer Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder = RegisterAllType(builder);
            return builder.Build();
        }
        internal static ContainerBuilder RegisterAllType(ContainerBuilder builder)
        {
            builder.RegisterType<IPHelper>().As<IIPHelper>();
            builder.RegisterType<RESTConector>().As<IRESTConector>();
            builder.RegisterType<IpstackLocationGetter>().As<ILocationGetter>().WithParameter("api_token", "baa0f72f9a00accf3dbe3e7bd1b18899");
            builder.RegisterType<WeatherBitWeatherGeter>().As<IWeatherGeter>().WithParameter("api_token", "698b7ec333944de08f62ef1921edecd2");
            return builder;
        }
    }
}
