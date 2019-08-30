using Competition.App.Common.ViewModels.Teams;
using Competition.App.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Competition.App.Common
{
    public static class ModelFactory
    {
        public static Teams CreateTeamsEntityObject (TeamsViewModel viewModel)
        {
            return new Teams
            {
                TeamName = viewModel.TeamName,
                Country = viewModel.Country
            };
        }

        public static List<TeamsViewModel> ReturnTeamsViewModelList(List<Teams> teams)
        {
            return teams.ConvertAll(x => new TeamsViewModel
            {
                Country = x.Country,
                TeamId = x.TeamId,
                TeamName = x.TeamName
            }).ToList();
        }

        public static TeamsViewModel CreateTeamViewModel(Teams team)
        {
            return new TeamsViewModel
            {
                TeamId = team.TeamId,
                TeamName = team.TeamName,
                Country = team.Country
            };
        }

        public static Teams MapTeamObjectForEdit (Teams entity, TeamsViewModel viewModel)
        {
            entity.TeamName = viewModel.TeamName;
            entity.Country = viewModel.Country;

            return entity;
        }
    }
}
