using Competition.App.Common.ViewModels.Competition;
using Competition.App.Common.ViewModels.Matches;
using Competition.App.Common.ViewModels.Teams;
using Competition.App.Domain.Entities;
using System.Collections.Generic;

namespace Competition.App.Services.ModelFactory
{
    public interface IModelsFactory
    {
        Teams CreateTeamsEntityObject(TeamsViewModel viewModel);

        List<TeamsViewModel> ReturnTeamsViewModelList(List<Teams> teams);

        TeamsViewModel CreateTeamViewModel(Teams team);

        Teams MapTeamObjectForEdit(Teams entity, TeamsViewModel viewModel);

        List<CompetitionViewModel> ReturnCompetitionsViewModel(List<Competitions> competitions);

        Competitions CreateCompetitionEntity(CompetitionViewModel model);

        Matches CreateMatchEntity(MatchesViewModel model);

        List<MatchesViewModel> CreateMatchesViewModel(List<Matches> matches);
    }
}
