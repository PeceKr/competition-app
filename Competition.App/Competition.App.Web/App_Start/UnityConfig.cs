using Competition.App.Domain.Repository;
using Competition.App.Domain.Repository.CompetitionRepository;
using Competition.App.Domain.Repository.MatchRepository;
using Competition.App.Domain.Repository.TeamsRepository;
using Competition.App.Services.CompetitionServices;
using Competition.App.Services.HomeService;
using Competition.App.Services.MatchServices;
using Competition.App.Services.ModelFactory;
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

            container.RegisterType<IMatchRepository, MatchRepository>();

            container.RegisterType<IMatchServices, MatchesServices>();

            container.RegisterType<ITeamsRepository, TeamsRepository>();

            container.RegisterType<ICompetitionRepository, CompetitionRepository>();

            container.RegisterType<IHomeService, HomeService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}