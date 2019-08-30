using Competition.App.Domain.Repository;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Competition.App.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IRepository, Repository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}