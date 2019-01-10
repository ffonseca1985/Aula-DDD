using CQRSlite.Config;
using System;

namespace SistemaBancarioSiteWeb.App_Start
{
    public class CustomDependencyResolverMvc
        : IServiceLocator
    {
        public T GetService<T>()
        {
            return Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<T>();
        }

        public object GetService(Type type)
        {
            return Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance(type);
        }
    }
}