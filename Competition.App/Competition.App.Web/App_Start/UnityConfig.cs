using Competition.App.Common.ModelFactory;
using Competition.App.Domain.Repository;
using Competition.App.Services.CompetitionServices;
using Competition.App.Services.TeamsServices;
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

            container.RegisterType<ITeamsServices, TeamsServices>();

            container.RegisterType<ICompetitionServices, CompetitionServices>();

            container.RegisterType<IModelsFactory, ModelsFactory>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}